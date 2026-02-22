using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using QLHieuSuat.Models;

[Authorize(Roles = "Admin")]
public class UserController : Controller
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly RoleManager<IdentityRole> _roleManager;

    public UserController(UserManager<ApplicationUser> userManager,
                          RoleManager<IdentityRole> roleManager)
    {
        _userManager = userManager;
        _roleManager = roleManager;
    }

    // DANH SÁCH USER
    public async Task<IActionResult> Index()
    {
        var users = _userManager.Users.ToList();
        var roles = _roleManager.Roles.ToList();

        var userList = new List<UserViewModel>();

        foreach (var user in users)
        {
            var userRoles = await _userManager.GetRolesAsync(user);

            userList.Add(new UserViewModel
            {
                Id = user.Id,
                Email = user.Email,
                UserName = user.UserName,
                Role = userRoles.FirstOrDefault(),
                AllRoles = roles
            });
        }

        return View(userList);
    }

    // CREATE GET
    public IActionResult Create()
    {
        ViewBag.Roles = _roleManager.Roles.ToList();
        return View();
    }

    // CREATE POST
    [HttpPost]
    public async Task<IActionResult> Create(string email, string password, string role)
    {
        var user = new ApplicationUser
        {
            UserName = email,
            Email = email
        };

        var result = await _userManager.CreateAsync(user, password);

        if (result.Succeeded)
        {
            await _userManager.AddToRoleAsync(user, role);
            return RedirectToAction("Index");
        }

        foreach (var error in result.Errors)
        {
            ModelState.AddModelError("", error.Description);
        }

        ViewBag.Roles = _roleManager.Roles.ToList();
        return View();
    }

    // UPDATE ROLE
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> UpdateRole(string userId, string newRole)
    {
        var user = await _userManager.FindByIdAsync(userId);
        if (user == null)
            return NotFound();

        var currentUserId = _userManager.GetUserId(User);

        // Không cho đổi role chính mình
        if (userId == currentUserId)
        {
            TempData["Error"] = "Bạn không thể thay đổi role của chính mình!";
            return RedirectToAction("Index");
        }

        var currentRoles = await _userManager.GetRolesAsync(user);

        await _userManager.RemoveFromRolesAsync(user, currentRoles);
        await _userManager.AddToRoleAsync(user, newRole);

        TempData["Success"] = "Cập nhật Role thành công!";
        return RedirectToAction("Index");
    }

    // DELETE GET
    public async Task<IActionResult> Delete(string id)
    {
        if (id == null)
            return NotFound();

        var user = await _userManager.FindByIdAsync(id);
        if (user == null)
            return NotFound();

        return View(user);
    }

    // DELETE POST
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(string id)
    {
        var currentUserId = _userManager.GetUserId(User);

        if (id == currentUserId)
        {
            TempData["Error"] = "Bạn không thể xóa chính mình!";
            return RedirectToAction("Index");
        }

        var user = await _userManager.FindByIdAsync(id);
        if (user != null)
        {
            await _userManager.DeleteAsync(user);
            TempData["Success"] = "Xóa tài khoản thành công!";
        }

        return RedirectToAction("Index");
    }

    // GET: ResetPassword
    public async Task<IActionResult> ResetPassword(string id)
    {
        if (id == null)
            return NotFound();

        var user = await _userManager.FindByIdAsync(id);
        if (user == null)
            return NotFound();

        return View(new ResetPasswordViewModel
        {
            UserId = user.Id,
            Email = user.Email
        });
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> ResetPassword(ResetPasswordViewModel model)
    {
        if (!ModelState.IsValid)
            return View(model);

        var currentUserId = _userManager.GetUserId(User);

        if (model.UserId == currentUserId)
        {
            TempData["Error"] = "Bạn không thể reset mật khẩu của chính mình!";
            return RedirectToAction("Index");
        }

        var user = await _userManager.FindByIdAsync(model.UserId);
        if (user == null)
            return NotFound();

        var token = await _userManager.GeneratePasswordResetTokenAsync(user);
        var result = await _userManager.ResetPasswordAsync(user, token, model.NewPassword);

        if (result.Succeeded)
        {
            TempData["Success"] = "Reset mật khẩu thành công!";
            return RedirectToAction("Index");
        }

        foreach (var error in result.Errors)
        {
            ModelState.AddModelError("", error.Description);
        }

        return View(model);
    }
}
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using QLHieuSuat.Models;

[Authorize]
public class MyTasksController : Controller
{
    private readonly ApplicationDbContext _context;

    public MyTasksController(ApplicationDbContext context)
    {
        _context = context;
    }

    //public async Task<IActionResult> Index()
    //{
    //    // Lấy UserId đang đăng nhập
    //    var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

    //    // Tìm Employee tương ứng
    //    var employee = await _context.Employees
    //        .FirstOrDefaultAsync(e => e.ApplicationUserId == userId);

    //    if (employee == null)
    //        return Content("Tài khoản này chưa được liên kết với nhân viên.");

    //    var tasks = await _context.TaskAssignments
    //        .Where(a => a.EmployeeId == employee.Id)
    //        .Select(a => a.TaskItem)
    //        .Include(t => t.Project)
    //        .ToListAsync();

    //    return View(tasks);
    //}

    //public async Task<IActionResult> Index()
    //{
    //    var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
    //    return Content("UserId hiện tại: " + userId);
    //}

    public async Task<IActionResult> Index()
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

        var employee = await _context.Employees
            .FirstOrDefaultAsync(e => e.ApplicationUserId == userId);

        if (employee == null)
            return Content("Tài khoản này chưa được liên kết với nhân viên.");

        var tasks = await _context.TaskAssignments
            .Where(a => a.EmployeeId == employee.Id)
            .Include(a => a.TaskItem)
                .ThenInclude(t => t.Project)
            .Select(a => a.TaskItem)
            .ToListAsync();

        // 🔥 TÍNH KPI Ở ĐÂY
        double kpi = 0;

        if (tasks.Count > 0)
        {
            kpi = tasks.Average(t => t.ProgressPercent);
        }

        ViewBag.KPI = Math.Round(kpi, 2);

        ViewBag.KPI = kpi;

        return View(tasks);
    }

    public async Task<IActionResult> UpdateProgress(int id)
    {
        var task = await _context.TaskItems.FindAsync(id);

        if (task == null)
            return NotFound();

        return View(task);
    }

    [HttpPost]
    public async Task<IActionResult> UpdateProgress(int id, int ProgressPercent)
    {
        var task = await _context.TaskItems.FindAsync(id);

        if (task == null)
            return NotFound();

        task.ProgressPercent = ProgressPercent;

        if (ProgressPercent == 100)
            task.Status = "Hoàn thành";
        else
            task.Status = "Đang thực hiện";

        await _context.SaveChangesAsync();

        return RedirectToAction(nameof(Index));
    }
}
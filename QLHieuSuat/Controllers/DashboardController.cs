using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QLHieuSuat.Models;
using System.Security.Claims;

[Authorize]
public class DashboardController : Controller
{
    private readonly ApplicationDbContext _context;

    public DashboardController(ApplicationDbContext context)
    {
        _context = context;
    }

    //public async Task<IActionResult> Index()
    //{
    //    var totalTasks = await _context.TaskItems.CountAsync();
    //    var completedTasks = await _context.TaskItems
    //        .CountAsync(t => t.ProgressPercent == 100);
    //    var inProgressTasks = await _context.TaskItems
    //        .CountAsync(t => t.ProgressPercent < 100);

    //    double avgKpi = 0;

    //    if (totalTasks > 0)
    //    {
    //        avgKpi = await _context.TaskItems
    //            .AverageAsync(t => t.ProgressPercent);
    //    }

    //    ViewBag.TotalTasks = totalTasks;
    //    ViewBag.CompletedTasks = completedTasks;
    //    ViewBag.InProgressTasks = inProgressTasks;
    //    ViewBag.AvgKpi = Math.Round(avgKpi, 2);



    //    var monthlyData = await _context.TaskItems
    //    .GroupBy(t => t.CreatedDate.Month)
    //    .Select(g => new
    //    {
    //        Month = g.Key,
    //        AvgProgress = g.Average(t => t.ProgressPercent)
    //    })
    //    .OrderBy(x => x.Month)
    //    .ToListAsync();

    //        ViewBag.MonthLabels = monthlyData
    //            .Select(x => "Tháng " + x.Month)
    //            .ToList();

    //        ViewBag.MonthData = monthlyData
    //            .Select(x => Math.Round(x.AvgProgress, 2))
    //            .ToList();



    //    var employeeStats = await _context.TaskItems
    //    .Include(t => t.Employee)
    //    .GroupBy(t => t.Employee.FullName)
    //    .Select(g => new
    //    {
    //        EmployeeName = g.Key,
    //        TotalTasks = g.Count()
    //    })
    //    .ToListAsync();

    //        ViewBag.EmployeeNames = employeeStats.Select(x => x.EmployeeName).ToList();
    //        ViewBag.EmployeeTotals = employeeStats.Select(x => x.TotalTasks).ToList();



    //    var departmentStats = await _context.TaskItems
    //    .Include(t => t.Employee)
    //        .ThenInclude(e => e.Department)
    //    .Where(t => t.Employee != null && t.Employee.Department != null)
    //    .GroupBy(t => t.Employee.Department.Name)
    //    .Select(g => new
    //    {
    //        DepartmentName = g.Key,
    //        TotalTasks = g.Count()
    //    })
    //    .ToListAsync();

    //        ViewBag.DepartmentNames = departmentStats.Select(x => x.DepartmentName).ToList();
    //        ViewBag.DepartmentTotals = departmentStats.Select(x => x.TotalTasks).ToList();


    //    return View();
    //}

    public async Task<IActionResult> Index()
    {
        IQueryable<TaskItem> tasksQuery;

        if (User.IsInRole("Admin"))
        {
            // Admin xem tất cả
            tasksQuery = _context.TaskItems;
        }
        else
        {
            // Nhân viên chỉ xem task của mình
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var employee = await _context.Employees
                .FirstOrDefaultAsync(e => e.ApplicationUserId == userId);

            if (employee == null)
            {
                return View(); // Không có employee thì trả về view rỗng
            }

            tasksQuery = _context.TaskItems
                .Where(t => t.EmployeeId == employee.Id);
        }

        // ===== TÍNH TOÁN CHUNG =====
        var totalTasks = await tasksQuery.CountAsync();
        var completedTasks = await tasksQuery
            .CountAsync(t => t.ProgressPercent == 100);
        var inProgressTasks = await tasksQuery
            .CountAsync(t => t.ProgressPercent < 100);

        double avgKpi = 0;
        if (totalTasks > 0)
        {
            avgKpi = await tasksQuery
                .AverageAsync(t => t.ProgressPercent);
        }

        ViewBag.TotalTasks = totalTasks;
        ViewBag.CompletedTasks = completedTasks;
        ViewBag.InProgressTasks = inProgressTasks;
        ViewBag.AvgKpi = Math.Round(avgKpi, 2);

        // ===== KPI THEO THÁNG =====
        var monthlyData = await tasksQuery
            .GroupBy(t => t.CreatedDate.Month)
            .Select(g => new
            {
                Month = g.Key,
                AvgProgress = g.Average(t => t.ProgressPercent)
            })
            .OrderBy(x => x.Month)
            .ToListAsync();

        ViewBag.MonthLabels = monthlyData
            .Select(x => "Tháng " + x.Month)
            .ToList();

        ViewBag.MonthData = monthlyData
            .Select(x => Math.Round(x.AvgProgress, 2))
            .ToList();

        // ===== THEO NHÂN VIÊN (Admin mới thấy đầy đủ) =====
        if (User.IsInRole("Admin"))
        {
            var employeeStats = await _context.TaskItems
                .Include(t => t.Employee)
                .Where(t => t.Employee != null)
                .GroupBy(t => t.Employee.FullName)
                .Select(g => new
                {
                    EmployeeName = g.Key,
                    TotalTasks = g.Count()
                })
                .ToListAsync();

            ViewBag.EmployeeNames = employeeStats.Select(x => x.EmployeeName).ToList();
            ViewBag.EmployeeTotals = employeeStats.Select(x => x.TotalTasks).ToList();
        }

        // ===== THEO PHÒNG BAN (Admin mới thấy đầy đủ) =====
        if (User.IsInRole("Admin"))
        {
            var departmentStats = await _context.TaskItems
                .Include(t => t.Employee)
                    .ThenInclude(e => e.Department)
                .Where(t => t.Employee != null && t.Employee.Department != null)
                .GroupBy(t => t.Employee.Department.Name)
                .Select(g => new
                {
                    DepartmentName = g.Key,
                    TotalTasks = g.Count()
                })
                .ToListAsync();

            ViewBag.DepartmentNames = departmentStats.Select(x => x.DepartmentName).ToList();
            ViewBag.DepartmentTotals = departmentStats.Select(x => x.TotalTasks).ToList();
        }

        return View();
    }
}
using QLHieuSuat.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using QLHieuSuat.Models;
using QLHieuSuat.Data;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddDefaultIdentity<ApplicationUser>(options =>
{
    options.SignIn.RequireConfirmedAccount = false;
})
.AddRoles<IdentityRole>()
.AddEntityFrameworkStores<ApplicationDbContext>();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();            // PHaI ĐaT TRuoC

app.UseAuthentication();     // SAU UseRouting
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapRazorPages();         //  BaT BUoC Co

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    //await SeedData.Initialize(services);
}


//using (var scope = app.Services.CreateScope())
//{
//    var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

//    // XÓA TỪ CON → CHA
//    context.TaskAssignments.RemoveRange(context.TaskAssignments);
//    context.TaskItems.RemoveRange(context.TaskItems);
//    context.Employees.RemoveRange(context.Employees);
//    context.Projects.RemoveRange(context.Projects);
//    context.Departments.RemoveRange(context.Departments);
//    context.SaveChanges();

//    // ====== DEPARTMENTS ======
//    var dep1 = new Department { Name = "IT", Description = "Phòng Công nghệ thông tin" };
//    var dep2 = new Department { Name = "Marketing", Description = "Phòng Marketing" };


//    context.Departments.AddRange(dep1, dep2);
//    context.SaveChanges();

//    // ====== KPI ======
//    var kpi1 = new KPI
//    {
//        Name = "Hoàn thành đúng hạn",
//        Description = "Đánh giá mức độ hoàn thành công việc đúng thời gian",
//        MaxScore = 10,
//        DepartmentId = dep1.Id
//    };

//    var kpi2 = new KPI
//    {
//        Name = "Chất lượng công việc",
//        Description = "Đánh giá chất lượng sản phẩm bàn giao",
//        MaxScore = 10,
//        DepartmentId = dep2.Id
//    };

//    context.KPIs.AddRange(kpi1, kpi2);
//    context.SaveChanges();

//    // ====== PROJECT ======
//    // ====== PROJECT ======
//    var project1 = new Project
//    {
//        Name = "Website Bán Hàng",
//        Description = "Phát triển hệ thống bán hàng online"
//    };

//    var project2 = new Project
//    {
//        Name = "Hệ thống KPI",
//        Description = "Quản lý hiệu suất nhân viên"
//    };

//    context.Projects.AddRange(project1, project2);
//    context.SaveChanges();

//    // ====== EMPLOYEE ======
//    var emp1 = new Employee
//    {
//        FullName = "Nguyễn Văn A",
//        YearsOfExperience = 3,
//        ProjectsParticipated = 5,
//        PersonalKPI = 8.5,
//        DepartmentId = dep1.Id
//    };

//    var emp2 = new Employee
//    {
//        FullName = "Trần Thị B",
//        YearsOfExperience = 5,
//        ProjectsParticipated = 8,
//        PersonalKPI = 9.0,
//        DepartmentId = dep2.Id
//    };

//    context.Employees.AddRange(emp1, emp2);
//    context.SaveChanges();

//    // ====== TASK ======
//    var task1 = new TaskItem
//    {
//        Name = "Thiết kế giao diện",
//        Difficulty = 3,
//        ProgressPercent = 70,
//        ProjectId = project1.Id
//    };

//    var task2 = new TaskItem
//    {
//        Name = "Xây dựng API",
//        Difficulty = 4,
//        ProgressPercent = 50,
//        ProjectId = project2.Id
//    };

//    context.TaskItems.AddRange(task1, task2);
//    context.SaveChanges();

//    // ====== ASSIGN ======
//    context.TaskAssignments.AddRange(
//        new TaskAssignment { TaskItemId = task1.Id, EmployeeId = emp1.Id },
//        new TaskAssignment { TaskItemId = task2.Id, EmployeeId = emp2.Id }
//    );

//    context.SaveChanges();
//}



using (var scope = app.Services.CreateScope())
{
    var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

    string[] roles = { "Admin", "Employee" };

    foreach (var role in roles)
    {
        if (!await roleManager.RoleExistsAsync(role))
        {
            await roleManager.CreateAsync(new IdentityRole(role));
        }
    }
}


app.Run();

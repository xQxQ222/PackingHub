using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// ��������� ��������� Razor Pages
builder.Services.AddRazorPages();

// ��������� ��������� MVC (����������� � �������������)
builder.Services.AddControllersWithViews();

// ��������� ����������� � ���� ������
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

// �������� ��������� ����������� ������, ����� ��� CSS, JS, �����������
app.UseStaticFiles();

// ���� ���������� � ����������, ���������� �������� ������
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

// ��������� ��������� ��� Razor Pages � MVC
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapRazorPages(); // ��� Razor Pages

app.Run();

using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Добавляем поддержку Razor Pages
builder.Services.AddRazorPages();

// Добавляем поддержку MVC (контроллеры и представления)
builder.Services.AddControllersWithViews();

// Настройка подключения к базе данных
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

// Включаем поддержку статических файлов, таких как CSS, JS, изображения
app.UseStaticFiles();

// Если приложение в разработке, показывать страницы ошибок
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

// Настройка маршрутов для Razor Pages и MVC
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapRazorPages(); // Для Razor Pages

app.Run();

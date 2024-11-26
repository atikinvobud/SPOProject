using Back.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<Context>(options => options.UseNpgsql(connectionString));

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

List<int> list = new List<int>();

app.MapGet("/test", (Context db) => 
{
    db.Users.Add(new User{Name = "nikita", Surname = "dubov"});
    db.SaveChanges();
    return db.Users.ToList();
});

app.MapGet("kaka", () => 
{
    Random random = new Random();
    for (int i = 0; i < 10; i++) list.Add(random.Next(1, 10));
    return Results.NoContent();
});

app.Run();
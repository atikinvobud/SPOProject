using Back.Models;
using Microsoft.EntityFrameworkCore;
using Back.Converters;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
   {
       options.AddPolicy("AllowAll", policy =>
       {
           policy.WithOrigins("http://localhost:5235")  // Адрес вашего фронтенда
                 .AllowAnyHeader()
                 .AllowAnyMethod();
       });
   });
builder.Services.AddControllersWithViews()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.PropertyNamingPolicy = null; // Не изменяет регистр
        options.JsonSerializerOptions.Converters.Add(new DateOnlyConverter());
        options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.Preserve;
    });

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<Context>(options => options.UseNpgsql(connectionString));

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}
app.UseCors("AllowAll");
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllers();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

List<int> list = new List<int>();

app.MapGet("kaka", () => 
{
    Random random = new Random();
    for (int i = 0; i < 10; i++) list.Add(random.Next(1, 10));
    return Results.NoContent();
});

app.Run();
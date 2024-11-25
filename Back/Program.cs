var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

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

app.MapGet("kaka", () => 
{
    Random random = new Random();
    for (int i = 0; i < 10; i++) list.Add(random.Next(1, 10));
    return Results.NoContent();
});

app.Run();
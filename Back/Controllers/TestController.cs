using Back.Models;
using Microsoft.AspNetCore.Mvc;
namespace Back.Controllers;

[Controller]
public class TestController : Controller
{    
    private readonly Context context;

    public TestController(Context context)
    {
        this.context = context;
    }   
    
    [HttpGet]
    public IActionResult TestMethod()
    {
        var sport = new Sport
            {
                Name = "Football",
                Description = "A popular team sport played worldwide.",
                Tournaments = new List<Tournament>() // Если потребуется добавить связанные данные
            };

        context.Sports.Add(sport);
        context.SaveChanges();
        return Ok(context.Sports.ToList());
    }
    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }
}
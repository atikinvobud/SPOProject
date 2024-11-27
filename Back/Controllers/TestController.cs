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
        context.SaveChanges();
        return Ok(context.Users.ToList());
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
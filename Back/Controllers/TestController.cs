using Microsoft.AspNetCore.Mvc;

namespace Back.Controllers;

public class TestController : Controller
{
    [HttpGet]
    public IActionResult TestMethod()
    {
        return NoContent();
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
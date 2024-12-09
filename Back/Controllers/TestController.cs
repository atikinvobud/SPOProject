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
        context.Notifications.Add(new Notification{Text = "Текст", DateOfSending = DateOnly.MinValue});
        context.SaveChanges();
        return Ok();
    }

    [HttpPost]
    public IActionResult DoThings()
    {
        return Ok();
    }

    [HttpPost]
    public IActionResult DoThings1()
    {
        context.NotACities.Add(new City
        {
            Name = "Москва"
        });
        context.SaveChanges();
        return Ok(context.NotACities.ToList());
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
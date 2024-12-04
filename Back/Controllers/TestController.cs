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
        return Ok(context.UserInfos.ToList());
    }

    [HttpGet]
    public IActionResult DoThings()
    {
        context.SaveChanges();
        //return Ok(context.NotACities.ToList());
        return Ok(context.UserInfos.ToList());
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
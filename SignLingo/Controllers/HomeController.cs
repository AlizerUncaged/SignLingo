using System.Diagnostics;
using ForceDown;
using Microsoft.AspNetCore.Mvc;
using SignLingo.Models;

namespace SignLingo.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly DatabaseAbstract _databaseAbstract;

    public HomeController(ILogger<HomeController> logger, DatabaseAbstract databaseAbstract)
    {
        _logger = logger;
        _databaseAbstract = databaseAbstract;
    }

    [HttpGet("/model/model.json")]
    public async Task<IActionResult> ModelJson()
    {
        var dbPort = await _databaseAbstract.GetDatabasePortAsync();
        var file = await System.IO.File.ReadAllTextAsync("./wwwroot/model.json");
        file = file.Replace("[DbAbstract]", $"{(dbPort - 8080) + 32}");
        return Content(file);
    }

    public async Task<IActionResult> Index()
    {
        return View(await _databaseAbstract.GetDatabasePortAsync());
    }

    public async Task<IActionResult> Signs()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
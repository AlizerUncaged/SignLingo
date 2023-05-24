using ForceDown;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SignLingo.Data;
using SignLingo.Models;
using Activity = System.Diagnostics.Activity;

namespace SignLingo.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly DatabaseAbstract _databaseAbstract;
    private readonly ApplicationDbContext _dbContext;
    private readonly UserManager<IdentityUser> _userManager;

    public HomeController(ILogger<HomeController> logger, DatabaseAbstract databaseAbstract,
        ApplicationDbContext dbContext, UserManager<IdentityUser> userManager)
    {
        _logger = logger;
        _databaseAbstract = databaseAbstract;
        _dbContext = dbContext;
        _userManager = userManager;
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

    [HttpGet("/lessons/{lessonId}")]
    [HttpGet("/lessons/{lessonId}/{activityId}")]
    public async Task<IActionResult> Lesson(long lessonId, long? activityId)
    {
        ViewData["LessonId"] = lessonId;
        ViewData["IsWelcomePage"] = activityId is null;

        var lesson = await _dbContext.Lessons
            .Include(x => x.ActivitySequence)
            .Include(x => x.Items)
            .FirstOrDefaultAsync(x => x.Id == lessonId);

        return View(lesson.ActivitySequence.FirstOrDefault(x => x.Id == activityId) ??
                    lesson.ActivitySequence.FirstOrDefault());
    }

    public async Task<IActionResult> Signs()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [HttpGet("/lessons/finished/{lessonId}")]
    public async Task<IActionResult> FinishedLesson(long lessonId)
    {
        var currentUser = await _userManager.GetUserAsync(User);

        if (currentUser is null)
            return Content("User doesn't exist!");

        var userMetadata = await _dbContext.UserMetadatas.FirstOrDefaultAsync(x => x.User.Id == currentUser.Id);
        if (userMetadata is null)
        {
            var userMetadataAddResult = await _dbContext.UserMetadatas.AddAsync(new UserMetadata()
            {
                User = currentUser
            });

            userMetadata = userMetadataAddResult.Entity;
        }

        var lesson = await _dbContext.Lessons.FirstOrDefaultAsync(x => x.Id == lessonId);
        if (lesson is null)
            return Content("Lesson doesn't exist!");
        
        userMetadata.FinishedLessons.Add(lesson);

        _dbContext.UserMetadatas.Update(userMetadata);

        await _dbContext.SaveChangesAsync();

        return View(lesson);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
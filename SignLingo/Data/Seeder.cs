using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace SignLingo.Data;

public class Seeder
{
    private readonly ApplicationDbContext _dbContext;
    private readonly UserManager<IdentityUser> _userManager;

    public Seeder(ApplicationDbContext dbContext, UserManager<IdentityUser> userManager)
    {
        _dbContext = dbContext;
        _userManager = userManager;
    }

    private IEnumerable<LearnItems> StringToLearnItems(params string[] items)
    {
        return items.Select(x => new LearnItems() { Item = x });
    }


    public IEnumerable<Activity> GenerateActivity()
    {
        return new List<Activity>()
        {
            new Activity()
            {
                ActivityType = ActivityType.SpellWord
            },
            new Activity()
            {
                ActivityType = ActivityType.SpellWord
            },
            new Activity()
            {
                ActivityType = ActivityType.SpellWord
            },
            new Activity()
            {
                ActivityType = ActivityType.SpellWord
            },
            new Activity()
            {
                ActivityType = ActivityType.SpellWord
            },
            new Activity()
            {
                ActivityType = ActivityType.SpellWord
            },
            new Activity()
            {
                ActivityType = ActivityType.SpellWord
            },
            new Activity()
            {
                ActivityType = ActivityType.SpellWord
            },
            new Activity()
            {
                ActivityType = ActivityType.SpellWord
            },
        };
    }

    public async Task SeedAsync()
    {
        // Seed only if lessons are empty.
        if (await _dbContext.Lessons.CountAsync() > 0)
        {
            return;
        }

        var createUserResult = await _userManager.CreateAsync(new IdentityUser()
        {
            Email = "saylent1@gmail.com", UserName = "saylent"
        }, "Qwerty123");


        await _dbContext.Lessons.AddAsync(new Lesson()
        {
            LessonImage =
                "https://cdn.dribbble.com/userupload/5212512/file/original-8f810bbb60971a8d674ceb8b0150ccbc.jpg?compress=1&resize=1024x1280",
            LessonTitle = "Greetings!",
            Items = StringToLearnItems("Kamusta", "Paalam", "Salamat", "Magandang Umaga", "Magandang Gabi").ToList(),
            ActivitySequence = GenerateActivity().ToList()
        });

        await _dbContext.Lessons.AddAsync(new Lesson()
        {
            LessonImage =
                "https://cdn.dribbble.com/users/648922/screenshots/15895262/media/dcd459092738c1ce081fa6948bdf0ff1.png",
            LessonTitle = "Time",
            Items = StringToLearnItems("Umaga", "Hapon", "Gabi", "Ngayon", "Bukas", "Kahapon").ToList(),
            ActivitySequence = GenerateActivity().ToList()
        });

        await _dbContext.Lessons.AddAsync(new Lesson()
        {
            LessonImage =
                "https://cdn.dribbble.com/users/648922/screenshots/6413054/cave_4x.png?compress=1&resize=1000x750&vertical=top",
            LessonTitle = "Family #1",
            Items = StringToLearnItems("Ina", "Ama", "Anak", "Kapatid").ToList(),
            ActivitySequence = GenerateActivity().ToList()
        });

        await _dbContext.Lessons.AddAsync(new Lesson()
        {
            LessonImage =
                "https://cdn.dribbble.com/users/648922/screenshots/8948260/media/961dcc2988e2220d100ac1018e66b277.png",
            LessonTitle = "Colors #1",
            Items = StringToLearnItems("Pula", "Dilaw", "Asul", "Kahel").ToList(),
            ActivitySequence = GenerateActivity().ToList()
        });

        await _dbContext.Lessons.AddAsync(new Lesson()
        {
            LessonImage =
                "https://cdn.dribbble.com/users/648922/screenshots/15342382/media/65caee64550ce68c8c5c1cb3265dd98a.png",
            LessonTitle = "Colors #2",
            Items = StringToLearnItems("Berde", "Lila", "Itim", "Puti").ToList(),
            ActivitySequence = GenerateActivity().ToList()
        });

        await _dbContext.Lessons.AddAsync(new Lesson()
        {
            LessonImage =
                "https://cdn.dribbble.com/users/648922/screenshots/5932664/media/6c21a412f3804c7cf6bbf6c1aa13777b.png?compress=1&resize=1000x750&vertical=top",
            LessonTitle = "Family #2",
            Items = StringToLearnItems("Lola", "Lolo", "Ate", "Kuya").ToList(),
            ActivitySequence = GenerateActivity().ToList()
        });

        await _dbContext.SaveChangesAsync();

        // new Lesson()
        // {
        //     Id = 2,
        //     LessonImage =
        //         "https://cdn.dribbble.com/users/648922/screenshots/15895262/media/dcd459092738c1ce081fa6948bdf0ff1.png",
        //     LessonTitle = "Time"
        // }
    }
}
using Microsoft.EntityFrameworkCore;

namespace SignLingo.Data;

public class Seeder
{
    private readonly ApplicationDbContext _dbContext;

    public Seeder(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task SeedAsync()
    {
        // Seed only if lessons are empty.
        if (await _dbContext.Lessons.CountAsync() > 0)
        {
            return;
        }

        await _dbContext.Lessons.AddAsync(new Lesson()
        {
            LessonImage =
                "https://cdn.dribbble.com/userupload/5212512/file/original-8f810bbb60971a8d674ceb8b0150ccbc.jpg?compress=1&resize=1024x1280",
            LessonTitle = "Greetings!",
            Items = new()
            {
                new LearnItems()
                {
                    Item = "Kamusta"
                },
                new LearnItems()
                {
                    Item = "Paalam"
                },
                new LearnItems()
                {
                    Item = "Salamat"
                },
                new LearnItems()
                {
                    Item = "Oo"
                },
                new LearnItems()
                {
                    Item = "Hindi"
                },
                new LearnItems()
                {
                    Item = "Mabuti"
                },
                new LearnItems()
                {
                    Item = "Pasensya"
                }
            },
            ActivitySequence = new()
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
                new Activity()
                {
                    ActivityType = ActivityType.SpellWord
                },
            }
        });

        await _dbContext.Lessons.AddAsync(new Lesson()
        {
            LessonImage =
                "https://cdn.dribbble.com/users/648922/screenshots/15895262/media/dcd459092738c1ce081fa6948bdf0ff1.png",
            LessonTitle = "Time",
            Items = new()
            {
                new LearnItems()
                {
                    Item = "Umaga"
                },
                new LearnItems()
                {
                    Item = "Hapon"
                },
                new LearnItems()
                {
                    Item = "Gabi"
                },
                new LearnItems()
                {
                    Item = "Ngayon"
                },
                new LearnItems()
                {
                    Item = "Bukas"
                },
                new LearnItems()
                {
                    Item = "Kahapon"
                },
            },
            ActivitySequence = new()
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
                new Activity()
                {
                    ActivityType = ActivityType.SpellWord
                },
                new Activity()
                {
                    ActivityType = ActivityType.SpellWord
                },
            }
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
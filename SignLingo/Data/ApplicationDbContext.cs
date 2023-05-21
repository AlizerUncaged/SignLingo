using ForceDown;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace SignLingo.Data;

public class ApplicationDbContext : IdentityDbContext
{
    private readonly DatabaseAbstract _databaseAbstract;

    public DbSet<Activity> Activities { get; set; }

    public DbSet<Lesson> Lessons { get; set; }

    public DbSet<UserMetadata> UserMetadatas { get; set; }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, DatabaseAbstract databaseAbstract)
        : base(options)
    {
        _databaseAbstract = databaseAbstract;
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<Lesson>().HasData(new Lesson[]
        {
            new Lesson()
            {
                Id = 1,
                LessonImage =
                    "https://cdn.dribbble.com/userupload/5212512/file/original-8f810bbb60971a8d674ceb8b0150ccbc.jpg?compress=1&resize=1024x1280",
                LessonTitle = "Greetings!",
//                 LessonDescription = @"
// ### Lesson 1: FSL Greetings
//
// Get ready to dive into the exciting world of **Filipino Sign Language (FSL)** greetings! 🌟✋ In this cozy lesson, you'll learn how to sign some 
// delightful greetings that will make your heart flutter. Whether you're saying hello, bidding farewell, or asking someone how they're doing, 
// FSL has the perfect signs to express warmth and friendliness. 🤗💬
// ".Trim(),
            },
            new Lesson()
            {
                Id = 2,
                LessonImage =
                    "https://cdn.dribbble.com/users/648922/screenshots/15895262/media/dcd459092738c1ce081fa6948bdf0ff1.png",
                LessonTitle = "FSL Numbers",
                LessonDescription = @"".Trim(),
            }
        });


        base.OnModelCreating(builder);
    }
}
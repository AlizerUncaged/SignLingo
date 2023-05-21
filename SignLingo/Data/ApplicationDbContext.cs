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
                LessonTitle = "Greetings!",
                LessonDescription = @"
# Lesson 1: FSL Greetings

Get ready to dive into the exciting world of Filipino Sign Language (FSL) greetings! 🌟✋ In this cozy lesson, you'll learn how to sign some 
delightful greetings that will make your heart flutter. Whether you're saying hello, bidding farewell, or asking someone how they're doing, 
FSL has the perfect signs to express warmth and friendliness. 🤗💬
".Trim(),
            }
        });


        base.OnModelCreating(builder);
    }
}
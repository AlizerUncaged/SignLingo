using ForceDown;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace SignLingo.Data;

public class ApplicationDbContext : IdentityDbContext
{
    private readonly DatabaseAbstract _databaseAbstract;

    public DbSet<Activity> Activities { get; set; }

    public DbSet<Lesson> Lessons { get; set; }
    public DbSet<UserFinished> FinishedItems { get; set; }


    public DbSet<LearnItems> Items { get; set; }

    public DbSet<UserMetadata> UserMetadatas { get; set; }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, DatabaseAbstract databaseAbstract)
        : base(options)
    {
        _databaseAbstract = databaseAbstract;
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        // builder.Entity<Lesson>().HasData(new Lesson[]
        // {
        //    
        // });


        base.OnModelCreating(builder);
    }
}
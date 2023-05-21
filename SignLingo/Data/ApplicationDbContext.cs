using ForceDown;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace SignLingo.Data;

public class ApplicationDbContext : IdentityDbContext
{
    private readonly DatabaseAbstract _databaseAbstract;

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, DatabaseAbstract databaseAbstract)
        : base(options)
    {
        _databaseAbstract = databaseAbstract;
    }
}
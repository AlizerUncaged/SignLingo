using Microsoft.AspNetCore.Identity;

namespace SignLingo.Models;

public class UserStats
{
    public IdentityUser User { get; set; }

    public double Score { get; set; }
}
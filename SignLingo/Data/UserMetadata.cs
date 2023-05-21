using Microsoft.AspNetCore.Identity;

namespace SignLingo.Data;

public class UserMetadata
{
    public long Id { get; set; }
    public IdentityUser User { get; set; }

    public List<Lesson> FinishedLessons { get; set; } = new();
}
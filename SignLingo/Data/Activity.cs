namespace SignLingo.Data;

public class Activity
{
    public long Id { get; set; }

    public Lesson ParentLesson { get; set; }

    /// <summary>
    /// Markdown of activity description.
    /// </summary>
    public string ActivityDescription { get; set; }

    public string Word { get; set; }

    public ActivityType ActivityType { get; set; }
}
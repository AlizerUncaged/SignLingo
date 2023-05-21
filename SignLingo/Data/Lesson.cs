namespace SignLingo.Data;

public class Lesson
{
    public long Id { get; set; }

    public string LessonTitle { get; set; }

    /// <summary>
    /// Markdown of lesson description.
    /// </summary>
    public string LessonDescription { get; set; } = string.Empty;

    /// <summary>
    /// Markdown of lesson reviewer.
    /// </summary>
    public string LessonReviewer { get; set; } = string.Empty;
    
    

    public List<Activity> Activities { get; set; } = new();
}
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


    public List<LearnItems> Items { get; set; } = new();

    public string LessonImage { get; set; } = string.Empty;


    public List<Activity> ActivitySequence { get; set; } = new();
    
}
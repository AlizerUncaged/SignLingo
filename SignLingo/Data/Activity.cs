namespace SignLingo.Data;

public class Activity
{
    private static Random _random = new Random();
    private string? _word;
    public long Id { get; set; }

    public Lesson ParentLesson { get; set; }

    /// <summary>
    /// Markdown of activity description.
    /// </summary>
    public string? ActivityDescription { get; set; }

    public string? Word
    {
        get
        {
            if (string.IsNullOrWhiteSpace(_word))
                return ParentLesson.Items[_random.Next(ParentLesson.Items.Count())].Item
                    ;
            return _word;
        }
        set => _word = value;
    }

    public ActivityType ActivityType { get; set; }
}
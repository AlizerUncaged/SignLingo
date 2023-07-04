namespace SignLingo.Data;

public class UserFinished
{
    public long Id { get; set; }

    public Lesson ParentLesson { get; set; }

    public double RemainingTime { get; set; }

    public long Score { get; set; }
}
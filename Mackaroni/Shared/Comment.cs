namespace Mackaroni.Shared;

public class Comment
{
    public string Text { get; set; }
    public string Author { get; set; }
    public DateTimeOffset PostedTime { get; set; }
}
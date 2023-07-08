using Mackaroni.Shared;

namespace Mackaroni.Server.Impl;

public class CommentProvider
{
    private Dictionary<string, List<Comment>> _storedComments = new();

    public List<Comment> GetCommentsForPage(string id)
    {
        if (!_storedComments.ContainsKey(id))
        {
            _storedComments[id] = new();
            _storedComments[id].Add(new()
            {
                Text = "Very cool comment for the page " + id,
                Author = "Server",
                PostedTime = DateTimeOffset.UtcNow
            });
        }
        return _storedComments[id];
    }
    
}
namespace Mackaroni.Shared;

public interface ICommentThreadProvider
{
    public Task<List<Comment>> GetCommentsForPage(string page);
}
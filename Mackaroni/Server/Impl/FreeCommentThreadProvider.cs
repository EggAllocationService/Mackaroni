using Mackaroni.Shared;

namespace Mackaroni.Server.Impl;

public class FreeCommentThreadProvider : ICommentThreadProvider
{
    private CommentProvider _p;
    public FreeCommentThreadProvider(CommentProvider p)
    {
        _p = p;
    }

    public Task<List<Comment>> GetCommentsForPage(string page)
    {
        return Task.FromResult(_p.GetCommentsForPage(page).OrderByDescending(p => p.PostedTime).ToList());
    }
}
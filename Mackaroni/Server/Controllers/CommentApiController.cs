using Mackaroni.Server.Hubs;
using Mackaroni.Server.Impl;
using Mackaroni.Shared;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace Mackaroni.Server.Controllers;

[ApiController]
[Route("/api/comments")]
public class CommentApiController : Controller
{
    private CommentProvider _comments;
    private IHubContext<CommentNotificationHub> _commentHub;
    public CommentApiController(CommentProvider comments, IHubContext<CommentNotificationHub> hubContext)
    {
        _comments = comments;
        _commentHub = hubContext;
    }
    // GET
    [Route("{page}")]
    public List<Comment> GetComments([FromRoute] string page)
    {
        return _comments.GetCommentsForPage(page);
    }

    [HttpPost]
    [Route("{page}")]
    public async Task<ActionResult> CreateNewComment([FromRoute] string page, [FromBody] CreateCommentRequest req)
    {
        var c = new Comment()
        {
            Author = req.Author,
            Text = req.Text,
            PostedTime = DateTimeOffset.UtcNow
        };
        var thread = _comments.GetCommentsForPage(page);
        thread.Add(c);
        await _commentHub.Clients.Group(page).SendAsync("CommentAdded", c);
        return Ok();
    }
}
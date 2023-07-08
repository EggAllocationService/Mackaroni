using Mackaroni.Shared;
using Microsoft.AspNetCore.SignalR;

namespace Mackaroni.Server.Hubs;

public class CommentNotificationHub : Hub<ICommentSectionClient>
{

    public async void AddToGroup(string page)
    {
        await Groups.AddToGroupAsync(Context.ConnectionId, page);
    }
}

public interface ICommentSectionClient
{
    public void CommentAdded(Comment c);
}
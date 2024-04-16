using System.Threading.Tasks;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;

namespace SignalRServerDotNetFramework.Hub
{
    [HubName("NotificationHub")]
    public class NotificationHub : Microsoft.AspNet.SignalR.Hub
    {
        private static IHubContext hubContext = GlobalHost.ConnectionManager.GetHubContext<NotificationHub>();

        public static async Task SendAsync(string hspTpCd, string stfNo, string message) =>
            await hubContext.Clients.All.SendAsync(hspTpCd, stfNo, message);


        // public void Send() => hubContext.Clients.All.addNewMessageToPage(hspTpCd, stfNo, message);
    }
}
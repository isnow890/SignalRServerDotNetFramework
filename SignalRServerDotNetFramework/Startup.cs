using System.Collections.Generic;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using Microsoft.Owin;
using Owin;
using SignalRServerDotNetFramework;
using SignalRServerDotNetFramework.Hub;

[assembly: OwinStartup(typeof(Startup))]

namespace SignalRServerDotNetFramework
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll);
            app.MapSignalR("/signalr", new HubConfiguration());
        }
    }
}
using System;
using System.Threading.Tasks;
using Quartz;
using SignalRServerDotNetFramework.Hub;

namespace SignalRServerDotNetFramework.Scheduler.Tasks
{
    public class SendIpsumMessageJob : IJob
    {
        public async Task Execute(IJobExecutionContext context)
        {
            Console.WriteLine($"SendIpsumMessageJob 실행 {DateTime.Now:yyyy/MM/dd hh:mm:ss}");
            await NotificationHub.SendAsync("01", "30430",
                "Lorem Ipsum is simply dummy text of the printing and typesetting industry. ");
        }
    }
}
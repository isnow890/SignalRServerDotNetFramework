using System;
using System.Threading.Tasks;
using Quartz;
using SignalRServerDotNetFramework.Hub;

namespace SignalRServerDotNetFramework.Scheduler.Tasks
{
    public class SendDummyMessageJob : IJob
    {
        public async Task Execute(IJobExecutionContext context)
        {
            Console.WriteLine($"SendDummyMessageJob 실행 {DateTime.Now:yyyy/MM/dd hh:mm:ss}");

            await NotificationHub.SendAsync("01", "30430",
                $"SendDummyMessageJob 지금 시간은 {DateTime.Now:yyyy/MM/dd hh:mm:ss}");
        }
    }
}
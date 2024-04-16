using System.Threading.Tasks;
using Quartz;
using Quartz.Impl;
using SignalRServerDotNetFramework.Scheduler.Tasks;

namespace SignalRServerDotNetFramework.Scheduler
{
    public class SchedulerMain
    {
        public static async void Start()
        {
            var factory = new StdSchedulerFactory();

            // get a scheduler
            var scheduler = await factory.GetScheduler();
            await scheduler.Start();

            //이건 1초
            var job = JobBuilder.Create<SendDummyMessageJob>()
                .WithIdentity("job1", "group1")
                .Build();
            var trigger = TriggerBuilder.Create()
                .WithIdentity("trigger1", "group1")
                .StartNow()
                .WithCronSchedule("* * * * * ?").Build();


            //이건 5초
            var job2 = JobBuilder.Create<SendIpsumMessageJob>()
                .WithIdentity("job2", "group1")
                .Build();
            var trigger2 = TriggerBuilder.Create()
                .WithIdentity("trigger2", "group1")
                .StartNow()
                .WithCronSchedule("0/5 * * * * ?")
                .Build();


            await scheduler.ScheduleJob(job, trigger);
            await scheduler.ScheduleJob(job2, trigger2);
        }
    }
}
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

using System.Threading.Tasks;

using Up4All.Tasker.Framework.Contracts;
using Up4All.Tasker.Framework.Entities;

namespace Up4All.Tasker.Framework.Tasks
{
    public abstract class CrawlerTaskBase : ICrawlerTask
    {
        protected readonly ITaskService TaskService;
        protected readonly ILogger<CrawlerTaskBase> LogService;
        protected readonly IConfiguration Configuration;


        public abstract int TaskId { get; }

        public abstract string TaskName { get; }

        protected CrawlerTaskBase(

            ITaskService taskService,
            ILogger<CrawlerTaskBase> logService,
            IConfiguration configuration)
        {
            TaskService = taskService;
            LogService = logService;
            Configuration = configuration;
        }

        public abstract Task RunAsync(Context context);

        public Task SaveTask(Context context)
        {
            TaskService.SaveAsync(context);
            return Task.CompletedTask;
        }
    }
}
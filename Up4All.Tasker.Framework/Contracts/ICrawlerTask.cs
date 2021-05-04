using System.Threading.Tasks;

using Up4All.Tasker.Framework.Entities;

namespace Up4All.Tasker.Framework.Contracts
{
    public interface ICrawlerTask
    {
        int TaskId { get; }

        string TaskName { get; }
        
        Task RunAsync(Context context);

        Task SaveTask(Context context);
    }
}

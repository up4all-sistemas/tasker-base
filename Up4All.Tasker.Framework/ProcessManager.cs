using System.Threading;

namespace Up4All.Tasker.Framework
{
    public class ProcessManager
    {
        public static readonly AutoResetEvent Closing = new AutoResetEvent(false);
    }
}

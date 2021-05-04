using System.Threading.Tasks;

using Up4All.WebCrawler.Domain.Models;

namespace Up4All.Tasker.Framework.Contracts
{
    public interface IProcess     
    {        
        void Start();
        void End();
        void Process(Metadata metadata);
    }
}

using System.Drawing;
using System.IO;
using System.Threading.Tasks;

using Up4All.Tasker.Framework.Entities;

namespace Up4All.Tasker.Framework.Contracts
{
    public interface ITaskService
    {   
        string CleanAccents(string text);

        Stream GeneratePdf(Image img);

        bool CompareName(string sourceName, string contextName);

        Task SaveAsync(Context context);
    }
}

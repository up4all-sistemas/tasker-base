using System;
using System.Collections.Generic;
using System.Text;

namespace Up4All.Tasker.Framework.Options
{
    public class CrawlerOptions
    {
        public string BotName { get; set; }

        public int? JobTask { get; set; }

        public int? Retries { get; set; }

        public int? TaskTimeout { get; set; }

        public CrawlerOptions()
        {
            
        }
    }
}

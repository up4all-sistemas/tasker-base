namespace Up4All.Tasker.Framework.Handlers.Exception
{
    public class WebCrawlerException<T> : System.Exception
    {
        public WebCrawlerException(System.Exception exception) : base("WebCrawlerException", exception)
        {

        }
    }
}
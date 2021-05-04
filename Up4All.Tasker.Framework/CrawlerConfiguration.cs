using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

using System.Net.Http;

using Up4All.Framework.MessageBus.Abstractions.Configurations;
using Up4All.Framework.MessageBus.RabbitMQ;
using Up4All.Tasker.Framework.ApiClients;
using Up4All.Tasker.Framework.ApiClients.Mocks;
using Up4All.Tasker.Framework.Contracts;
using Up4All.Tasker.Framework.Entities;
using Up4All.Tasker.Framework.Options;
using Up4All.Tasker.Framework.Tasks;

namespace Up4All.Tasker.Framework
{
    public static class CrawlerConfiguration
    {
        public static IServiceCollection AddCrawlerServiceBase(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddLogging((builder) => builder.SetMinimumLevel(LogLevel.Trace));
            services.AddSingleton<Context>();            
            services.AddSingleton(typeof(ILogger<>), typeof(Logger<>));
            services.AddSingleton<HttpClient>();
            services.AddSingleton(configuration);
            services.AddSingleton<IProcess, EngineBase>();
            services.Configure<CrawlerOptions>(o => configuration.GetSection(nameof(CrawlerOptions)).Bind(o));
            return services;
        }

        public static IServiceCollection AddTask<T>(this IServiceCollection services) where T : CrawlerTaskBase
        {
            services.AddSingleton<ICrawlerTask, T>();
            return services;
        }

        public static IServiceCollection AddCrawlerServicesDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddMessageBusTopicClient<RabbitMQTopicClient>(configuration);
            services.AddMessageBusSubscribeClient<RabbitMQSubscribeClient>(configuration);
            services.AddSingleton<ITaskService, TaskService>();
            return services;
        }

        public static IServiceCollection AddCrawlerServicesDependenciesAsMock(this IServiceCollection services)
        {
            services.AddMessageBusTopicClientMocked<RabbitMQTopicClientMocked>();
            services.AddMessageBusSubscribeClientMocked<RabbitMQSubscribeClientMocked>();
            services.AddSingleton<ITaskService, TaskServiceMock>();
            return services;
        }
    }
}

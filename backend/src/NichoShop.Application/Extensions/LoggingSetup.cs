using Elastic.Ingest.Elasticsearch.DataStreams;
using Elastic.Serilog.Sinks;
using Elastic.Transport;
using Serilog;

namespace NichoShop.Application.Extensions
{
    public static class LoggingSetup
    {
        public static void ConfigureLogging(IHostEnvironment environment)
        {
            string environmentName = environment.EnvironmentName.ToLower();

            Log.Logger = new LoggerConfiguration()
                 .MinimumLevel.Debug()
                .WriteTo.Console()
                .WriteTo.Elasticsearch(new[] { new Uri("http://localhost:9200") }, opts =>
                {
                    opts.DataStream = new DataStreamName("logs", "hivespace", environmentName);
                }, transport =>
                {
                    transport.Authentication(new BasicAuthentication("elastic", "t79fl+2c97qba-tufpol"));
                })
                .CreateLogger();
        }
    }
}

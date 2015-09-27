using System;
using System.Configuration;
using CodeCop.Core;
using CodeCop.Core.Contracts;
using Serilog.Sinks.Elasticsearch;


namespace Serilog.Elastic.CodeCop
{
    public class OnErrorInterceptor : ICopIntercept, ICopErrorHandle
    {
        public OnErrorInterceptor()
        {
            var uri = ConfigurationManager.AppSettings["ElasticNode"];
            
            if(!string.IsNullOrEmpty(uri))
            {
                var options = new ElasticsearchSinkOptions(new Uri(uri));
                Log.Logger = new LoggerConfiguration().WriteTo.Elasticsearch(options).CreateLogger();
            }

           
        }

        /// <summary>
        /// Runs before the method execution
        /// </summary>
        /// <param name="context"/>
        public void OnBeforeExecute(InterceptionContext context)
        {
        }

        /// <summary>
        /// Runs after the method execution
        /// </summary>
        /// <param name="context"/>
        public void OnAfterExecute(InterceptionContext context)
        {
            
        }


        public void OnError(InterceptionContext context)
        {
            if(Log.Logger != null && context.Exception != null)
            {
                Log.Logger.Error(context.Exception, string.Format("There was an error method {0} from {1} type", context.InterceptedMethod.Name, context.InterceptedMethod.DeclaringType.FullName));
            }
        }
    }
}

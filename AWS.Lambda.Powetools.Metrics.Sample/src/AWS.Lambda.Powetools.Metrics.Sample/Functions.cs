using Amazon.Lambda.Annotations;
using Amazon.Lambda.Annotations.APIGateway;
using Amazon.Lambda.Core;
using AWS.Lambda.Powertools.Metrics;
using AWS.Lambda.Powertools.Logging;
using Amazon;


[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.SystemTextJson.DefaultLambdaJsonSerializer))]

namespace MyMetrics.Sample
{
    /// <summary>
    /// A collection of sample Lambda functions that provide a REST api for doing simple math calculations. 
    /// </summary>
    public class Functions
    {
        public class ApiResponse
        {
            public string? Message { get; set; }
            public int HttpResponseCode { get; set; }
        }
            
        /// <summary>
        /// Default constructor.
        /// </summary>
        public Functions()
        {
        }

        /// <summary>
        /// Post an EMF metric to CloudWatch.
        /// </summary>
        /// <param name="metricValue">The value to store in CloudWatch</param>
        /// <param name="context">Lambda context object</param>
        /// <returns></returns>
        [Metrics(CaptureColdStart = true, Service = "PostEmbeddedMetricApi", Namespace = "MyMetrics")]
        [LambdaFunction(Timeout = 3, MemorySize = 256)]
        [HttpApi(LambdaHttpMethod.Post, "/metrics/embedded/{environment}/{metricValue}")]
        public ApiResponse PostEmbeddedMetric(string environment, int metricValue, ILambdaContext context)
        {
            context.Logger.LogInformation($"Invocation");
            Metrics.PushSingleMetric(
                metricName: "MyEmbeddedMetric",
                value: metricValue,
                service: "PostEmbeddedMetricApi",
                nameSpace: "MyMetrics",
                unit: MetricUnit.,
                defaultDimensions: new Dictionary<string, string>
                {
                    { "Environment", environment }
                });

                         
            return new ApiResponse
            {
                Message = $"Embedded metric value captured: {metricValue}",
                HttpResponseCode = 200
            };
        }
    }
}
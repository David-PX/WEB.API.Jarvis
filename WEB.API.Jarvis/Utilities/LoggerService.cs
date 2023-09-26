using Serilog;
using Serilog.Formatting.Json;

namespace WEB.API.Jarvis.Utilities
{
    public static class LoggerService
    {
        public static void Info(string message)
        {
            DateTime executionTime = DateTime.Now;
            //"BOTService.Customer | GetCustomer Start Request" +
            //                      "| Requester: {0}" +
            //                      "| ExternalCredentialType: {1}" +
            //                      "| ExternalCredential: {2}" +
            //                      "| Execution Time: {3}",



            // Instantiate the logger
            var log = new LoggerConfiguration()  // using Serilog;

                // using Serilog.Formatting.Json;
                .WriteTo.File(new JsonFormatter(renderMessage: true), "C:/Logs/log.json")

                // using Serilog.Formatting.Compact;
                // .WriteTo.File(new RenderedCompactJsonFormatter(), "log.json")

                .CreateLogger();

            // An example
           
            
            log.Information($"{message} | Execution Time: {DateTime.Now.Subtract(executionTime).TotalSeconds:N2} | "  );
        }
    }
}

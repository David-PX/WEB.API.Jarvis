using Serilog;
using Serilog.Formatting.Json;

namespace WEB.API.Jarvis.Utilities
{
    public static class LoggerService
    {
        
        public static void LogActionStart(string action, HttpRequest request)
        {
            var log = new LoggerConfiguration()
                            .WriteTo.File(new JsonFormatter(renderMessage: true), "C:/Logs/jarvislogs/log.json")
                            .CreateLogger();
            DateTime startTime = DateTime.Now;

            log.Information(
                "Action: {Action} | Requester: {Requester} | CredentialType: {CredentialType} | Start Time: {StartTime}",
                action,
                request.Headers["Requester-Jarvis"].ToString(),
                request.Headers["Role-Requester-Jarvis"].ToString(),
                startTime
            );
        }

        public static void LogActionEnd(string action, DateTime startTime)
        {
            var log = new LoggerConfiguration()
                            .WriteTo.File(new JsonFormatter(renderMessage: true), "C:/Logs/jarvislogs/log.json")
                            .CreateLogger();

            DateTime endTime = DateTime.Now;

            log.Information(
                "Action: {Action} | Execution Time: {ExecutionTime} seconds",
                action,
                endTime.Subtract(startTime).TotalSeconds.ToString("N2")
            );
        }

        public static void LogException(string action, HttpRequest request, string exception, DateTime startTime)
        {
            var log = new LoggerConfiguration()
                            .WriteTo.File(new JsonFormatter(renderMessage: true), "C:/Logs/jarvislogs/log.json")
                            .CreateLogger();
            DateTime endTime = DateTime.Now;

            log.Error(
                "Action: {Action} | Requester: {Requester} | CredentialType: {CredentialType} | Exception: {Exception} |  Execution Time: {ExecutionTime} seconds",
                action,
                request.Headers["Requester-Jarvis"].ToString(),
                request.Headers["Role-Requester-Jarvis"].ToString(),
                exception,
                endTime.Subtract(startTime).TotalSeconds.ToString("N2")
            );

        }
    }
}

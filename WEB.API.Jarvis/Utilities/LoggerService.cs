using Serilog;
using Serilog.Formatting.Json;

namespace WEB.API.Jarvis.Utilities
{
    public static class LoggerService
    {
        
        public static void LogActionStart(string action, string requester, string externalCredentialType, string externalCredential)
        {
            var log = new LoggerConfiguration()
                            .WriteTo.File(new JsonFormatter(renderMessage: true), "C:/Logs/log.json")
                            .CreateLogger();
            DateTime startTime = DateTime.Now;

            log.Information(
                "Action: {Action} | Requester: {Requester} | ExternalCredentialType: {CredentialType} | Start Time: {StartTime}",
                action,
                requester,
                externalCredentialType,
                startTime
            );
        }

        public static void LogActionEnd(string action, DateTime startTime)
        {
            var log = new LoggerConfiguration()
                            .WriteTo.File(new JsonFormatter(renderMessage: true), "C:/Logs/log.json")
                            .CreateLogger();

            DateTime endTime = DateTime.Now;

            log.Information(
                "Action: {Action} | Execution Time: {ExecutionTime} seconds",
                action,
                endTime.Subtract(startTime).TotalSeconds.ToString("N2")
            );
        }
    }
}

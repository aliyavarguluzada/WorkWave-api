using Microsoft.EntityFrameworkCore.Diagnostics;
using System.Data.Common;
using System.Diagnostics;

namespace WorkWaveApp.Infrastructure.Services
{
    public class PerformanceInterceptor : DbCommandInterceptor
    {
        private const long QuerySlowThreshold = 100; // milliseconds

        public PerformanceInterceptor()
        {

        }

       
        public override InterceptionResult<DbDataReader> ReaderExecuting(
            DbCommand command,
            CommandEventData eventData,
            InterceptionResult<DbDataReader> result)
        {
            Stopwatch stopwatch = Stopwatch.StartNew();

            var originalResult = base.ReaderExecuting(command, eventData, result);

            stopwatch.Stop();
            if (stopwatch.ElapsedMilliseconds > QuerySlowThreshold)
            {
                Console.WriteLine($"Slow Query Detected: {command.CommandText}");
            }

            return originalResult;
        }
    }
}

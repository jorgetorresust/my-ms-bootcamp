using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
    class Class1 : ILogger
    {
        IDisposable ILogger.BeginScope<TState>(TState state)
        {
            throw new NotImplementedException();
        }

        bool ILogger.IsEnabled(LogLevel logLevel)
        {
            throw new NotImplementedException();
        }

        void ILogger.Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception? exception, Func<TState, Exception?, string> formatter)
        {
            throw new NotImplementedException();
        }
    }
}

using System.ComponentModel.Composition;

namespace Projekt.CommonInterfaces
{
    [InheritedExport(typeof(ILoggerService))]
    interface ILoggerService
    {
        void Log(string text);
        void Log(string text, LogLevel level);
    }
}

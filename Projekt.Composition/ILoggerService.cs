using System.ComponentModel.Composition;

namespace Projekt.Composition
{
    [InheritedExport(typeof(ILoggerService))]
    public interface ILoggerService
    {
        void Log(string text);
        void Log(string text, LogLevel level);
    }
}

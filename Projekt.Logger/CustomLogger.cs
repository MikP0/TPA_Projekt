using Projekt.Composition;
using System;
using System.ComponentModel.Composition;

[PartCreationPolicy(CreationPolicy.Shared)]
public class CustomLogger : ILoggerService
{
    private const string FILE_EXT = ".log";
    private readonly string datetimeFormat;
    private string logFilename;

    [ImportingConstructor]
    public CustomLogger()
    {
        datetimeFormat = "yyyy-MM-dd HH:mm:ss.fff";

        logFilename = System.Reflection.Assembly.GetExecutingAssembly().GetName().Name + FILE_EXT;

        string logHeader = logFilename + " is created.";
        if (!System.IO.File.Exists(logFilename))
        {
            Log(DateTime.Now.ToString(datetimeFormat) + " " + logHeader);
        }
    }

    public void Log(string text)
    {
        try
        {
            using (System.IO.StreamWriter writer = new System.IO.StreamWriter(logFilename, true, System.Text.Encoding.UTF8))
            {
                if (!string.IsNullOrEmpty(text))
                {
                    writer.WriteLine(text);
                }
            }
        }
        catch
        {
            throw new NullReferenceException();
        }
    }

    public void Log(string text, LogLevel level)
    {
        string pretext;
        switch (level)
        {
            case LogLevel.TRACE:
                pretext = System.DateTime.Now.ToString(datetimeFormat) + " [TRACE]   ";
                break;
            case LogLevel.INFO:
                pretext = System.DateTime.Now.ToString(datetimeFormat) + " [INFO]    ";
                break;
            case LogLevel.DEBUG:
                pretext = System.DateTime.Now.ToString(datetimeFormat) + " [DEBUG]   ";
                break;
            case LogLevel.WARNING:
                pretext = System.DateTime.Now.ToString(datetimeFormat) + " [WARNING] ";
                break;
            case LogLevel.ERROR:
                pretext = System.DateTime.Now.ToString(datetimeFormat) + " [ERROR]   ";
                break;
            case LogLevel.FATAL:
                pretext = System.DateTime.Now.ToString(datetimeFormat) + " [FATAL]   ";
                break;
            default:
                pretext = "";
                break;
        }
        Log(pretext + text);
    }
}
using Projekt.CommonInterfaces;
using System;

namespace Projekt.Cmd
{
    internal class CommandLineOpenFilePathService : IOpenFilePathService
    {
        private string _filePath;
        public static CommandLineOpenFilePathService Create(string filePath)
        {
            CommandLineOpenFilePathService commandLineOpenFilePathService = new CommandLineOpenFilePathService
            {
                _filePath = filePath
            };
            return commandLineOpenFilePathService;
        }
        public string FilePath(string defaultPath)
        {
            Console.WriteLine("Reading object...:" + _filePath ?? defaultPath);
            return _filePath ?? defaultPath;
        }
    }
}

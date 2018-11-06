using Projekt.CommonInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt.Cmd
{
    class CommandLineSaveFilePathService : ISaveFilePathService
    {
        private string _filePath;
        public static CommandLineSaveFilePathService Create(string filePath)
        {
            CommandLineSaveFilePathService commandLineSaveFilePathService = new CommandLineSaveFilePathService
            {
                _filePath = filePath
            };
            return commandLineSaveFilePathService;
        }
        public string FilePath(string defaultPath)
        {
            Console.WriteLine("Saving object...:" + _filePath ?? defaultPath);
            return _filePath ?? defaultPath;
        }
    }
}

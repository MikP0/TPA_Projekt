using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using log4net;
using Projekt.CommonInterfaces;
using Projekt.Composition;
using Projekt.ViewModel;

namespace Projekt.Cmd
{
    class Program
    {
        private static WorkspaceViewModel DataContext;
        private static TreeViewItem rootItem;
        private static Dictionary<int, TreeViewItem> itemChildren = new Dictionary<int, TreeViewItem>();
        private static Stack<TreeViewItem> previousItems = new Stack<TreeViewItem>();
        private static readonly ILog logger = LogManager.GetLogger("CmdLogger");

        [STAThread]
        static void Main(string[] args)
        {
            Compose.Instance.Setup();
            Compose.Instance.AddLocalAssemblyToCatalog("Projekt.ViewModel.dll");
            Compose.Instance.AddLocalAssemblyToCatalog("Projekt.Model.dll");
            Compose.Instance.Container.ComposeExportedValue<IOpenFilePathService>(new CommandLineOpenFilePathService());
            Compose.Instance.Container.ComposeExportedValue<ISaveFilePathService>(new CommandLineSaveFilePathService());
            DataContext = Compose.Instance.Container.GetExportedValue<WorkspaceViewModel>();

            Console.WriteLine("Welcome to TPA_Projekt. Type in a command.");

            while (true)
            {
                Console.Write("$ ");
                string command = Console.ReadLine();

                string command_main = command.Split(new char[] { ' ' }).First();
                string[] arguments = command.Split(new char[] { ' ' }).Skip(1).ToArray();
                if (lCommands.ContainsKey(command_main))
                {
                    Action<string[]> function_to_execute = null;
                    lCommands.TryGetValue(command_main, out function_to_execute);
                    function_to_execute(arguments);
                }
                else
                    Console.WriteLine("Command '" + command_main + "' not found");
            }
        }


        private static Dictionary<string, Action<string[]>> lCommands =
            new Dictionary<string, Action<string[]>>()
            {
                { "list", ListFunc },
                { "help" , HelpFunc },
                { "read", ReadFunc},
                { "save", SaveFunc},
                { "exit", ExitFunc},
                { "clear", ClearFunc },
            };


        private static void ClearFunc(string[] obj)
        {
            Console.Clear();
        }

        private static void ListFunc(string[] obj)
        {
            if (logger.IsInfoEnabled) {
                logger.Info("List function invoked for item " + rootItem.ToString());
            }
            if(rootItem == null) {
                if (logger.IsErrorEnabled) {
                    logger.Warn("List function invoked but no rootItem is specified.");
                }
                Console.WriteLine("You have to read object first.");
                Console.WriteLine("If you're having issues with the program type 'help' for more instructions.");
                return;
            }
            int option1 = 0;
            Console.WriteLine("Listed values\n");
            if (obj.Length != 1)
            {
                PrintAndUpdate();
            }
            else if (Int32.TryParse(obj[0], out option1))
            {
                if (itemChildren.ContainsKey(option1))
                {
                    previousItems.Push(rootItem);
                    rootItem = itemChildren[option1];
                    PrintAndUpdate();
                }
                else if (option1 == 0)
                {
                    if (previousItems.Count() != 0)
                        rootItem = previousItems.Pop();
                    PrintAndUpdate();
                }
                else {
                    if (logger.IsWarnEnabled)
                    {
                        logger.Warn("User provided wrong argument for list function.");
                    }
                    Console.WriteLine("Wrong argument!");
                }
                
            }
            else
            {

            }

        }

        private static void PrintAndUpdate()
        {
            Console.WriteLine(rootItem.ToString());
            if (rootItem.IsExpanded == false)
                rootItem.IsExpanded = true;

            int counter = 0;
            itemChildren.Clear();
            foreach (TreeViewItem item in rootItem.Children)
            {
                itemChildren.Add(++counter, item);
            }
            foreach (KeyValuePair<int, TreeViewItem> item in itemChildren)
            {
                Console.WriteLine("\t[{0}]\t{1}", item.Key, item.Value.ToString());
            }
            if (previousItems.Count() != 0)
                Console.WriteLine("\t[0]\t{0}", previousItems.Peek().ToString());
        }

        private static void ReadFunc(string[] obj)
        {
            if(logger.IsInfoEnabled)
            {
                logger.Info("Read function invoked.");
            }
            if (obj.Length != 1)
            {
                if(logger.IsWarnEnabled)
                {
                    logger.Warn("No PATH argument provided to Read function");
                }
                Console.WriteLine("You have to provide PATH to .dll file");
                Console.WriteLine("If you're having issues with the program type 'help' for more instructions.");
                return;
            }
            DataContext.InjectOpenFilePathService(CommandLineOpenFilePathService.Create(obj[0]));
            DataContext.LoadFromFileDataCommand.Execute("Load");
            DataContext.ReadDataCommand.Execute("Read");
            Console.WriteLine("Read: " + DataContext.ReadFileName);
            try
            {
                rootItem = DataContext.HierarchicalAreas[0];
            }
            catch(ArgumentOutOfRangeException e)
            {
                if (logger.IsWarnEnabled)
                {
                    logger.Warn("Wrong PATH argument provided to Read function\n" + e);
                }
                Console.WriteLine("You have to provide correct PATH to .dll file. Your PATH is wrong or file doesn't exist.");
                Console.WriteLine("If you're having issues with the program type 'help' for more instructions.");
                return;
            }
            if(logger.IsInfoEnabled)
            {
                logger.Info("Correctly read " + rootItem.ToString());
            }
        }

        private static void SaveFunc(string[] obj)
        {
            if(logger.IsInfoEnabled)
            {
                logger.Info("Save function invoked");
            }
            if (rootItem == null)
            {
                if(logger.IsWarnEnabled)
                {
                    logger.Warn("Save function invoked but no object has been read");
                }
                Console.WriteLine("You have to read object first.");
                Console.WriteLine("If you're having issues with the program type 'help' for more instructions.");
                return;
            }

            if (obj.Length != 1) return;
            try
            {
                DataContext.InjectSaveFilePathService(CommandLineSaveFilePathService.Create(obj[0]));
                DataContext.SaveDataCommand.Execute("Save");
            }
            catch (UnauthorizedAccessException e)
            {
                if (logger.IsErrorEnabled)
                {
                    logger.Error("Unauthorized access !! \n" + e);
                }
                Console.WriteLine("Unauthorized access! Probably wrong PATH or you don't have enough privilages to save it in desired destination");
                return;
            }

            Console.WriteLine("Save: " + DataContext.SaveFileName);
            if (logger.IsInfoEnabled)
            {
                logger.Info("Correctly saved to file:\n" + DataContext.SaveFileName);
            }

        }

        public static void HelpFunc(string[] args)
        {
            if (logger.IsDebugEnabled)
            {
                logger.Debug("Help function invoked");
            }
            Console.WriteLine("============================= HELP =============================");
            Console.WriteLine("\nUsage:\t[OPTION] ARGUMENT\n");
            Console.WriteLine("Options:");
            Console.WriteLine("\thelp            - show help");
            Console.WriteLine("\texit            - exit program");
            Console.WriteLine("\tclear           - clear terminal");
            Console.WriteLine("\tread <PATH>     - read object model from chosen .dll");
            Console.WriteLine("\tsave <PATH>     - save object model to file");
            Console.WriteLine("\tlist <ARGUMENT> - list objects from loaded .dll");
        }
        public static void ExitFunc(string[] args)
        {
            if (logger.IsInfoEnabled)
            {
                logger.Debug("Exit function enabled. Program will shut down....");
            }
            System.Environment.Exit(1);
        }
    }
}

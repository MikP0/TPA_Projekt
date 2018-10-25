using System;
using System.Collections.Generic;
using System.Linq;
using Projekt.ViewModel;

namespace Projekt.Cmd
{
    class Program
    {
        private static readonly WorkspaceViewModel workspaceViewModel = new WorkspaceViewModel();
        private static TreeViewItem rootItem;
        private static Dictionary<int, TreeViewItem> itemChildren = new Dictionary<int, TreeViewItem>();
        private static Stack<TreeViewItem> previousItems = new Stack<TreeViewItem>();

        [STAThread]
        static void Main(string[] args)
        {

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
            if(rootItem == null) {
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
                    Console.WriteLine("Wrong argument!");
                }
                
            }
            else
            {

            }

        }

        private static void PrintAndUpdate()
        {
            Console.WriteLine(rootItem.Name);
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
                Console.WriteLine("\t[{0}]\t{1}", item.Key, item.Value.Name);
            }
            if (previousItems.Count() != 0)
                Console.WriteLine("\t[0]\t{0}", previousItems.Peek().Name);
        }

        private static void ReadFunc(string[] obj)
        {
            if (obj.Length != 1)
            {
                Console.WriteLine("You have to provide PATH to .dll file");
                Console.WriteLine("If you're having issues with the program type 'help' for more instructions.");
                return;
            }
            Console.WriteLine("Reading object...:" + obj[0]);
            workspaceViewModel.ReadFileName = obj[0];
            workspaceViewModel.LoadFromFileDataCommand.Execute("Load");
            workspaceViewModel.ReadDataCommand.Execute("Read");
            Console.WriteLine("Read: " + workspaceViewModel.ReadFileName);
            rootItem = workspaceViewModel.HierarchicalAreas[0];
        }

        private static void SaveFunc(string[] obj)
        {
            if (rootItem == null)
            {
                Console.WriteLine("You have to read object first.");
                Console.WriteLine("If you're having issues with the program type 'help' for more instructions.");
                return;
            }

            if (obj.Length != 1) return;
            Console.WriteLine("Saving object...:" + obj[0]);
            workspaceViewModel.SaveFileName = obj[0];
            workspaceViewModel.SaveDataCommand.Execute("Save");
            Console.WriteLine("Save: " + workspaceViewModel.SaveFileName);

        }

        public static void HelpFunc(string[] args)
        {
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
            System.Environment.Exit(1);
        }
    }
}

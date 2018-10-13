using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using Projekt.ViewModel;

namespace Projekt.Cmd
{
    class Program
    {
        private static readonly workspaceViewModel workspaceViewModel = new workspaceViewModel();
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
                { "exit", ExitFunc}, 
            };

        private static void ListFunc(string[] obj)
        {
            
            Console.WriteLine("Listed values\n");
            if (obj.Length != 1)
            {
                foreach (var item in workspaceViewModel.HierarchicalAreas)
                {
                    Console.WriteLine(item.Name);
                }
            }
            else if(obj[0] == "child")
            {
                foreach (var item in workspaceViewModel.HierarchicalAreas)
                {
                    Console.WriteLine(item.Name);
                    item.IsExpanded = true;
                    foreach(var children in item.Children)
                    {
                        children.IsExpanded = true;
                        Console.WriteLine(children.Name);
                    }
                }
            }
            else
            {

            }
            
        }
        private static void CopyFunc(string[] obj)
        {
            if (obj.Length != 2) return;
            Console.WriteLine("Copying " + obj[0] + " to " + obj[1]);
        }
        private static void ReadFunc(string[] obj)
        {
            if (obj.Length != 1) return;
            Console.WriteLine("Reading object...:" + obj[0]);
            workspaceViewModel.FileName = obj[0];
            workspaceViewModel.LoadFromFileDataCommand.Execute("Load");
            workspaceViewModel.ReadDataCommand.Execute("Read");
            Console.WriteLine("Read: " + workspaceViewModel.FileName);
        }

        public static void HelpFunc(string[] args)
        {
            Console.WriteLine("===== SOME MEANINGFULL HELP ==== ");
        }
        public static void ExitFunc(string[] args)
        {
            System.Environment.Exit(1);
        }
    }
}

using System;
using System.Reflection;
using System.IO;

namespace MLNet
{
    public class Program
    {
        static void Main(string[] args)
        {

            if (args.Length < 3)
            {
                ShowUsage();
            }
            else
            {
                string dll = $"{Directory.GetCurrentDirectory()}\\bin\\Debug\\netstandard2.0\\{args[0]}.dll";
                string action = args[1];
                string model = args[2];

                Assembly assembly = Assembly.LoadFile(dll);
                
                string assemblyName = assembly.GetName().Name;

                MethodInfo m = assembly.GetType($"{assemblyName}.{model}").GetMethod(action);
                m.Invoke(assembly.CreateInstance($"{assemblyName}.{model}"),null);


            }
        }

        static void ShowUsage()
        {
            Console.WriteLine($"mlnet");
            Console.WriteLine("-------------");

            Console.WriteLine("\nUsage:");
            Console.WriteLine("\tmlnet <current-project-dll> <action> <model-class>");
            Console.WriteLine("\tmlnet MLModels Train IrisClassification");
            Console.WriteLine("\nAction:");
            Console.WriteLine("\tTrain\tTrains Model");
        }
    }
}

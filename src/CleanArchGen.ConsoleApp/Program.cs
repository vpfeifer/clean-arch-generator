using Microsoft.Extensions.DependencyInjection;
using System;

namespace CleanArchGen.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            ServiceProvider provider = Bootstrapper.ResolveAppDependencies();

            Console.WriteLine("Hello World!");
        }
    }
}

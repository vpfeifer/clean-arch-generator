using System;
using System.IO;

namespace CleanArchGen.Infra.FileSystem
{
    public class DirectoryCreator
    {
        public void Create(string path)
        {
            try 
            {
                if (Directory.Exists(path)) 
                {
                    Console.WriteLine($"The path '{path}' already exists.");
                    return;
                }

                Directory.CreateDirectory(path);
                Console.WriteLine($"The directory {path} was created.");
            } 
            catch (Exception e)
            {
                Console.WriteLine($"Could not create directory {path}: {e.ToString()}");
                throw e;
            } 
        }   
    }
}

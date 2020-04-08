using System;
using System.IO;
using CleanArchGen.Domain.Interfaces;

namespace CleanArchGen.Infra.FileSystem
{
    public class DirectoryCreator : IDirectoryCreator
    {
        public void CreateAndSetAsCurrentPath(string path)
        {
            if (!Directory.Exists(path)) 
            {
                Directory.CreateDirectory(path);
            }

            Environment.CurrentDirectory = path;
        }
    }
}

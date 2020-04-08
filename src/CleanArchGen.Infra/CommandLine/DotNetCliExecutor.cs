using System;
using System.Diagnostics;
using CleanArchGen.Domain.Interfaces;
using CleanArchGen.Infra.Exceptions;

namespace CleanArchGen.Infra.CommandLine
{
    public class DotNetCliExecutor : IDotNetClient
    {
        private Process _process;

        public void CreateSolutionFile(string path, string name)
        {
            var createSolutionCommand = $"new sln -o {path} -n {name} --force";

            try
            {
               Execute(createSolutionCommand);
            }
            catch(Exception)
            {
                throw new CouldNotCreateSolutionFileException(createSolutionCommand);
            }
        }

        private void Execute(string command)
        {
            using (_process = new Process())
            {
                _process.StartInfo.FileName = "dotnet";
                _process.StartInfo.Arguments = command;
                _process.StartInfo.CreateNoWindow = true;
                _process.StartInfo.RedirectStandardOutput = true;
                _process.Start();
                
                _process.WaitForExit();

                if (_process.HasExited && _process.ExitCode != 0)
                    throw new ErrorExecutingDotNetCommandException(command);
            }
        }
    }
}
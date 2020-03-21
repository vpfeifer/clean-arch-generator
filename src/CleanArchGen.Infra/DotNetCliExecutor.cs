using System;
using System.Diagnostics;
using System.Threading.Tasks;
using CleanArchGen.Infra.Exceptions;

namespace CleanArchGen.Infra
{
    public class DotNetCliExecutor
    {
        private Process _process;

        public void Execute(string command)
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
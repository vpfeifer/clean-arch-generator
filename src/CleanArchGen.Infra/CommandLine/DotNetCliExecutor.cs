using System;
using System.Diagnostics;
using CleanArchGen.Domain.Interfaces;
using CleanArchGen.Infra.Exceptions;

namespace CleanArchGen.Infra.CommandLine
{
    public class DotNetCliExecutor : IDotNetClient
    {
        private readonly ICommandBuilder _commandBuilder;
        private Process _process;

        public DotNetCliExecutor(ICommandBuilder commandBuilder)
        {
            _commandBuilder = commandBuilder;
        }

        public void CreateSolutionFile(string path, string fileName)
        {
            var command = _commandBuilder.NewSolution()
                                .WithPath(path)
                                .WithName(fileName)
                                .WithForce()
                                .Build();

            TryExecute(command);
        }

        public void CreateClassLibProject(string path, string projectName)
        {
            var command = _commandBuilder.NewClassLib()
                                .WithPath(path)
                                .WithName(projectName)
                                .WithNoRestore()
                                .WithForce()
                                .Build();

            TryExecute(command);
        }

        public void CreateWebApiProject(string path, string projectName)
        {
            var command = _commandBuilder.NewWebApi()
                                .WithPath(path)
                                .WithName(projectName)
                                .WithNoRestore()
                                .WithForce()
                                .Build();

            TryExecute(command);
        }

        private void TryExecute(string command)
        {
            try
            {
                Execute(command);
            }
            catch (Exception)
            {
                throw new ErrorExecutingDotNetCommandException(command);
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
using System;
using CleanArchGen.Infra.Exceptions;

namespace CleanArchGen.Infra.CommandLine
{
    public class DotNetCommandBuilder : ICommandBuilder
    {
        private string command = string.Empty;
        private bool isDefaultCommandDefined = false;

        public ICommandBuilder NewSolution()
        {
            return AddDefaultCommand("new sln");
        }

        public ICommandBuilder NewClassLib()
        {
            return AddDefaultCommand("new classlib");
        }

        public ICommandBuilder WithPath(string path)
        {
            var parameter = $" -o {path}";
            return AddParameterWithArgument(parameter, "path", path);
        }

        public ICommandBuilder WithName(string name)
        {
            var parameter = $" -n {name}";
            return AddParameterWithArgument(parameter, "name", name);
        }

        public ICommandBuilder WithNoRestore()
        {
            return AddParameter(" --no-restore");
        }

        public ICommandBuilder WithForce()
        {
            return AddParameter(" --force");
        }

        private ICommandBuilder AddDefaultCommand(string defaultCommand)
        {
            if(isDefaultCommandDefined) 
                throw new DefaultCommandAlreadyDefinedException(defaultCommand);

            command += defaultCommand;
            isDefaultCommandDefined = true;
            return this;
        }

        private ICommandBuilder AddParameter(string parameter)
        {
            if(!isDefaultCommandDefined)
                throw new DefaultCommandMustBeDefinedException(parameter, command);

            command += parameter;

            return this;
        }

        private ICommandBuilder AddParameterWithArgument(string parameter, string argumentName, string argumentValue)
        {
            if (string.IsNullOrWhiteSpace(argumentValue))
                throw new ArgumentException($"The {argumentName} must not be empty, null or whitespace.");

            return AddParameter(parameter);
        }

        public string Build()
        {
            return command;
        }
    }
}
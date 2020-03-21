using System;

namespace CleanArchGen.Infra.Exceptions
{
    public class ErrorExecutingDotNetCommandException : Exception
    {
        public ErrorExecutingDotNetCommandException(string command) 
            : base($"Error trying to execute dotnet command : {command}") 
        {
            
        }
    }
}
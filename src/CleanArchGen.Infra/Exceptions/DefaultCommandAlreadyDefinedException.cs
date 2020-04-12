using System;

namespace CleanArchGen.Infra.Exceptions
{
    public class DefaultCommandAlreadyDefinedException : Exception
    {
        public DefaultCommandAlreadyDefinedException(string command) 
            : base($"Default command already defined : {command}") 
        {
            
        }
    }
}
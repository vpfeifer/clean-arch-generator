using System;

namespace CleanArchGen.Infra.Exceptions
{
    public class DefaultCommandMustBeDefinedException : Exception
    {
        public DefaultCommandMustBeDefinedException(string parameter, string command) 
            : base($"Default command must be defined before : {parameter}. Actual command : {command}") 
        {
            
        }
    }
}
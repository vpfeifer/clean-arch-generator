using System;

namespace CleanArchGen.Infra.Exceptions
{
    public class CouldNotCreateSolutionFileException : Exception
    {
        public CouldNotCreateSolutionFileException(string command) 
            : base($"Error trying to create solution file : {command}") 
        {
            
        }
    }
}
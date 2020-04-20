namespace CleanArchGen.Infra.CommandLine
{
    public interface ICommandBuilder
    {
        ICommandBuilder NewSolution();
        ICommandBuilder NewClassLib();
        ICommandBuilder NewWebApi();
        ICommandBuilder WithPath(string path);
        ICommandBuilder WithName(string name);
        ICommandBuilder WithNoRestore();
        ICommandBuilder WithForce();
        string Build();
    }
}
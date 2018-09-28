namespace Codific.Interfaces.Engine
{
    public interface ICommand
    {
        string Description { get; }

        void Execute(string args);
    }
}

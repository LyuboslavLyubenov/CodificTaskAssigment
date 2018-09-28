namespace Codific.Interfaces
{
    public interface IDoor
    {
        IItem RequiredItemForUnlocking { get; }

        IRoom Room { get; }
    }
}

using System.Collections.ObjectModel;

namespace Codific.Interfaces
{
    public interface IMaze
    {
        IRoom FirstRoom { get; }

        IRoom LastRoom { get; }

        ReadOnlyCollection<IRoom> AllRooms { get; }
    }
}

using Codific.Interfaces;

namespace Codific.Utils
{
    public class MazeGenerator
    {
        MazeGenerator()
        {    
        }

        public static IMaze GeneratePreBuildMaze()
        {
            var keyForFourthRoom = new KeyItem("Key 4", 10);
            var keyForFinalRoom = new KeyItem("Key 7", 50);

            var first = new Room();
            var second = new Room();
            var third = new Room(new IItem[] { keyForFourthRoom });
            var fourth = new Room();
            var fifth = new Room();
            var sixth = new Room(new IItem[] { keyForFinalRoom });
            var seventh = new Room();
            
            first.AddDoorTo(second);
            second.AddDoorTo(third);
            second.AddDoorTo(fourth, keyForFourthRoom);
            third.AddDoorTo(second);
            fourth.AddDoorTo(fifth);
            fifth.AddDoorTo(sixth);
            fifth.AddDoorTo(seventh, keyForFinalRoom);
            sixth.AddDoorTo(fifth);

            var allRooms = new IRoom[]
            {
                first,
                second,
                third,
                fourth,
                fifth,
                sixth,
                seventh
            };

            return new Maze(allRooms, first, seventh);
        }
    }
}

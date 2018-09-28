using System;
using System.Linq;
using System.Reflection;
using Codific;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CodificTests
{
    [TestClass]
    public class RoomTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CantAddDoorToNullRoom()
        {
            var room = new Room();
            room.AddDoorTo(null);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void CantAddAnotherDoorToRoom()
        {
            var room = new Room();
            var room2 = new Room();
            room.AddDoorTo(room2);
            room.AddDoorTo(room2);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void CantAddRoomToSelf()
        {
            var room = new Room();
            room.AddDoorTo(room);
        }

        [TestMethod]
        public void SuccessfullyAddsDoorToRoom()
        {
            var room = new Room();
            var room2 = new Room();
            room.AddDoorTo(room2);
            var isDoorAdded = room.AllDoors.ToList().Exists(d => d.Room == room2);
            Assert.IsTrue(isDoorAdded);
        }
    }
}

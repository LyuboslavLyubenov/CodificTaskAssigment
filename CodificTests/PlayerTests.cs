using System;
using Codific;
using Codific.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace CodificTests
{
    [TestClass]
    public class PlayerTests
    {
        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void ReceiveDamageWhenDeadThrowsException()
        {
            var firstRoomMock = new Mock<IRoom>();
            var player = new Player(firstRoomMock.Object);
            player.ReceiveDamage(100);
            player.ReceiveDamage(100);
        }

        [TestMethod]
        public void CorrectlyCalculateHealthAfterReceiveDamage()
        {
            var firstRoomMock = new Mock<IRoom>();
            var player = new Player(firstRoomMock.Object);
            player.ReceiveDamage(30);
            Assert.AreEqual(Player.StartHealth - 30, player.Health);
            Assert.IsTrue(player.IsAlive);
        }

        [TestMethod]
        public void CorrectlyCalculateHealthAfterReceiveDamage2()
        {
            var firstRoomMock = new Mock<IRoom>();
            var player = new Player(firstRoomMock.Object);
            player.ReceiveDamage(5000);
            Assert.AreEqual(0, player.Health);
            Assert.IsFalse(player.IsAlive);
        }

        [TestMethod]
        public void FireOnCreatureDeathWhenPlayerIsKilled()
        {
            var firstRoomMock = new Mock<IRoom>();
            var player = new Player(firstRoomMock.Object);
            player.OnCreatureDeath += (sender, args) => { Assert.IsTrue(true); };
            player.ReceiveDamage(5000);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ChangePositionWhenNewRoomIsNullThrowsException()
        {
            var firstRoomMock = new Mock<IRoom>();
            var player = new Player(firstRoomMock.Object);
            player.ChangePosition(null);
        }

        [TestMethod]
        public void ChangedPositionFireChangedRoomEventSuccessfully()
        {
            var firstRoomMock = new Mock<IRoom>();
            var player = new Player(firstRoomMock.Object);
            player.OnRoomEnter += (sender, args) => { Assert.AreSame(args.Room, firstRoomMock.Object); };
            player.ChangePosition(firstRoomMock.Object);
        }
    }
}

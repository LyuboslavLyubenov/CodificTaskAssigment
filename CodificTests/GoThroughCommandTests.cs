using System;
using Codific;
using Codific.Commands;
using Codific.Interfaces.Engine;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CodificTests
{
    [TestClass]
    public class GoThroughCommandTests
    {
        private ICommandsRunner commandsRunner;

        [TestInitialize]
        public void Initialize()
        {
            this.commandsRunner = new CommandsRunner();
            commandsRunner.AddCommand("Мини през", new GoThroughCommand());
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void IfRoomNumberIsNotValidIntegerThrowsException()
        {
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void IfDoesntHaveDoorToTheRoomThrowException()
        {

        }
    }
}
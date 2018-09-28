using System;
using Codific;
using Codific.Exceptions;
using Codific.Interfaces.Engine;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace CodificTests
{
    class FakeCommand : ICommand
    {
        public string Description { get; }

        public void Execute(string args)
        {
            throw new NotImplementedException();
        }
    }

    [TestClass]
    public class CommandsRunnerTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AddNullCommandNameThrowsException()
        {
            var commandsRunner = new CommandsRunner();
            commandsRunner.AddCommand("", null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AddNullCommandThrowsException()
        {
            var commandsRunner = new CommandsRunner();
            commandsRunner.AddCommand("NotNullName", null);
        }

        [TestMethod]
        [ExpectedException(typeof(DublicateCommandException))]
        public void AddSameCommandMoreThanOnceThrowsException()
        {
            var fakeCommand = new Mock<ICommand>();
            var commandsRunner = new CommandsRunner();
            commandsRunner.AddCommand("FakeCommand", fakeCommand.Object);
            commandsRunner.AddCommand("FakeCommand", fakeCommand.Object);
        }

        [TestMethod]
        public void AddCommandSuccessfully()
        {
            var fakeCommand = new Mock<ICommand>();
            var commandsRunner = new CommandsRunner();
            commandsRunner.AddCommand("FakeCommands", fakeCommand.Object);

        }
        
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void RemoveCommandThatsNotAddedThrowsException()
        {
            var commandsRunner = new CommandsRunner();
            commandsRunner.RemoveCommand("fakeCommand");
        }
        
        [TestMethod]
        public void RemoveCommandSuccessfully()
        {
            var fakeCommand = new Mock<ICommand>();
            var commandsRunner = new CommandsRunner();
            commandsRunner.AddCommand("FakeCommand", fakeCommand.Object);
            commandsRunner.RemoveCommand("FakeCommand");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void RunCommandWithNullArgumentStringThrowsException()
        {
            var commandsRunner = new CommandsRunner();
            commandsRunner.RunCommand(null);
        }
        
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void RunCommandWithEmptyStringThrowsException()
        {
            var commandsRunner = new CommandsRunner();
            commandsRunner.RunCommand("");
        }

        [TestMethod]
        [ExpectedException(typeof(NotFoundCommandException))]
        public void RunCommandWithNotExistingNameThrowsException()
        {
            var commandsRunner = new CommandsRunner();
            commandsRunner.RunCommand("asdasdas");
        }
        
        [TestMethod]
        public void RunCommandSuccessfully()
        {
            var commandsRunner = new CommandsRunner();
            var fakeCommand = new Mock<ICommand>();
            fakeCommand.Setup(x => x.Execute(null)).Callback(() =>
            {
                Assert.IsTrue(true);
            });

            commandsRunner.AddCommand("FakeCommand", fakeCommand.Object);
            commandsRunner.RunCommand("FakeCommand");
        }

        [TestMethod]
        public void RunCommandSuccessfullyWithParameters()
        {
            var commandsRunner = new CommandsRunner();
            var fakeCommand = new Mock<ICommand>();
            var args = "command args";
            fakeCommand.Setup(x => x.Execute(args)).Callback((string receivedArgs) =>
            {
                Assert.AreEqual(args, receivedArgs);
            });

            commandsRunner.AddCommand("FakeCommand", fakeCommand.Object);
            commandsRunner.RunCommand("FakeCommand - " + args);
        }
    }
}

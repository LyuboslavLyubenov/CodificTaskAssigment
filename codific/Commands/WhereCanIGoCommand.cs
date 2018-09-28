using System;
using System.Linq;
using Codific.Interfaces;
using Codific.Interfaces.Engine;

namespace Codific.Commands
{
    public class WhereCanIGoCommand : ICommand
    {
        private readonly IMainPlayer player;
        private readonly IScreenDrawer drawer;

        public WhereCanIGoCommand(IMainPlayer player, IScreenDrawer drawer)
        {
            this.player = player ?? throw new ArgumentNullException(nameof(player));
            this.drawer = drawer ?? throw new ArgumentNullException(nameof(drawer));
        }

        public string Description
        {
            get => "Показва стаите до които можеш да отидеш";
        }

        public void Execute(string args)
        {
            var output = string.Join(Environment.NewLine, this.player.Position.AllDoors.Select(d => "Стая номер " + d.Room.Number));
            this.drawer.ShowMessage($"Местата до които можеш да отидеш са: {Environment.NewLine}{output}");
        }
    }
}

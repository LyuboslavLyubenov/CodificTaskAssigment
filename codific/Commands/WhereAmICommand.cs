using System;
using Codific.Interfaces;
using Codific.Interfaces.Engine;

namespace Codific.Commands
{
    public class WhereAmICommand : ICommand
    {
        private readonly IMainPlayer player;
        private readonly IScreenDrawer drawer;

        public WhereAmICommand(IMainPlayer player, IScreenDrawer drawer)
        {
            this.player = player ?? throw new ArgumentNullException(nameof(player));
            this.drawer = drawer ?? throw new ArgumentNullException(nameof(drawer));
        }

        public string Description
        {
            get => "Показва в коя стая си";
        }

        public void Execute(string args)
        {
            this.drawer.ShowMessage($"Намираш се в {this.player.Position.Number} стая");
        }
    }
}

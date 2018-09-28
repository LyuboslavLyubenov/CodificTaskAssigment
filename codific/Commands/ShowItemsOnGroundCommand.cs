using System;
using System.Linq;
using Codific.Interfaces;
using Codific.Interfaces.Engine;

namespace Codific.Commands
{
    public class ShowItemsOnGroundCommand : ICommand
    {
        private readonly IMainPlayer player;
        private readonly IScreenDrawer screenDrawer;

        public ShowItemsOnGroundCommand(IMainPlayer player, IScreenDrawer screenDrawer)
        {
            this.player = player ?? throw new ArgumentNullException(nameof(player));
            this.screenDrawer = screenDrawer ?? throw new ArgumentNullException(nameof(screenDrawer));
        }

        public string Description
        {
            get => "Показва дали в стаята има няккави предмети за вземане";
        }

        public void Execute(string args)
        {
            var itemsWithWeights = this.player.Position.ItemsInside.Select(i => $"{i.Name} ({i.Weight} kg)");
            this.screenDrawer.ShowMessage("Предмети: " + Environment.NewLine + string.Join(Environment.NewLine, itemsWithWeights));
        }
    }
}

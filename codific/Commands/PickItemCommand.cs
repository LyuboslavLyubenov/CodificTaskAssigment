using System;
using System.Linq;
using Codific.Interfaces;
using Codific.Interfaces.Engine;

namespace Codific.Commands
{
    public class PickItemCommand : ICommand
    {
        private readonly IMainPlayer player;
        private readonly IScreenDrawer screenDrawer;

        public PickItemCommand(IMainPlayer player, IScreenDrawer screenDrawer)
        {
            this.player = player ?? throw new ArgumentNullException(nameof(player));
            this.screenDrawer = screenDrawer ?? throw new ArgumentNullException(nameof(screenDrawer));
        }

        public string Description
        {
            get => "Вземаш предмет от земята";
        }

        public void Execute(string args)
        {
            var itemName = args;
            var item = this.player.Position.ItemsInside.FirstOrDefault(i => i.Name == itemName);

            if (item == null)
            {
                throw new ArgumentException("Не съществува предмет в стаята с име " + itemName);
            }

            this.player.Backpack.PickupItem(item);
            this.screenDrawer.ShowMessage("Успешно взе предмет");
        }
    }
}

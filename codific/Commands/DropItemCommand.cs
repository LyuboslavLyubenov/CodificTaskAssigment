using System;
using System.Linq;
using Codific.Interfaces;
using Codific.Interfaces.Engine;

namespace Codific.Commands
{
    public class DropItemCommand : ICommand
    {
        private readonly IMainPlayer mainPlayer;
        private readonly IScreenDrawer drawer;

        public DropItemCommand(IMainPlayer mainPlayer, IScreenDrawer drawer)
        {
            this.mainPlayer = mainPlayer ?? throw new ArgumentNullException(nameof(mainPlayer));
            this.drawer = drawer ?? throw new ArgumentNullException(nameof(drawer));
        }

        public string Description
        {
            get => "Изхвърля предмет в стаята";
        }

        public void Execute(string args)
        {
            var itemName = args;
            var item = this.mainPlayer.Backpack.CurrentHoldingItems.FirstOrDefault(i => i.Name == itemName);

            if (item == null)
            {
                throw new InvalidOperationException($"Не съществува предмет {itemName} в чантата");
            }

            this.mainPlayer.Backpack.DropItem(item);
            this.drawer.ShowMessage("Предмета успешно взет");
        }
    }
}

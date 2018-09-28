using System;
using Codific.Interfaces;
using Codific.Interfaces.Engine;

namespace Codific.Commands
{
    public class GoThroughCommand : ICommand
    {
        private readonly IMainPlayer player;
        private readonly IScreenDrawer drawer;

        public GoThroughCommand(IMainPlayer player, IScreenDrawer drawer)
        {
            this.player = player ?? throw new ArgumentNullException(nameof(player));
            this.drawer = drawer ?? throw new ArgumentNullException(nameof(drawer));
        }

        public string Description
        {
            get => "Влиза в стая. Използва се по следният начин: Мини 1 , където 1 е номера на стаята";
        }

        public void Execute(string args)
        {
            int roomNumber;
            var isParsed = int.TryParse(args, out roomNumber);

            if (!isParsed)
            {
                throw new InvalidOperationException("Невалиден номер на стая");
            }

            this.player.ChangePosition(roomNumber);
            this.drawer.ShowMessage("Успешно преместил се в стая с номер " + roomNumber);
        }
    }
}

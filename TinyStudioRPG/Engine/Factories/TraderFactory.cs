using Engine.Models;
namespace Engine.Factories
{
    public static class TraderFactory
    {
        private static readonly List<Trader> _traders = [];
        static TraderFactory()
        {
            Trader susan = new("Susana");
            susan.AddItemToInventory(ItemFactory.CreateGameItem(1001));
            Trader farmerTed = new("Granjero Guillermo");
            farmerTed.AddItemToInventory(ItemFactory.CreateGameItem(1001));
            Trader peteTheHerbalist = new("Romualdo el yerbero");
            peteTheHerbalist.AddItemToInventory(ItemFactory.CreateGameItem(1001));
            AddTraderToList(susan);
            AddTraderToList(farmerTed);
            AddTraderToList(peteTheHerbalist);
        }
        public static Trader GetTraderByName(string name)
        {
            return _traders.FirstOrDefault(t => t.Name == name);
        }
        private static void AddTraderToList(Trader trader)
        {
            if (_traders.Any(t => t.Name == trader.Name))
            {
                throw new ArgumentException($"There is already a trader named '{trader.Name}'");
            }
            _traders.Add(trader);
        }
    }
}
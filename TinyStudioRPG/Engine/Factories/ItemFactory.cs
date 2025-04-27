using Engine.Models;

namespace Engine.Factories
{
    public static class ItemFactory
    {
        private readonly static List<GameItem> _standardGameItems;

        static ItemFactory()
        {
            _standardGameItems = [];

            _standardGameItems.Add(new Weapon(1001, "Facón", 1, 1, 2));
            _standardGameItems.Add(new Weapon(1002, "Hacha", 2, 2, 2));
            _standardGameItems.Add(new GameItem(9001, "Diente de víbora", 1));
            _standardGameItems.Add(new GameItem(9002, "Cuero de víbora", 2));
            _standardGameItems.Add(new GameItem(9003, "Cola de rata", 1));
            _standardGameItems.Add(new GameItem(9004, "Cuero de rata", 2));
            _standardGameItems.Add(new GameItem(9005, "Colmillo de araña", 1));
            _standardGameItems.Add(new GameItem(9006, "Tela de araña", 2));
        }

        public static GameItem CreateGameItem(int itemTypeId)
        {
            GameItem standardItem = _standardGameItems.FirstOrDefault(item => item.ItemTypeID == itemTypeId);

            if (standardItem != null)
            {
                return standardItem
                       is not Weapon ? standardItem.Clone() : ((Weapon)standardItem).Clone();
            }

            return null;
        }
    }
}

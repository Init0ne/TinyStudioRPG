using Engine.Models;

namespace Engine.Factories
{
    public static class ItemFactory
    {
        private static List<GameItem> _standardGameItems;

        static ItemFactory()
        {
            _standardGameItems = [];

            _standardGameItems.Add(new Weapon(1001, "Facon", 1, 1, 2));
            _standardGameItems.Add(new Weapon(1002, "Hacha", 2, 2, 2));
        }

        public static GameItem CreateGameItem(int itemTypeId)
        {
            GameItem standardItem = _standardGameItems.FirstOrDefault(item => item.ItempTypeID == itemTypeId);

            if (standardItem != null)
            {
                return standardItem.Clone();
            }

            return null;
        }
    }
}

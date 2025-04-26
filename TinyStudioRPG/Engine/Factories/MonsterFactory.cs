using Engine.Models;

namespace Engine.Factories
{
    public class MonsterFactory
    {
        public static Monster GetMonster(int monsterID)
        {
            switch (monsterID)
            {
                case 1:
                    Monster vibora = new("Víbora", "Vibora.png", 4, 4, 2, 1);

                    AddLootItem(vibora, 9001, 25);
                    AddLootItem(vibora, 9002, 75);

                    return vibora;

                case 2:
                    Monster rata = new("Rata", "Vibora.png", 4, 4, 2, 1);

                    AddLootItem(rata, 9003, 25);
                    AddLootItem(rata, 9004, 75);

                    return rata;

                case 3:
                    Monster araña = new("Araña", "Vibora.png", 4, 4, 2, 1);

                    AddLootItem(araña, 9005, 25);
                    AddLootItem(araña, 9006, 75);

                    return araña;

                default:
                    throw new ArgumentException(string.Format("MonsterType '{0}' does not exist", monsterID));
            }
        }

        private static void AddLootItem(Monster monster, int itemID, int dropPercentage)
        {
            if (RandonNumberGenerator.SimpleNumberBetween(1, 100) <= dropPercentage)
            {
                monster.Inventory.Add(new ItemQuantity(itemID, 1));
            }
        }
    }
}

using Engine.Models;

namespace Engine
{
    public class Weapon(int itemTypeID, string name, int price, int minDamage, int maxDamage) : GameItem(itemTypeID, name, price)
    {
        public int MinimumDamage { get; set; } = minDamage;
        public int MaximumDamage { get; set; } = maxDamage;

        public new Weapon Clone()
        {
            return new Weapon(ItemTypeID, Name, Price, MinimumDamage, MaximumDamage);
        }
    }
}

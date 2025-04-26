namespace Engine.Models
{
    public class GameItem(int itemTypeID, string name, int price)
    {
        public int ItempTypeID { get; set; } = itemTypeID;
        public string Name { get; set; } = name;
        public int Price { get; set; } = price;

        public GameItem Clone()
        {
            return new GameItem(ItempTypeID, Name, Price);
        }
    }
}

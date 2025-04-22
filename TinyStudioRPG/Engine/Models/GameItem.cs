namespace Engine.Models
{
    public class GameItem
    {
        public int ItempTypeID { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }

        public GameItem(int itemTypeID, string name, int price)
        {
            ItempTypeID = itemTypeID;
            Name = name;
            Price = price;
        }
    }
}

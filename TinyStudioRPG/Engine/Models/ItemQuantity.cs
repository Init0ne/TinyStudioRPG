namespace Engine.Models
{
    public class ItemQuantity(int itemId, int quantity)
    {
        public int ItemID { get; set; } = itemId;
        public int Quantity { get; set; } = quantity;
    }
}

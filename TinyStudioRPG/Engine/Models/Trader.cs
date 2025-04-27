using System.Collections.ObjectModel;
namespace Engine.Models
{
    public class Trader(string name) : BaseNotificationClass
    {
        public string Name { get; set; } = name;
        public ObservableCollection<GameItem> Inventory { get; set; } = [];

        public void AddItemToInventory(GameItem item)
        {
            Inventory.Add(item);
        }
        public void RemoveItemFromInventory(GameItem item)
        {
            Inventory.Remove(item);
        }
    }
}
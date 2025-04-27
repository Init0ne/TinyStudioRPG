using System.Collections.ObjectModel;
using System.ComponentModel;

namespace Engine.Models
{
    public class Player : BaseNotificationClass
    {
        private string name;
        private string characterClass;
        private int hitPoints;
        private int experiencePoints;
        private int level;
        private int gold;

        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                OnPropertyChanged(nameof(Name));
            }
        }

        public string CharacterClass
        {
            get { return characterClass; }
            set
            {
                characterClass = value;
                OnPropertyChanged(nameof(CharacterClass));
            }
        }

        public int HitPoints
        {
            get { return hitPoints; }
            set
            {
                hitPoints = value;
                OnPropertyChanged(nameof(HitPoints));
            }
        }

        public int ExperiencePoints
        {
            get { return experiencePoints; }
            set 
                { 
                    experiencePoints = value;
                    OnPropertyChanged(nameof(ExperiencePoints));
                }
        }

        public int Level
        {
            get { return level; }
            set
            {
                level = value;
                OnPropertyChanged(nameof(Level));
            }
        }

        public int Gold
        {
            get { return gold; }
            set
            {
                gold = value;
                OnPropertyChanged(nameof(Gold));
            }
        }

        public ObservableCollection<GameItem> Inventory { get; set; }

        public List<GameItem> Weapons => [.. Inventory.Where(i => i is Weapon)];
        public ObservableCollection<QuestStatus> Quests { get; set; }

        public Player()
        {
            Inventory = [];
            Quests = [];
        }

        public void AddItemToInventory(GameItem item)
        {
            Inventory.Add(item);

            OnPropertyChanged(nameof(Weapons));
        }
    }
}

using Engine.EventArgs;
using Engine.Factories;
using Engine.Models;

namespace Engine.ViewModels
{
    public class GameSession : BaseNotificationClass
    {
        public event EventHandler<GameMessageEventArgs> OnMessageRaised;

        #region Properties 

        private Location _currentLocation;
        private Monster _currentMonster;

        public World CurrentWorld { get; set; }
        public Player CurrentPlayer { get; set; }
        public Location CurrentLocation
        {
            get { return _currentLocation; }
            set
            {
                _currentLocation = value;

                OnPropertyChanged(nameof(CurrentLocation));
                OnPropertyChanged(nameof(HasLocationToNorth));
                OnPropertyChanged(nameof(HasLocationToWest));
                OnPropertyChanged(nameof(HasLocationToEast));
                OnPropertyChanged(nameof(HasLocationToSouth));

                CompleteQuestsAtLocation();
                GivePlayerQuestsAtLocation();
                GetMonsterAtLocation();
            }
        }

        public Monster CurrentMonster
        {
            get { return _currentMonster; }
            set
            {
                _currentMonster = value;

                OnPropertyChanged(nameof(CurrentMonster));
                OnPropertyChanged(nameof(HasMonster));

                if (CurrentMonster != null)
                {
                    RaiseMesage($"Viste un {CurrentMonster.Name} aca.");
                }
                else
                {
                    RaiseMesage("No hay nada por aca.");
                }
            }
        }

        public Weapon CurrentWeapon { get; set; }

        public bool HasLocationToNorth
        {
            get { return CurrentWorld.LocationAt(CurrentLocation.XCoordinate, CurrentLocation.YCoordinate + 1) != null; }
        }

        public bool HasLocationToWest
        {
            get { return CurrentWorld.LocationAt(CurrentLocation.XCoordinate - 1, CurrentLocation.YCoordinate) != null; }
        }

        public bool HasLocationToEast
        {
            get { return CurrentWorld.LocationAt(CurrentLocation.XCoordinate + 1, CurrentLocation.YCoordinate) != null; }
        }

        public bool HasLocationToSouth
        {
            get { return CurrentWorld.LocationAt(CurrentLocation.XCoordinate, CurrentLocation.YCoordinate - 1) != null; }
        }

        #endregion

        public bool HasMonster => CurrentMonster != null;

        public GameSession()
        {
            CurrentPlayer = new Player
            {
                Name = "Martín Fierro",
                CharacterClass = "Gaucho",
                HitPoints = 10,
                ExperiencePoints = 0,
                Level = 1,
                Gold = 100
            };

            if (CurrentPlayer.Weapons.Count == 0)
            {
                CurrentPlayer.AddItemToInventory(ItemFactory.CreateGameItem(1001));
            }

            CurrentWorld = WorldFactory.CreateWorld();

            CurrentLocation = CurrentWorld.LocationAt(0, -1);
        }

        public void MoveNorth()
        {
            Location newLocation = CurrentWorld.LocationAt(CurrentLocation.XCoordinate, CurrentLocation.YCoordinate + 1);
            if (HasLocationToNorth)
            {
                CurrentLocation = newLocation;
            }
        }

        public void MoveWest()
        {
            Location newLocation = CurrentWorld.LocationAt(CurrentLocation.XCoordinate - 1, CurrentLocation.YCoordinate);
            if (HasLocationToWest)
            {
                CurrentLocation = newLocation;
            }
        }

        public void MoveEast()
        {
            Location newLocation = CurrentWorld.LocationAt(CurrentLocation.XCoordinate + 1, CurrentLocation.YCoordinate);
            if (HasLocationToEast)
            {
                CurrentLocation = newLocation;
            }
        }

        public void MoveSouth()
        {
            Location newLocation = CurrentWorld.LocationAt(CurrentLocation.XCoordinate, CurrentLocation.YCoordinate - 1);
            if (HasLocationToSouth)
            {
                CurrentLocation = newLocation;
            }
        }

        private void CompleteQuestsAtLocation()
        {
            foreach (Quest quest in CurrentLocation.QuestsAvaibleHere)
            {
                QuestStatus questToComplete =
                    CurrentPlayer.Quests.FirstOrDefault(q => q.PlayerQuest.ID == quest.ID &&
                                                             !q.IsCompleted);
                if (questToComplete != null)
                {
                    if (CurrentPlayer.HasAllTheseItems(quest.ItemsToComplete))
                    {
                        // Remove the quest completion items from the player's inventory
                        foreach (ItemQuantity itemQuantity in quest.ItemsToComplete)
                        {
                            for (int i = 0; i < itemQuantity.Quantity; i++)
                            {
                                CurrentPlayer.RemoveItemFromInventory(CurrentPlayer.Inventory.First(item => item.ItemTypeID == itemQuantity.ItemID));
                            }
                        }
                        RaiseMessage("");
                        RaiseMessage($"Completaste la mision '{quest.Name}'");
                        // Give the player the quest rewards
                        CurrentPlayer.ExperiencePoints += quest.RewardExperiencePoints;
                        RaiseMessage($"Recibiste {quest.RewardExperiencePoints} puntos de exp");
                        CurrentPlayer.Gold += quest.RewardGold;
                        RaiseMessage($"Recibiste {quest.RewardGold} pesos");
                        foreach (ItemQuantity itemQuantity in quest.RewardItems)
                        {
                            GameItem rewardItem = ItemFactory.CreateGameItem(itemQuantity.ItemID);
                            CurrentPlayer.AddItemToInventory(rewardItem);
                            RaiseMessage($"Recibiste un {rewardItem.Name}");
                        }
                        // Mark the Quest as completed
                        questToComplete.IsCompleted = true;
                    }
                }
            }
        }

        private void GivePlayerQuestsAtLocation()
        {
            foreach (Quest quest in CurrentLocation.QuestsAvaibleHere)
            {
                if (!CurrentPlayer.Quests.Any(q => q.PlayerQuest.ID == quest.ID))
                {
                    CurrentPlayer.Quests.Add(new QuestStatus(quest));
                    RaiseMessage("");
                    RaiseMessage($"Recibiste la mision : '{quest.Name}'");
                    RaiseMessage(quest.Description);
                    RaiseMessage("Volve con :");
                    foreach (ItemQuantity itemQuantity in quest.ItemsToComplete)
                    {
                        RaiseMessage($"   {itemQuantity.Quantity} {ItemFactory.CreateGameItem(itemQuantity.ItemID).Name}");
                    }
                    RaiseMessage("Y recibiras:");
                    RaiseMessage($"   {quest.RewardExperiencePoints} puntos de exp.");
                    RaiseMessage($"   {quest.RewardGold} pesos");
                    foreach (ItemQuantity itemQuantity in quest.RewardItems)
                    {
                        RaiseMessage($"   {itemQuantity.Quantity} {ItemFactory.CreateGameItem(itemQuantity.ItemID).Name}");
                    }
                }
            }
        }

        private void GetMonsterAtLocation()
        {
            CurrentMonster = CurrentLocation.GetMonster();
        }

        private void RaiseMesage(string message)
        {
            OnMessageRaised?.Invoke(this, new GameMessageEventArgs(message));
        }

        public void AttackCurrentMonster()
        {
            if (CurrentWeapon == null)
            {
                RaiseMessage("Tenes que elegir un arma para atacar.");
                return;
            }
            // Determine damage to monster
            int damageToMonster = RandonNumberGenerator.SimpleNumberBetween(CurrentWeapon.MinimumDamage, CurrentWeapon.MaximumDamage);
            if (damageToMonster == 0)
            {
                RaiseMessage($"Le pifiaste a {CurrentMonster.Name}.");
            }
            else
            {
                CurrentMonster.HitPoints -= damageToMonster;
                RaiseMessage($"Le pegaste a {CurrentMonster.Name} por {damageToMonster} puntos.");
            }
            // If monster if killed, collect rewards and loot
            if (CurrentMonster.HitPoints <= 0)
            {
                RaiseMessage("");
                RaiseMessage($"Mataste a {CurrentMonster.Name}!");
                CurrentPlayer.ExperiencePoints += CurrentMonster.RewardExperiencePoints;
                RaiseMessage($"Recibis {CurrentMonster.RewardExperiencePoints} puntos de exp.");
                CurrentPlayer.Gold += CurrentMonster.RewardGold;
                RaiseMessage($"Recibis {CurrentMonster.RewardGold} pesos.");
                foreach (ItemQuantity itemQuantity in CurrentMonster.Inventory)
                {
                    GameItem item = ItemFactory.CreateGameItem(itemQuantity.ItemID);
                    CurrentPlayer.AddItemToInventory(item);
                    RaiseMessage($"Recibis {itemQuantity.Quantity} {item.Name}.");
                }
                // Get another monster to fight
                GetMonsterAtLocation();
            }
            else
            {
                // If monster is still alive, let the monster attack
                int damageToPlayer = RandonNumberGenerator.SimpleNumberBetween(CurrentMonster.MinimumDamage, CurrentMonster.MaximumDamage);
                if (damageToPlayer == 0)
                {
                    RaiseMessage("El monstruo ataca y le pifia");
                }
                else
                {
                    CurrentPlayer.HitPoints -= damageToPlayer;
                    RaiseMessage($"{CurrentMonster.Name} te pego {damageToPlayer} puntos.");
                }
                // If player is killed, move them back to their home.
                if (CurrentPlayer.HitPoints <= 0)
                {
                    RaiseMessage("");
                    RaiseMessage($"{CurrentMonster.Name} te mato.");
                    CurrentLocation = CurrentWorld.LocationAt(0, -1);
                    CurrentPlayer.HitPoints = CurrentPlayer.Level * 10;
                }
            }
        }
        private void RaiseMessage(string message)
        {
            OnMessageRaised?.Invoke(this, new GameMessageEventArgs(message));
        }
    }
}

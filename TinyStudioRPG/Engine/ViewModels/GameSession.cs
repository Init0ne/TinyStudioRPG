using Engine.Factories;
using Engine.Models;

namespace Engine.ViewModels
{
    public class GameSession
    {
        public World CurrentWorld { get; set; }
        public Player CurrentPlayer { get; set; }
        public Location CurrentLocation { get; set; }

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

            WorldFactory factory = new();
            CurrentWorld = factory.CreateWorld();

            //CurrentLocation = CurrentWorld.LocationAt(-2, -1);
            //CurrentLocation = CurrentWorld.LocationAt(-1, -1);
            CurrentLocation = CurrentWorld.LocationAt(0, -1);
        }
    }
}

using Engine.Models;

namespace Engine.ViewModels
{
    public class GameSession
    {
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

            CurrentLocation = new Location
            {
                Name = "Casa",
                XCoordinate = 0,
                YCoordinate = -1,
                Description = "Hogar tradicional porteño.",
                ImageName = "F:\\Programacion\\Git\\TinyStudioRPG\\TinyStudioRPG\\Engine\\Images\\Locations\\casa.png"
            };
        }
    }
}

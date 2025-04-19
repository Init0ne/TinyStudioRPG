using Engine.Models;

namespace Engine.ViewModels
{
    public class GameSession
    {
        Player CurrentPlater { get; set; }

        public GameSession()
        {
            CurrentPlater = new Player
            {
                Name = "Martín Fierro",
                Gold = 100,
            };
        }
    }
}

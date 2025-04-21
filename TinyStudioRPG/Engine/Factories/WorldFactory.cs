using Engine.Models;

namespace Engine.Factories
{
    internal class WorldFactory
    {
        internal World CreateWorld()
        {
            World newWorld = new();

            newWorld.AddLocation(-2, -1, "Campo de Soja", "Zona de cultivo.", "F:\\Programacion\\Git\\TinyStudioRPG\\TinyStudioRPG\\Engine\\Images\\Locations\\casa.png");

            newWorld.AddLocation(-1, -1, "Estancia Pampeana", "Una casa en el campo.", "F:\\Programacion\\Git\\TinyStudioRPG\\TinyStudioRPG\\Engine\\Images\\Locations\\casa.png");

            newWorld.AddLocation(0, -1, "Casa", "Hogar tradicional porteño.", "F:\\Programacion\\Git\\TinyStudioRPG\\TinyStudioRPG\\Engine\\Images\\Locations\\casa.png");

            return newWorld;
        }
    }
}

﻿using Engine.Models;

namespace Engine.Factories
{
    internal static class WorldFactory
    {
        internal static World CreateWorld()
        {
            World newWorld = new();

            newWorld.AddLocation(-2, -1, "Campo de Soja", "Zona de cultivo. Enemigos: Ratones Talpa.", "F:\\Programacion\\Git\\TinyStudioRPG\\TinyStudioRPG\\Engine\\Images\\Locations\\Casa_Principal.png");

            newWorld.LocationAt(-2, -1).AddMonster(2, 100);

            newWorld.AddLocation(-1, -1, "Estancia Pampeana", "NPC: Estanciero que pide ayuda con el ganado.", "F:\\Programacion\\Git\\TinyStudioRPG\\TinyStudioRPG\\Engine\\Images\\Locations\\Casa_Principal.png");
            newWorld.LocationAt(-1, -1).TraderHere = TraderFactory.GetTraderByName("Granjero Guillermo");

            newWorld.AddLocation(0, -1, "Casa", "Hogar tradicional porteño.", "F:\\Programacion\\Git\\TinyStudioRPG\\TinyStudioRPG\\Engine\\Images\\Locations\\Casa_Principal.png");

            newWorld.AddLocation(-1, 0, "Pulpería", "Comercio con productos locales: alpargatas, facones, termos.", "F:\\Programacion\\Git\\TinyStudioRPG\\TinyStudioRPG\\Engine\\Images\\Locations\\Casa_Principal.png");
            newWorld.LocationAt(-1, 0).TraderHere = TraderFactory.GetTraderByName("Susana");

            newWorld.AddLocation(0, 0, "Plaza de Mayo", "Punto central con la Pirámide de Mayo.", "F:\\Programacion\\Git\\TinyStudioRPG\\TinyStudioRPG\\Engine\\Images\\Locations\\Casa_Principal.png");

            newWorld.AddLocation(1, 0, "Puente de la Boca", "Transición a zonas peligrosas.", "F:\\Programacion\\Git\\TinyStudioRPG\\TinyStudioRPG\\Engine\\Images\\Locations\\Casa_Principal.png");

            newWorld.AddLocation(2, 0, "Monte Chaqueño", "Ambiente selvático. Enemigo: Araña Pollito.", "F:\\Programacion\\Git\\TinyStudioRPG\\TinyStudioRPG\\Engine\\Images\\Locations\\Casa_Principal.png");

            newWorld.LocationAt(2, 0).AddMonster(3, 100);

            newWorld.AddLocation(0, 1, "Puesto de Mate", "NPC: Mateador que da misiones para recolectar yerba y curembas.", "F:\\Programacion\\Git\\TinyStudioRPG\\TinyStudioRPG\\Engine\\Images\\Locations\\Casa_Principal.png");
            newWorld.LocationAt(0, 1).TraderHere =TraderFactory.GetTraderByName("Romualdo el yerbero");
            newWorld.LocationAt(0, 1).QuestsAvaibleHere.Add(QuestFactory.GetQuestByID(1));

            newWorld.AddLocation(0, 2, "Yerbal Misionero", "Plantaciones de yerba mate.", "F:\\Programacion\\Git\\TinyStudioRPG\\TinyStudioRPG\\Engine\\Images\\Locations\\Casa_Principal.png");

            newWorld.LocationAt(0, 2).AddMonster(1, 100);

            return newWorld;
        }
    }
}

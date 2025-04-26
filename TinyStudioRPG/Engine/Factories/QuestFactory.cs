using Engine.Models;

namespace Engine.Factories
{
    internal static class QuestFactory
    {
        private static readonly List<Quest> _quests = [];

        static QuestFactory()
        {
            //Declara los items necesarios para completar la quest y su recompensa
            List<ItemQuantity> itemsToComplete = [];
            List<ItemQuantity> rewardItems = [];

            itemsToComplete.Add(new ItemQuantity(9001, 5));
            rewardItems.Add(new ItemQuantity(1002, 1));

            //Crea la quest
            _quests.Add(new Quest(
                1,
                "Limpiar el yerbatero",
                "Eliminar los animales que están atacando el yerbatero",
                itemsToComplete,
                25, 
                10,
                rewardItems
                ));
        }

        internal static Quest GetQuestByID(int id) => _quests.FirstOrDefault(quest => quest.ID == id);
    }
}

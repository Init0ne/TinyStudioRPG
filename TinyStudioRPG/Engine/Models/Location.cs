using Engine.Factories;

namespace Engine.Models
{
    public class Location
    {
        public int XCoordinate { get; set; }
        public int YCoordinate { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageName { get; set; }
        public List<Quest> QuestsAvaibleHere { get; set; } = [];
        public List<MonsterEncounter> MonstersHere { get; set; } = [];

        public void AddMonster(int monsterID, int chanceOfEncountering)
        {
            if (MonstersHere.Exists(m => m.MonsterID == monsterID))
            {
                MonstersHere.First(m => m.MonsterID == monsterID)
                    .ChanceOfEncountering = chanceOfEncountering;
            }
            else
            {
                MonstersHere.Add(new MonsterEncounter(monsterID, chanceOfEncountering));
            }
        }

        public Monster GetMonster()
        {
            if (MonstersHere.Count == 0)
            {
                return null;
            }

            int totalChance = MonstersHere.Sum(m => m.ChanceOfEncountering);

            int randomNumber = RandonNumberGenerator.SimpleNumberBetween(1, totalChance);

            int runningTotal = 0;

            foreach (MonsterEncounter monsterEncounterin in MonstersHere)
            {
                runningTotal += monsterEncounterin.ChanceOfEncountering;

                if (randomNumber <= runningTotal)
                {
                    return MonsterFactory.GetMonster(monsterEncounterin.MonsterID);
                }
            }

            return MonsterFactory.GetMonster(MonstersHere.Last().MonsterID);
        }
    }
}

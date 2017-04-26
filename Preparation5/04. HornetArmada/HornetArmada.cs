namespace _04.HornetArmada
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class HornetArmada
    {
        public static void Main()
        {
            var numberOFLines = int.Parse(Console.ReadLine());
            var legionActivityDict = new Dictionary<string, long>();
            var legionSoldierCountDict = new Dictionary<string, Dictionary<string, long>>();

            for (int i = 0; i < numberOFLines; i++)
            {
                var inputParams = Console.ReadLine()
                    .Split(new char[] { '=', '-', '>', ':', ' ' }
                    , StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                var currentActivity = long.Parse(inputParams[0]);
                var currentLegionName = inputParams[1];
                var currentSoldierName = inputParams[2];
                var currentSoldierCount = long.Parse(inputParams[3]);

                if (!legionSoldierCountDict.ContainsKey(currentLegionName))
                {
                    legionSoldierCountDict[currentLegionName] = new Dictionary<string, long>();
                    legionActivityDict[currentLegionName] = currentActivity;
                }

                if (!legionSoldierCountDict[currentLegionName].ContainsKey(currentSoldierName))
                {
                    legionSoldierCountDict[currentLegionName][currentSoldierName] = 0;
                }

                legionSoldierCountDict[currentLegionName][currentSoldierName] += currentSoldierCount;

                if (legionActivityDict[currentLegionName] < currentActivity)
                {
                    legionActivityDict[currentLegionName] = currentActivity;
                }
            }

            var neededInfo = Console.ReadLine().Split('\\').ToArray();

            if (neededInfo.Length > 1)
            {
                var neededActivity = long.Parse(neededInfo[0]);
                var neededSoldierType = neededInfo[1];

                foreach (var legion in legionSoldierCountDict
                    .Where(x => x.Value.ContainsKey(neededSoldierType))
                    .OrderByDescending(x => x.Value[neededSoldierType]))
                {
                    if (legionActivityDict[legion.Key] < neededActivity)
                    {
                        foreach (var soldierType in legion.Value)
                        {
                            if (soldierType.Key == neededSoldierType)
                            {
                                Console.WriteLine($"{legion.Key} -> {soldierType.Value}");
                            }
                        }
                    }
                }
            }
            else
            {
                var neededSoldierType = neededInfo[0];

                foreach (var legion in legionActivityDict.OrderByDescending(x => x.Value))
                {
                    if (legionSoldierCountDict[legion.Key].ContainsKey(neededSoldierType))
                    {
                        Console.WriteLine($"{legion.Value} : {legion.Key}");
                    }
                }
            }
        }
    }
}
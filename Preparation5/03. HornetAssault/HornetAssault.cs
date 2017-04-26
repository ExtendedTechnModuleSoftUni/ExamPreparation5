namespace _03.HornetAssault
{
    using System;
    using System.Linq;

    public class HornetAssault
    {
        public static void Main()
        {
            var beehives = Console.ReadLine().Split().Select(long.Parse).ToArray();
            var hornets = Console.ReadLine().Split().Select(long.Parse).ToArray();

            long hornetsPower = hornets.Sum();
            var leftHornetIndex = 0;

            for (int i = 0; i < beehives.Length; i++)
            {
                var currentBeehive = beehives[i];

                if (leftHornetIndex > hornets.Length - 1)
                {
                    break;
                }

                if (currentBeehive >= hornetsPower)
                {
                    beehives[i] -= hornetsPower;
                    hornetsPower -= hornets[leftHornetIndex];
                    leftHornetIndex++;
                }
                else
                {
                    beehives[i] -= hornetsPower;

                    if (beehives[i] < 0)
                    {
                        beehives[i] = 0;
                    }
                }
            }

            if (beehives.Any(x => x > 0))
            {
                Console.WriteLine(string.Join(" ", beehives.Where(x => x > 0)));
            }
            else
            {
                Console.WriteLine(string.Join(" ", hornets.Skip(leftHornetIndex)));
            }
        }
    }
}
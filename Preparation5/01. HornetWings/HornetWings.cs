namespace _01.HornetWings
{
    using System;

    public class HornetWings
    {
        public static void Main()
        {
            var wingFlaps = long.Parse(Console.ReadLine());
            var distance = double.Parse(Console.ReadLine());
            var endurance = long.Parse(Console.ReadLine());

            var totalDistance = (wingFlaps / 1000) * distance;
            var totalFlapsSeconds = (wingFlaps / 100);
            var rest = (wingFlaps / endurance) * 5;

            Console.WriteLine($"{totalDistance:f2} m.");
            Console.WriteLine($"{totalFlapsSeconds + rest} s.");
        }
    }
}

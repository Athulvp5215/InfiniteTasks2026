using System;

namespace Assessment3
{
    class Team
    {
        public void Pointscalculation(int no_of_matches)
        {
            int sum = 0;

            for (int i = 1; i <= no_of_matches; i++)
            {
                Console.Write($"Enter score for match {i}: ");
                int score = Convert.ToInt32(Console.ReadLine());
                sum += score;
            }

            double average = (double)sum / no_of_matches;

            Console.WriteLine("\n--- Match Statistics ---");
            Console.WriteLine("Total Matches : " + no_of_matches);
            Console.WriteLine("Total Score   : " + sum);
            Console.WriteLine("Average Score : " + average);
        }
    }
}
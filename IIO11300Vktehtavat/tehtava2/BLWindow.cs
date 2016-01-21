using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tehtava2
{
    class BLWindow
    {
        public static string DrawRandom()
        {
            Random random = new Random();

            int[] randomNumbers = new int[7];

            for (int i = 0; i < randomNumbers.Length; i++)
            {
                randomNumbers[i] = random.Next(1, 40);
            }


            return string.Join(" ",randomNumbers);
        }
        public static string DrawViking()
        {
            Random random = new Random();

            int[] randomNumbers = new int[6];

            for (int i = 0; i < randomNumbers.Length; i++)
            {
                randomNumbers[i] = random.Next(1, 49);
            }

            return string.Join(" ", randomNumbers);
        }
        public static string DrawEuro()
        {
            Random random = new Random();

            int[] numbers = new int[5];
            int[] stars = new int[2];

            for (int i = 0; i < numbers.Length; i++)
            {
                numbers[i] = random.Next(1, 51);
            }
            for (int i = 0; i < stars.Length; i++)
            {
                stars[i] = random.Next(1, 9);
            }
            return string.Join(" ", numbers) + " " + string.Join(" ",stars);
        }
    }
}

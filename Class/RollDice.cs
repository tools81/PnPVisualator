using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace Pen_and_Paper_Visualator.Class
{
    class RollDice
    {
        private static List<int> cvOutcome = new List<int>();
        private static Random cvRandom = new Random();
        private static int cvRand;

        public static int Roll(int value1, int value2, int value3, int successValue, int rollAgainValue)
        {
            int lvTotal = value1 + value2 + value3;
            int lvSuccesses = 0;

            for (int idx = 0; idx < lvTotal; idx++)
            {
                cvRand = cvRandom.Next(1, 10);

                cvOutcome.Add(cvRand);

                if (cvRand >= rollAgainValue)
                {
                    RollAgain(rollAgainValue);
                }
            }

            foreach (int lvValue in cvOutcome)
            {
                if (lvValue >= successValue)
                {
                    lvSuccesses++;
                }
            }

            return lvSuccesses;
        }

        public static string GetOutcomeList()
        {
            string outcomeString = String.Join(",", cvOutcome);
            cvOutcome.Clear();
            return outcomeString;
        }

        private static void RollAgain(int RollAgainValue)
        {
            cvRand = cvRandom.Next(1, 10);

            cvOutcome.Add(cvRand);

            if (cvRand >= RollAgainValue)
            {
                RollAgain(RollAgainValue);
            }
        }
    }
}

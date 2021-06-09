using System;

namespace GradeBook
{
    public class Stats
    {
        public double Average
        {
            get
            {
                return Sum / Count;
            }
        }
        public double High;
        public double Low;
        public double Sum;
        public int Count;

        public void Add(double num)
        {
            Sum += num;
            Count++;
            High = Math.Max(num, High);
            Low = Math.Min(num, Low);
        }
        // constructor
        public Stats()
        {
            Sum = 0.0;
            Count = 0;
            High = double.MinValue; //lowest possible double value
            Low = double.MaxValue; //largest possible double value

        }

        public char Letter
        {
            get
            {
                //C# v7, pattern matching switch statement
                switch (Average)
                {
                    case var x when x >= 90.0:
                        return 'A';

                    case var x when x >= 80.0:
                        return 'B';

                    case var x when x >= 70.0:
                        return 'C';

                    case var x when x >= 60.0:
                        return 'D';

                    default:
                        return 'F';

                }
            }

        }



    }
}
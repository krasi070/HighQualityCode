namespace PerformanceOfOperations
{
    using System;
    using System.Diagnostics;

    class Program
    {
        static void Main()
        {
            int firstInt = 12;
            int secondInt = 1343;
            long firstLong = 63278;
            long secondLong = 23757862;
            double firstDouble = 2134.145;
            double secondDouble = 41412.21;
            decimal firstDecimal = 4312.423452m;
            decimal secondDecimal = 1.765782678826256m;

            //+--------------------------+------------------+------------------+------------------+------------------+------------------+------------------+------------------+
            //|                          |        +         |        -         |   ++ (prefix)    |   ++ (postfix)   |       += 1       |        *         |        /         |
            //+--------------------------+------------------+------------------+------------------+------------------+------------------+------------------+------------------+
            //| int                      | 00:00:00.0000800 | 00:00:00.0000700 | 00:00:00.0000800 | 00:00:00.0000800 | 00:00:00.0000800 | 00:00:00.0000800 | 00:00:00.0000800 |
            //| long                     | 00:00:00.0000800 | 00:00:00.0001000 | 00:00:00.0000800 | 00:00:00.0000800 | 00:00:00.0000800 | 00:00:00.0001000 | 00:00:00.0001200 |
            //| double                   | 00:00:00.0000800 | 00:00:00.0000800 | 00:00:00.0000800 | 00:00:00.0000800 | 00:00:00.0000800 | 00:00:00.0000700 | 00:00:00.0000800 |
            //| decimal 00:00:00.0002500 | 00:00:00.0002500 | 00:00:00.0005000 | 00:00:00.0003500 | 00:00:00.0001000 | 00:00:00.0005000 | 00:00:00.0007000 | 00:00:00.0007000 |
            //+--------------------------+------------------+------------------+------------------+------------------+------------------+------------------+------------------+


            //+-------------+------------------+
            //|             |      double      |
            //+-------------+------------------+
            //| Math.Sqrt() | 00:00:00.0001500 |
            //| Math.Log()  | 00:00:00.0002500 |
            //| Math.Sin()  | 00:00:00.0001500 |
            //+-------------+------------------+
        }

        //Test Int
        private static void TestIntegerAdding(int firstInt, int secondInt)
        {
            Stopwatch stopwatch = new Stopwatch();
            for (int i = 0; i < 1000; i++)
            {
                stopwatch.Start();
                int sum = firstInt + secondInt;
                stopwatch.Stop();
                Console.WriteLine(stopwatch.Elapsed);
            }
        }

        private static void TestIntegerSubtracting(int firstInt, int secondInt)
        {
            Stopwatch stopwatch = new Stopwatch();
            for (int i = 0; i < 1000; i++)
            {
                stopwatch.Start();
                int result = firstInt - secondInt;
                stopwatch.Stop();
                Console.WriteLine(stopwatch.Elapsed);
            }
        }

        private static void TestIntegerIncrementingPostFix(int integer)
        {
            Stopwatch stopwatch = new Stopwatch();
            for (int i = 0; i < 1000; i++)
            {
                stopwatch.Start();
                integer++;
                stopwatch.Stop();
                Console.WriteLine(stopwatch.Elapsed);
            }
        }

        private static void TestIntegerIncrementingPreFix(int integer)
        {
            Stopwatch stopwatch = new Stopwatch();
            for (int i = 0; i < 1000; i++)
            {
                stopwatch.Start();
                ++integer;
                stopwatch.Stop();
                Console.WriteLine(stopwatch.Elapsed);
            }
        }

        private static void TestIntegerAddingOne(int integer)
        {
            Stopwatch stopwatch = new Stopwatch();
            for (int i = 0; i < 1000; i++)
            {
                stopwatch.Start();
                integer += 1;
                stopwatch.Stop();
                Console.WriteLine(stopwatch.Elapsed);
            }
        }

        private static void TestIntegerMultiplying(int firstInt, int secondInt)
        {
            Stopwatch stopwatch = new Stopwatch();
            for (int i = 0; i < 1000; i++)
            {
                stopwatch.Start();
                int product = firstInt * secondInt;
                stopwatch.Stop();
                Console.WriteLine(stopwatch.Elapsed);
            }
        }

        private static void TestIntegerDividing(int firstInt, int secondInt)
        {
            Stopwatch stopwatch = new Stopwatch();
            for (int i = 0; i < 1000; i++)
            {
                stopwatch.Start();
                int result = firstInt / secondInt;
                stopwatch.Stop();
                Console.WriteLine(stopwatch.Elapsed);
            }
        }

        //Test Long
        private static void TestLongAdding(long firstLong, long secondLong)
        {
            Stopwatch stopwatch = new Stopwatch();
            for (int i = 0; i < 1000; i++)
            {
                stopwatch.Start();
                long sum = firstLong + secondLong;
                stopwatch.Stop();
                Console.WriteLine(stopwatch.Elapsed);
            }
        }

        private static void TestLongSubtracting(long firstLong, long secondLong)
        {
            Stopwatch stopwatch = new Stopwatch();
            for (int i = 0; i < 1000; i++)
            {
                stopwatch.Start();
                long result = firstLong - secondLong;
                stopwatch.Stop();
                Console.WriteLine(stopwatch.Elapsed);
            }
        }

        private static void TestLongIncrementingPostFix(long firstLong)
        {
            Stopwatch stopwatch = new Stopwatch();
            for (int i = 0; i < 1000; i++)
            {
                stopwatch.Start();
                firstLong++;
                stopwatch.Stop();
                Console.WriteLine(stopwatch.Elapsed);
            }
        }

        private static void TestLongIncrementingPreFix(long firstLong)
        {
            Stopwatch stopwatch = new Stopwatch();
            for (int i = 0; i < 1000; i++)
            {
                stopwatch.Start();
                ++firstLong;
                stopwatch.Stop();
                Console.WriteLine(stopwatch.Elapsed);
            }
        }

        private static void TestLongAddingOne(long firstLong)
        {
            Stopwatch stopwatch = new Stopwatch();
            for (int i = 0; i < 1000; i++)
            {
                stopwatch.Start();
                firstLong += 1;
                stopwatch.Stop();
                Console.WriteLine(stopwatch.Elapsed);
            }
        }

        private static void TestLongMultiplying(long firstLong, long secondLong)
        {
            Stopwatch stopwatch = new Stopwatch();
            for (int i = 0; i < 1000; i++)
            {
                stopwatch.Start();
                long result = firstLong * secondLong;
                stopwatch.Stop();
                Console.WriteLine(stopwatch.Elapsed);
            }
        }

        private static void TestLongDividing(long firstLong, long secondLong)
        {
            Stopwatch stopwatch = new Stopwatch();
            for (int i = 0; i < 1000; i++)
            {
                stopwatch.Start();
                long result = firstLong / secondLong;
                stopwatch.Stop();
                Console.WriteLine(stopwatch.Elapsed);
            }
        }

        //Test Double
        private static void TestDoubleAdding(double firstDouble, double secondDouble)
        {
            Stopwatch stopwatch = new Stopwatch();
            for (int i = 0; i < 1000; i++)
            {
                stopwatch.Start();
                double sum = firstDouble + secondDouble;
                stopwatch.Stop();
                Console.WriteLine(stopwatch.Elapsed);
            }
        }

        private static void TestDoubleSubtracting(double firstDouble, double secondDouble)
        {
            Stopwatch stopwatch = new Stopwatch();
            for (int i = 0; i < 1000; i++)
            {
                stopwatch.Start();
                double result = firstDouble - secondDouble;
                stopwatch.Stop();
                Console.WriteLine(stopwatch.Elapsed);
            }
        }

        private static void TestDoubleIncrementingPostFix(double firstDouble)
        {
            Stopwatch stopwatch = new Stopwatch();
            for (int i = 0; i < 1000; i++)
            {
                stopwatch.Start();
                firstDouble++;
                stopwatch.Stop();
                Console.WriteLine(stopwatch.Elapsed);
            }
        }

        private static void TestDoubleIncrementingPreFix(double firstDouble)
        {
            Stopwatch stopwatch = new Stopwatch();
            for (int i = 0; i < 1000; i++)
            {
                stopwatch.Start();
                ++firstDouble;
                stopwatch.Stop();
                Console.WriteLine(stopwatch.Elapsed);
            }
        }

        private static void TestDoubleAddingOne(double firstDouble)
        {
            Stopwatch stopwatch = new Stopwatch();
            for (int i = 0; i < 1000; i++)
            {
                stopwatch.Start();
                firstDouble += 1;
                stopwatch.Stop();
                Console.WriteLine(stopwatch.Elapsed);
            }
        }

        private static void TestDoubleMultiplying(double firstDouble, double secondDouble)
        {
            Stopwatch stopwatch = new Stopwatch();
            for (int i = 0; i < 1000; i++)
            {
                stopwatch.Start();
                double result = firstDouble * secondDouble;
                stopwatch.Stop();
                Console.WriteLine(stopwatch.Elapsed);
            }
        }

        private static void TestDoubleDividing(double firstDouble, double secondDouble)
        {
            Stopwatch stopwatch = new Stopwatch();
            for (int i = 0; i < 1000; i++)
            {
                stopwatch.Start();
                double result = firstDouble / secondDouble;
                stopwatch.Stop();
                Console.WriteLine(stopwatch.Elapsed);
            }
        }

        //Test Decimal

        private static void TestDecimalAdding(decimal firstDecimal, decimal secondDecimal)
        {
            Stopwatch stopwatch = new Stopwatch();
            for (int i = 0; i < 1000; i++)
            {
                stopwatch.Start();
                decimal result = firstDecimal + secondDecimal;
                stopwatch.Stop();
                Console.WriteLine(stopwatch.Elapsed);
            }
        }

        private static void TestDecimalSubtracting(decimal firstDecimal, decimal secondDecimal)
        {
            Stopwatch stopwatch = new Stopwatch();
            for (int i = 0; i < 1000; i++)
            {
                stopwatch.Start();
                decimal result = firstDecimal - secondDecimal;
                stopwatch.Stop();
                Console.WriteLine(stopwatch.Elapsed);
            }
        }

        private static void TestDecimalIncrementingPostFix(decimal firstDecimal)
        {
            Stopwatch stopwatch = new Stopwatch();
            for (int i = 0; i < 1000; i++)
            {
                stopwatch.Start();
                firstDecimal++;
                stopwatch.Stop();
                Console.WriteLine(stopwatch.Elapsed);
            }
        }

        private static void TestDecimalIncrementingPreFix(decimal firstDecimal)
        {
            Stopwatch stopwatch = new Stopwatch();
            for (int i = 0; i < 1000; i++)
            {
                stopwatch.Start();
                ++firstDecimal;
                stopwatch.Stop();
                Console.WriteLine(stopwatch.Elapsed);
            }
        }

        private static void TestDecimalAddingOne(decimal firstDecimal)
        {
            Stopwatch stopwatch = new Stopwatch();
            for (int i = 0; i < 1000; i++)
            {
                stopwatch.Start();
                firstDecimal += 1;
                stopwatch.Stop();
                Console.WriteLine(stopwatch.Elapsed);
            }
        }

        private static void TestDecimalMultiplying(decimal firstDecimal, decimal secondDecimal)
        {
            Stopwatch stopwatch = new Stopwatch();
            for (int i = 0; i < 1000; i++)
            {
                stopwatch.Start();
                decimal result = firstDecimal * secondDecimal;
                stopwatch.Stop();
                Console.WriteLine(stopwatch.Elapsed);
            }
        }

        private static void TestDecimalDividing(decimal firstDecimal, decimal secondDecimal)
        {
            Stopwatch stopwatch = new Stopwatch();
            for (int i = 0; i < 1000; i++)
            {
                stopwatch.Start();
                decimal result = firstDecimal / secondDecimal;
                stopwatch.Stop();
                Console.WriteLine(stopwatch.Elapsed);
            }
        }

        //Test double math methods

        private static void TestDoubleSqrt(double number)
        {
            Stopwatch stopwatch = new Stopwatch();
            for (int i = 0; i < 1000; i++)
            {
                stopwatch.Start();
                Math.Sqrt(number);
                stopwatch.Stop();
                Console.WriteLine(stopwatch.Elapsed);
            }
        }

        private static void TestDoubleLog(double number)
        {
            Stopwatch stopwatch = new Stopwatch();
            for (int i = 0; i < 1000; i++)
            {
                stopwatch.Start();
                Math.Log(number);
                stopwatch.Stop();
                Console.WriteLine(stopwatch.Elapsed);
            }
        }

        private static void TestDoubleSin(double number)
        {
            Stopwatch stopwatch = new Stopwatch();
            for (int i = 0; i < 1000; i++)
            {
                stopwatch.Start();
                Math.Sin(number);
                stopwatch.Stop();
                Console.WriteLine(stopwatch.Elapsed);
            }
        }
    }
}

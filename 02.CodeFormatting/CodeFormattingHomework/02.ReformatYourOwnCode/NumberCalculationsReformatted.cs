using System;

public class NumberCalculations
{
    public static void Main()
    {
        Console.Write("Enter a set of numbers(double): ");
        string firstSetOfNumbers = Console.ReadLine();

        double[] doubleNumbers = new double[firstSetOfNumbers.Split().Length];
        for (int i = 0; i < doubleNumbers.Length; i++)
        {
            doubleNumbers[i] = double.Parse(firstSetOfNumbers.Split()[i]);
        }

        Console.WriteLine("Min: {0};Max: {1};Average: {2};Sum: {3};Product: {4}",
            GetMin(doubleNumbers),
            GetMax(doubleNumbers),
            GetAverage(doubleNumbers),
            GetSum(doubleNumbers),
            GetProduct(doubleNumbers));

        Console.Write("Enter the second set of numbers(decimal): ");
        string secondSetOfNumbers = Console.ReadLine();

        decimal[] decimalNumbers = new decimal[secondSetOfNumbers.Split().Length];
        for (int i = 0; i < decimalNumbers.Length; i++)
        {
            decimalNumbers[i] = decimal.Parse(secondSetOfNumbers.Split()[i]);
        }

        Console.WriteLine("Min: {0};Max: {1};Average: {2};Sum: {3};Product: {4}",
            GetMin(decimalNumbers),
            GetMax(decimalNumbers),
            GetAverage(decimalNumbers),
            GetSum(decimalNumbers), 
            GetProduct(decimalNumbers));
    }

    private static double GetMin(double[] numbers)
    {
        double min = numbers[0];

        for (int i = 0; i < numbers.Length; i++)
        {
            if (min > numbers[i])
            {
                min = numbers[i];
            }
        }

        return min;
    }

    private static decimal GetMin(decimal[] numbers)
    {
        decimal min = numbers[0];

        for (int i = 0; i < numbers.Length; i++)
        {
            if (min > numbers[i])
            {
                min = numbers[i];
            }
        }

        return min;
    }

    private static double GetMax(double[] numbers)
    {
        double max = numbers[0];

        for (int i = 0; i < numbers.Length; i++)
        {
            if (max < numbers[i])
            {
                max = numbers[i];
            }
        }

        return max;
    }

    private static decimal GetMax(decimal[] numbers)
    {
        decimal max = numbers[0];

        for (int i = 0; i < numbers.Length; i++)
        {
            if (max < numbers[i])
            {
                max = numbers[i];
            }
        }

        return max;
    }

    private static double GetAverage(double[] numbers)
    {
        double average = 0;

        foreach (var number in numbers)
        {
            average += number;
        }

        average /= numbers.Length;

        return average;
    }

    private static decimal GetAverage(decimal[] numbers)
    {
        decimal average = 0;

        foreach (var number in numbers)
        {
            average += number;
        }

        average /= numbers.Length;

        return average;
    }

    private static double GetSum(double[] numbers)
    {
        double sum = 0;

        foreach (var number in numbers)
        {
            sum += number;
        }

        return sum;
    }

    private static decimal GetSum(decimal[] numbers)
    {
        decimal sum = 0;

        foreach (var number in numbers)
        {
            sum += number;
        }

        return sum;
    }

    private static double GetProduct(double[] numbers)
    {
        double product = 1;

        foreach (var number in numbers)
        {
            product *= number;
        }

        return product;
    }

    private static decimal GetProduct(decimal[] numbers)
    {
        decimal product = 1;

        foreach (var number in numbers)
        {
            product *= number;
        }

        return product;
    }
}

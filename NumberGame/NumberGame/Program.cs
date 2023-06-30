using System.Linq.Expressions;
using System.Runtime.CompilerServices;

namespace NumberGame
{
   
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Welcome to my game! Lets do some math!");
                StartSequence();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.WriteLine("Program is complete.");
            }
        }
        static void StartSequence()
        {
            Console.WriteLine("Enter a number greater than zero");
            try
            {
                int number = Convert.ToInt32(Console.ReadLine());
                if (number > 0)
                {
                    int[] arr = new int[number];
                    Populate(arr);
                    int sum = GetSum(arr);
                    int value = GetProduct(arr, sum);
                    decimal q = GetQuotient(value);
                    Console.WriteLine($"Your array is size: {number}");
                    Console.Write("The numbers in the array are ");
                    foreach (int item in arr)
                    {
                        Console.Write(item + ",");

                    }
                    Console.WriteLine();
                    Console.WriteLine($"The sum of the array is {sum}");
                    int chosenNumber = value / sum;
                    Console.WriteLine($"{sum} * {chosenNumber} = {value}");
                    decimal mystery = value / q;
                    Console.WriteLine($"{value} / {mystery} =  {q}");
                }
                else
                {
                    Console.WriteLine("Wrong input");
                }

            }
            catch (OverflowException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (FormatException ex)
            {
                Console.WriteLine(ex.Message);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }



        }
        static Array Populate(int[] arr)
        {


            for (int i = 0; i < arr.Length; i++)
            {
                Console.WriteLine($"Please enter number :{i + 1} of {arr.Length}");
                arr[i] = Convert.ToInt32(Console.ReadLine());
            }

            return arr;
        }

        static int GetSum(int[] arr)
        {
            int sum = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                sum = sum + arr[i];
            }
            if (sum < 20)
            {
                throw new Exception($"Value of {sum} is too low");
            }

            return sum;

        }
        static int GetProduct(int[] arr, int sum)
        {
            try
            {
                int product = 0;
                Console.WriteLine($"Select number between 1 to {arr.Length}");
                int ramdomNumber = Convert.ToInt32(Console.ReadLine());

                if (ramdomNumber > 0 && ramdomNumber <= arr.Length)
                    product = sum * arr[ramdomNumber - 1];

                return product;
            }
            catch (IndexOutOfRangeException ex)
            {
                Console.WriteLine(ex.Message);
            }
            return 0;
        }
        static decimal GetQuotient(int value)
        {
            try
            {
                Console.WriteLine($"Please select random number to divide the product {value} by it");
                int num = Convert.ToInt32(Console.ReadLine());
                decimal result = decimal.Divide(value, num);

                return result;
            }
            catch (DivideByZeroException e)
            {

                Console.WriteLine(e.Message);
            }
            return 0;
        }


    }
}
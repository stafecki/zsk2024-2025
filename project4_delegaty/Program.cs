using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project4_delegaty
{
    internal class Program
    {
        public delegate float Operation(float x, float y);
        public static float Add(float x, float y)
        {
            return x + y;
        }
        public static float Subtract(float x, float y)
        {
            return x - y;
        }
        public static float Divide(float x, float y)
        {
            return x / y;
        }
        public static float Multiply(float x, float y)
        {
            return x * y;
        }
        public static void DisplayResult(Operation op, float x, float y)
        {
            float result;
            if(op.Method.Name == "Divide" && y == 0)
            {
                Console.WriteLine("Nie wolno dzielić przez 0");
                result = 0;
            }
            else
            {
                try
                {
                    result = op(x, y);
                    Console.WriteLine($"Wynik operacji {op.Method.Name} na liczbach {x} i {y} wynosi: {result}");
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Błąd: {e.Message}");
                    result = 0;
                }
            }
        }
        public static float GetFloatFromUser(string prompt)
        {
            Console.Write(prompt);
            float input = 0;
            while (true)
            {
                if (float.TryParse(Console.ReadLine(), out input))
                {
                    break;
                }
                else
                {
                    Console.Write("Podano nieprawidłowe dane, spróbuj ponownie: ");
                }
            }
            return input;
        }
        public static void Main(string[] args)
        {
            float a = GetFloatFromUser("Podaj pierwszą liczbe: ");
            float b = GetFloatFromUser("Podaj drugą liczbę: ");

            Operation adding = new Operation(Add);
            Operation subtracting = new Operation(Subtract);
            Operation dividing = new Operation(Divide);
            Operation multiplying = new Operation(Multiply);

            DisplayResult(adding, a, b);
            DisplayResult(subtracting, a, b);
            DisplayResult(dividing, a, b);
            DisplayResult(multiplying, a, b);

            Console.ReadKey();
        }
    }
}

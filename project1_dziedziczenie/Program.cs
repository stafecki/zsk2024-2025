using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace project1_dziedziczenie
{
    #region Klasy
    class Shape
    {
        public virtual float CalculateArea()
        {
            return 0;
        }
        public virtual float CalculatePerimeter()
        {
            return 0;
        }
    }

    class Rectangle : Shape
    {
        private float width;
        private float height;

        public void SetDimensions(float w, float h)
        {
            width = w;
            height = h;
        }

        public override float CalculateArea()
        {
            return width * height;
        }

        public override float CalculatePerimeter()
        {
            return 2 * width + 2 * height;
        }
    }

    class Circle : Shape
    {
        private float radius;
        public Circle(float r)
        {
            radius = r;
        }
        public void setRadius(float r)
        {
            radius = r;
        }

        public override float CalculateArea()
        {
            return (float)Math.Round(Math.PI * Math.Pow(radius, 2), 2);
        }

        public override float CalculatePerimeter()
        {
            return (float)Math.Round(2 * Math.PI * radius, 2);
        }
    }
    class Triangle : Shape
    {
        private float sideA;
        private float sideB;
        private float sideC;

        public Triangle(float sideA, float sideB, float sideC)
        {
            this.sideA = sideA;
            this.sideB = sideB;
            this.sideC = sideC;
        }

        public override float CalculateArea()
        {
            float s = (sideA + sideB + sideC) / 2;
            return (float)Math.Sqrt(s*(s-sideA)*s*(s-sideB)*s*(s-sideC));
        }

        public override float CalculatePerimeter()
        {
            return sideA + sideB + sideC;
        }
    }
    #endregion
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Wybierz kształt do obliczenia: ");
                Console.WriteLine("1. Prostokąt");
                Console.WriteLine("2. Koło");
                Console.WriteLine("3. Trójkąt");
                Console.WriteLine("4. Trapez");
                Console.WriteLine("5. Kula");
                Console.WriteLine("6. Wyjście");
                Console.Write("Twój wybór: ");
                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        Rectangle rect = new Rectangle();
                        Console.Write("Podaj szerokość: ");
                        float rectWidth = float.Parse(Console.ReadLine());
                        Console.Write("Podaj wysokość: ");
                        float rectHeight = float.Parse(Console.ReadLine());
                        rect.SetDimensions(rectWidth, rectHeight);
                        Console.WriteLine("Powierzchnia prostokąta: {0}", rect.CalculateArea());
                        Console.WriteLine("Obwód prostokąta: {0}", rect.CalculatePerimeter());
                        break;
                    case 2:
                        float circleRadius = GetValidInput("Podaj promień: ");
                        Circle circ = new Circle(circleRadius);
                        Console.WriteLine("Powierzchnia koła: {0}", circ.CalculateArea());
                        Console.WriteLine("Obwód koła: {0}", circ.CalculatePerimeter());
                        break;
                    case 3:
                        float sideA = GetValidInput("Podaj długość boku A: ");
                        float sideB = GetValidInput("Podaj długość boku B: ");
                        float sideC = GetValidInput("Podaj długość boku C: ");
                        if (IsValidTriangle(sideA, sideB, sideC))
                        {
                            Triangle triangle = new Triangle(sideA, sideB, sideC);
                            Console.WriteLine("Powierzchnia trójkąta: {0}", triangle.CalculateArea());
                            Console.WriteLine("Obwód trójkąta: {0}", triangle.CalculatePerimeter());
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Podane długości boków nie tworzą trójkąta. Spróbuj ponownie");
                            Console.ResetColor();
                        }
                        break;
                    case 6:
                        return;

                    default:
                        Console.WriteLine("Nieprawidłowy wybór. Spróbuj ponownie");
                        break;
                }
            }
            /*Rectangle rect = new Rectangle();
            rect.SetDimensions(2.0f, 2.0f);

            Console.WriteLine("Pole prostokąta wynosi: {0}", rect.CalculateArea());

            Circle circ = new Circle();
            circ.setRadius(2.4f);
            Console.WriteLine("Pole koła wynosi: {0}", circ.CalculateArea());
            Console.WriteLine("Obwód koła wynosi {0}", circ.CalculatePerimeter());*/
            Console.ReadKey();
        }

        private static bool IsValidTriangle(float sideA, float sideB, float sideC)
        {
            return (sideA + sideB > sideC) && (sideB + sideC > sideA) && (sideA + sideC > sideB);
        }

        private static float GetValidInput(string prompt)
        {
            float input;
            while (true)
            {
                Console.Write(prompt);
                if (float.TryParse(Console.ReadLine(), out input) && input > 0)
                {
                    return input;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Nieprawidłowe dane, spróbuj ponownie.");
                    Console.ResetColor();
                }
            }
        }

        /*static public int GetUserInputInt()
        {
            int input;

            while(true)
            {
                Console.Write("Podaj wartość(int): ");
                if (int.TryParse(Console.ReadLine(), out input))
                {
                    return input;
                }
                else
                {
                    Console.WriteLine("Nieprawidłowy format danych");
                }
            }
        }*/


    }
}

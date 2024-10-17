using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project2_kompozycja_shape
{
    public abstract class Shape
    {
        public abstract double CalculateArea();
        public abstract double CalculatePerimeter();
    }
    public class Square : Shape
    {
        public double Side { get; set; }
        public Square(double side)
        {
            Side = side;
        }
        public override double CalculateArea()
        {
            return Side * Side;
        }
        public override double CalculatePerimeter()
        {
            return 4* Side;
        }
    }
    public class Rectangle : Shape
    {
        public double SideA { get; set; }
        public double SideB { get; set; }
        public Rectangle(double sideA, double sideB)
        {
            SideA = sideA;
            SideB = sideB;
        }
        public override double CalculateArea()
        {
            return SideA * SideB;
        }
        public override double CalculatePerimeter()
        {
            return 2 * SideA + 2 * SideB;
        }
    }
    public class Geometry
    {
        public List<Shape> Shapes { get; set; }
        public Geometry()
        {
            Shapes = new List<Shape>();
        }
        public void AddShape(Shape shape)
        {
            Shapes.Add(shape);
        }
        public double CalculateTotalArea()
        {
            double totalArea = 0;
            foreach (Shape shape in Shapes)
            {
                totalArea += shape.CalculateArea();
            }
            return totalArea;
        }

        public double CalcutaleTotalPerimeter()
        {
            double totalPerimeter = 0;
            foreach (Shape shape in Shapes)
            {
                totalPerimeter += shape.CalculatePerimeter();
            }
            return totalPerimeter;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Geometry geometry = new Geometry();
            geometry.AddShape(new Square(4));
            geometry.AddShape(new Rectangle(4,2));

            Console.WriteLine($"Całkowite pole: {geometry.CalculateTotalArea()}");

            Console.WriteLine($"Całkowity obwod: {geometry.CalcutaleTotalPerimeter()}");

            Console.ReadKey();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
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
    }

	class Circle : Shape
    {
		private float radius;
		public void setRadius(float r)
        {
			radius = r;
        }

        public override float CalculateArea()
        {
            return (float)Math.Round(Math.PI * Math.Pow(radius,2),2);
        }
    }

    #endregion
    class Program
	{
		static void Main(string[] args)
		{
			Rectangle rect = new Rectangle();
            rect.SetDimensions(2.0f, 2.0f);

            Console.WriteLine("Pole prostokąta wynosi: {0}", rect.CalculateArea());

            Circle circ = new Circle();
            circ.setRadius(2.4f);
            Console.WriteLine("Pole koła wynosi: {0}", circ.CalculateArea());
			Console.ReadKey();
		}
	}
}

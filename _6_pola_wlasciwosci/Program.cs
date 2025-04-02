namespace _6_pola_wlasciwosci
{
    enum Color
    {
        Black,
        White,
        Red
    }

    enum InteriorColor
    {
        Black,
        White,
        Brown
    }
    class Car
    {
        //pola
        public string brand;
        public string model; // tak nie powinno się robic

        //pola prywatne
        private int _productionYear;
        private decimal _price;
        private string _color;
        private string _interiorColor;


        public int ProductionYear
        {
            get { return _productionYear; }
            set
            {
                if (value > 1886 && value <= DateTime.Now.Year) _productionYear = value;
                else throw new ArgumentException("Rok produkcji powinien byc wiekszy niz 1886 i mniejszy niż obecny");
            }
        }
        
        public decimal Price
        {
            get { return _price; }
            set
            {
                if (value > 0) _price = value;
                else throw new ArgumentException("Cena nie może być mniejsza niz 0");
            }
        }

        public string Color
        {
            get { return _color; }
            set
            {
                if (string.IsNullOrEmpty(value)) throw new ArgumentException("Kolor musi być ustalony");
                else if (Enum.IsDefined(typeof(Color), value)) throw new ArgumentException($"Kolor musi być w {string.Join(", ", Enum.GetNames(typeof(Color)))}");
                _color = value;

            }
        }

        public string InteriorColor
        {
            get { return _interiorColor; }
            set
            {
                if (string.IsNullOrEmpty(value)) throw new ArgumentException("Kolor musi być ustalony");
                else if (Enum.IsDefined(typeof(InteriorColor), value)) throw new ArgumentException($"Kolor musi być w {string.Join(", ", Enum.GetNames(typeof(InteriorColor)))}");
                _interiorColor = value;

            }
        }

        public Car(string brand, string model, int productionYear, int price, string color, string interiorColor)
        {
            try
            {
                this.brand = brand;
                this.model = model;
                ProductionYear = productionYear;
                Price = price;
                Color = color;
                InteriorColor = interiorColor;
                ProductionYear = productionYear;
                Price = price;
                Color = color;
                InteriorColor = interiorColor;
            }
            catch(ArgumentException e)
            {
                Console.WriteLine($"Błąd podczas utworzenia ");
            } 
        }

        public Car()
        {
            brand = "Nieznana";
            model = "Nieznany";
            _productionYear = 2000;
            _price = 0m;
        }

        public override string ToString()
        {
            return $"Marka: {brand}, model: {model}, rok produkcji: {ProductionYear}, cena: {Price}, kolor: {Color}, kolor wnętrza: {InteriorColor}";
        }
    }

    internal class Program
    {
        
    }
}

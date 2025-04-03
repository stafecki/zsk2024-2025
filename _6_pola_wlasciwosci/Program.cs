namespace _6_pola_wlasciwosci
{
    //enum Color
    //{
    //    Black,
    //    White,
    //    Red
    //}

    enum InteriorColor
    {
        Black,
        Gray,
        Beige
    }
    class Car
    {
        //pola
        public string brand;
        public string model; // tak nie powinno się robic, nie ma zadnej walidacji

        //pola prywatne
        private int _productionYear;
        private decimal _price;
        private string _carColor;
        private string _carInteriorColor;


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
                if (value >= 0) _price = value;
                else throw new ArgumentException("Cena nie może być mniejsza niz 0");
            }
        }

        public string CarColor
        {
            get { return _carColor; }
            set
            {
                string[] allowedColors = ["black", "white", "red"];
                if (string.IsNullOrWhiteSpace(value)) throw new ArgumentException("Kolor musi być ustalony");
                else if (!allowedColors.Contains(value.ToLower())) throw new ArgumentException($"Kolor musi być jednym z tych: {string.Join(", ", allowedColors)}");
                _carColor = value;

            }
        }

        public string CarInteriorColor
        {
            get { return _carInteriorColor; }
            set
            {
                if (string.IsNullOrWhiteSpace(value)) throw new ArgumentNullException("Wartość nie powinna być pusta lub być białym znakiem");
                else if (!Enum.TryParse<InteriorColor>(value, true, out _)) 
                {
                    string allowedColorsList = string.Join(", ", Enum.GetNames(typeof(InteriorColor))).ToLower();
                    throw new ArgumentException($"Kolor wnętrza musi być jednym z {allowedColorsList}");
                };
                _carInteriorColor = value;

            }
        }

        public Car(string brand, string model, int productionYear, decimal price, string color, string interiorColor)
        {
            this.brand = brand;
            this.model = model;
            ProductionYear = productionYear;
            Price = price;
            CarColor = color;
            CarInteriorColor = interiorColor;
            ProductionYear = productionYear;
            Price = price;
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
            return $"Marka: {brand}, model: {model}, rok produkcji: {ProductionYear}, cena: {Price:C}, kolor: {CarColor}, kolor wnętrza: {CarInteriorColor}";
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            //Car car1 = new Car("Toyota", "Yaris", 2000, 2000.99M, "black", "red");// bez try catcha
            //Console.WriteLine(car1.ToString());
            
            try
            {
                Car car2 = new Car("BMW", "17", 2024, 750000M, "white", "beige");
                //car2.Price = -3;
                Console.WriteLine(car2.ToString());
            }
            catch (ArgumentException e)
            {
                Console.WriteLine($"Błąd: {e.Message}");
            }
        }
    }
}

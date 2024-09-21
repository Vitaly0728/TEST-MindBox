namespace TestMindbox
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Square> shapes = new List<Square>
            {            
            new Circle(3),
            new Triangle(3, 4, 5)            
            };

            foreach (var shape in shapes)
            {
                Console.WriteLine($"Площадь: {shape.CalculateArea()}");
            }
        }
    }

    public class Circle : Square
    {
        private double _radiusCircle;
        public Circle(double radius)
        {
            if (radius < 0)
            {
                throw new ArgumentException("Радиус круга не может быть отрицательным");                  
            }
            _radiusCircle = radius;
        }
        public double CalculateArea()
        {
            return Math.PI * _radiusCircle * _radiusCircle;
        }
    }

    public class Triangle : Square
    {
        private double _firstSide;
        private double _secondSide;
        private double _thirdSide;

        public Triangle(double firstSide, double secondSide, double thirdSide)
        {
            if (firstSide <= 0 || secondSide <= 0 || thirdSide <= 0)
            {
                throw new ArgumentException("Стороны треугольника должны быть положительными.");
            }
            if (firstSide + secondSide <= thirdSide || secondSide + thirdSide <= firstSide
               || firstSide + thirdSide <= secondSide)
            {
                throw new ArgumentException("Стороны не могут образовать треугольник.");
            }

            if (IsRightTriangle(firstSide, secondSide, thirdSide)) Console.WriteLine("Треугольник прямоугольный");
            
            else Console.WriteLine("Треугольник не прямоугольный");                
            
            _firstSide = firstSide;
            _secondSide = secondSide;
            _thirdSide = thirdSide;
        }
        private bool IsRightTriangle(double firstSide, double secondSide, double thirdSide)
        {
            double firstSquared = firstSide * firstSide;
            double secondSquared = secondSide * secondSide;
            double thirdSquared = thirdSide * thirdSide;

            return (firstSquared + secondSquared == thirdSquared) ||
                   (secondSquared + thirdSquared == firstSquared) ||
                   (firstSquared + thirdSquared == secondSquared);
        }
        public double CalculateArea()
        {
            double perimeterp = (_firstSide+_secondSide+_thirdSide) / 2;
            return Math.Sqrt(perimeterp * (perimeterp - _firstSide) * (perimeterp - _secondSide)
            * (perimeterp - _thirdSide));
        }
    }
    public interface Square
    {
        double CalculateArea();
    }
    
}

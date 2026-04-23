namespace CSharpAssignment
{
    class DistanceTest
    {
        public static void Run()
        {
            Distance d1 = new Distance { Kilometer = 100 };
            Distance d2 = new Distance { Kilometer = 50 };
            Distance d3 = new Distance();

            d3.AddDistance(d1, d2);
            d3.Display();
        }
    }
}
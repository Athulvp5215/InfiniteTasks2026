namespace CSharpAssignment
{
    class Distance
    {
        public int Kilometer;

        public void AddDistance(Distance d1, Distance d2)
        {
            Kilometer = d1.Kilometer + d2.Kilometer;
        }

        public void Display()
        {
            System.Console.WriteLine("Total Distance: " + Kilometer + " km");
        }
    }
}
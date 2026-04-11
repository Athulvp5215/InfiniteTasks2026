using System;
using TravelConcessionLibrary;

namespace Assignment7
{
    class Program
    {
        const double BaseFare = 500;

        static void Main(string[] args)
        {
            Console.WriteLine("Enter Passenger Name:");
            string passengerName = Console.ReadLine();

            Console.WriteLine("Enter Passenger Age:");
            int passengerAge = int.Parse(Console.ReadLine());

            Concession travelConcession = new Concession();
            string concessionDetails =
                travelConcession.CalculateConcession(passengerAge, BaseFare);

            Console.WriteLine("\nPassenger Name: " + passengerName);
            Console.WriteLine(concessionDetails);

            Console.ReadLine();
        }
    }
}
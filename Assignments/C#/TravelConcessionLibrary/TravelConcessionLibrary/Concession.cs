using System;

namespace TravelConcessionLibrary
{
    public class TravelDiscount
    {
        public string GetConcessionDetails(int passengerAge, double fareAmount)
        {
            if (passengerAge <= 5)
            {
                return "Little Champs - Free Ticket";
            }
            else if (passengerAge > 60)
            {
                double discountedFare = fareAmount * 0.70;
                return "Senior Citizen - Fare after concession: " + discountedFare;
            }
            else
            {
                return "Ticket Booked - Fare: " + fareAmount;
            }
        }
    }
}
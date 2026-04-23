using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace TravelConcession
{

    public class Concession
    {
        public string CalculateConcession(int age, decimal totalFare)
        {
            if (age <= 5)
            {
                return "Little Champs - Free Ticket";
            }
            else if (age > 60)
            {
                decimal concessionAmount = totalFare * 0.30m;
                decimal discountedFare = totalFare - concessionAmount;
                return $"Senior Citizen - Fare after concession: {discountedFare}";
            }
            else
            {
                return $"Ticket Booked - Fare: {totalFare}";
            }
        }
    }

}
using System;

namespace AssignmentProject
{
    public class NumberValidator
    {
        public static void CheckNumber(int number)
        {
            if (number < 0)
                throw new ArgumentException("Number cannot be negative");
        }
    }
}
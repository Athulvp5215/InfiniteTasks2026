using System;
using System.IO;

namespace Assessment3
{
    class FileAppend
    {
        public void AppendToFile()
        {
            string filePath = "AthulTextFile.txt";

            using (StreamWriter sw = new StreamWriter(filePath, true))
            {
                sw.WriteLine("Appending text on: " + DateTime.Now);
            }

            Console.WriteLine("\nText appended successfully.");
        }
    }
}
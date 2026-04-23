using System;
using ReportGeneratorApp.Interface;

namespace ReportGeneratorApp.Concrete
{
    public class TabularReportGenerator : IReportGenerator
    {
        string reportFormat = "tabular";

        public void GenerateReport()
        {
            Console.WriteLine("Generating " + reportFormat + " report...");
        }
    }
}
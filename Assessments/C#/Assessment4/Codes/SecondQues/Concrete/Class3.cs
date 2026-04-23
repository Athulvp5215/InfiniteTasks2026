using System;
using ReportGeneratorApp.Interface;

namespace ReportGeneratorApp.Concrete
{
    public class SummaryReportGenerator : IReportGenerator
    {
        string reportCategory = "summary";

        public void GenerateReport()
        {
            Console.WriteLine("Generating " + reportCategory + " report...");
        }
    }
}

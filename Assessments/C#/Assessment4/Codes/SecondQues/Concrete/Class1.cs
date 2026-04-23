using System;
using ReportGeneratorApp.Interface;

namespace ReportGeneratorApp.Concrete
{
    public class ChartReportGenerator : IReportGenerator
    {
        string reportType = "chart-based";

        public void GenerateReport()
        {
            Console.WriteLine("Generating " + reportType + " report...");
        }
    }
}
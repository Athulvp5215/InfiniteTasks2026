using ReportGeneratorApp.Interface;

namespace ReportGeneratorApp.Abstract
{
    public abstract class ReportFactory
    {
        protected string factoryType = "Report";

        public abstract IReportGenerator CreateReport();
    }
}
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using System.Reflection;

namespace ExtentReporting2
{
    public class ExtentReporting
    {
        private static ExtentReports extentReports;
        private static ExtentTest extentTest;
        public readonly static string reportPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"..\..\..\..\results\";

        private static ExtentReports Reporter()
        {
            //var path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"..\..\..\..\results\";


            if (extentReports == null)
            {
                Directory.CreateDirectory(reportPath);
                extentReports = new ExtentReports();
                var reporter = new ExtentSparkReporter(reportPath + "ExtentReport.html");
                extentReports.AttachReporter(reporter);
            }
            return extentReports;
        }

        public static void CreateTest(string testName)
        {
            extentTest = Reporter().CreateTest(testName);
        }

        public static void EndReporting()
        {
            Reporter().Flush();
        }
        public static void LogInfo(string info)
        {
            extentTest?.Info(info);
        }

        public static void LogPass(string error)
        {
            extentTest?.Pass(error);
        }

        public static void LogFail(string error)
        {
            extentTest?.Fail(error);
        }

        public static void LogScreenshot(string info, string image)
        {
            extentTest?.Info(info, MediaEntityBuilder.CreateScreenCaptureFromPath(image).Build());
        }
    }
}

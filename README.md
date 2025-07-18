# ExtentReporting2
**Project: Selenium Reporting with ExtentReports and NUnit**
This project demonstrates how to integrate Selenium WebDriver, NUnit, and ExtentReports in a C# test automation framework. The goal is to execute UI tests in Chrome, log test execution steps, capture screenshots (especially for failures), and generate interactive HTML reports.

**Features**
✅ Automated browser testing using Selenium WebDriver

🧪 Test structure based on NUnit

📊 Beautiful, interactive HTML reports with ExtentReports

📸 Automatic screenshot capture on test failure and test completion

📂 Report output stored locally with screenshots embedded
After execution, the HTML report will be generated at: /results/ExtentReport.html
Screenshots are saved in the /results/Screenshots directory and attached to the report.

📌 Prerequisites
.NET SDK installed
Chrome browser installed
NuGet packages:
  Selenium.WebDriver
  NUnit
  ExtentReports (AventStack.ExtentReports)

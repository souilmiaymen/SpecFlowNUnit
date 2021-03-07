using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace SpecFlowNUnitDemo.Steps
{
    [Binding]
    public sealed class Hooks
    {
        private DriverHelper _driverHelper;
        public Hooks (DriverHelper driverHelper) => _driverHelper=driverHelper;
        AventStack.ExtentReports.ExtentTest scenario, step;
        [BeforeScenario]
        public void BeforeScenario (ScenarioContext context)
        {
            scenario=feature.CreateNode(context.ScenarioInfo.Title);
            ChromeOptions option = new ChromeOptions();
            option.AddArguments("start-maximized");
            option.AddArguments("--disable-gpu");
            //option.AddArguments("--headless");
            _driverHelper.Driver=new ChromeDriver(option);
        }

        static AventStack.ExtentReports.ExtentReports extent;
        static string reportpath = System.IO.Directory.GetParent(@"../../../").FullName
            +Path.DirectorySeparatorChar+"Result"
            +Path.DirectorySeparatorChar+"Result_";
        [BeforeTestRun]
        public static void BeforeTestRun () 
        {
            ExtentHtmlReporter htmlReport = new ExtentHtmlReporter(reportpath);
            extent=new AventStack.ExtentReports.ExtentReports();
            extent.AttachReporter(htmlReport);
        }
        static AventStack.ExtentReports.ExtentTest feature;
        [BeforeFeature]
        public static void BeforeFeature(FeatureContext context)
        {
            feature=extent.CreateTest(context.FeatureInfo.Title);
        }

        [BeforeStep]
        public void BeforeStep ()
        {
            step=scenario;
        }
        [AfterStep]
        public void AfterStep (ScenarioContext context)
        {
            if (context.TestError == null)
            {
                step.Log(Status.Pass, context.StepContext.StepInfo.Text);
            }
            else if (context.TestError!=null)
            {
                step.Log(Status.Fail, context.StepContext.StepInfo.Text);
            }
        }
        [AfterFeature]
        public static void AfterFeature ()
        {
            extent.Flush();
        }
        [AfterScenario]
        public void AfterScenario ()
        {
            _driverHelper.Driver.Quit();
        }
    }
}

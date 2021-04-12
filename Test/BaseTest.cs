using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VCSchool.Drivers;
using VCSchool.Page;
using VCSchool.Tools;

namespace VCSchool.Test
{
    public class BaseTest
    {
        protected static IWebDriver driver;
        public static DropdownDemoNewPage _dropdownDemoPage;
        public static DemoVTPage _vartuTechnikaPage;
        public static SebCalculatorPage _sebCalculatorPage;
        public static SenukaiPage _senukaiPage;
        public static AlertPage _alertPage;
        public static AutoInsurancePage _autoInsurancePage;
        public static TravelInsurancePage _travelInsurancePage;
        public static ContactToBTAPage _contactToBTAPage;

        [OneTimeSetUp]
        public static void OneTimeSetup()
        {
            driver = CustomDriver.GetChromeDriver();
            _dropdownDemoPage = new DropdownDemoNewPage(driver);
            _vartuTechnikaPage = new DemoVTPage(driver);
            _sebCalculatorPage = new SebCalculatorPage(driver);
            _senukaiPage = new SenukaiPage(driver);
            _alertPage = new AlertPage(driver);
            _autoInsurancePage = new AutoInsurancePage(driver);
            _travelInsurancePage = new TravelInsurancePage(driver);
            _contactToBTAPage = new ContactToBTAPage(driver);
        }

        [TearDown]
        public static void TearDown()
        {
            if (TestContext.CurrentContext.Result.Outcome != ResultState.Success)
            {
                MyScreenshot.TakeScreenshot(driver);
            }
        }

        [OneTimeTearDown]
        public static void OneTimeTearDown()
        {
            driver.Quit();
        }
    }
}

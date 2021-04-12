using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Opera;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VCSchool.Drivers
{
    public class CustomDriver
    {
        public static IWebDriver GetChromeDriver()//metodas, kuris grazins mums IWEbdriveri
        {
            return GetDriver(Browsers.Chrome);
        }
        public static IWebDriver GetFirefoxDriver()//metodas, kuris grazins mums IWEbdriveri
        {
            return GetDriver(Browsers.Firefox);
        }
        private static IWebDriver GetDriver (Browsers browserName)//metodas noriu issikviesti ta browseri, kuri uzprasau, paduodu tipa browser
        {
            IWebDriver webdriver = null;//kintamasis
            switch(browserName)
            {
                case Browsers.Chrome:
                    webdriver = new ChromeDriver();
                    break;
                case Browsers.Firefox:
                    webdriver = new FirefoxDriver();
                    break;
                case Browsers.Opera:
                    webdriver = new OperaDriver();
                    break;
               default:
                    webdriver = new OperaDriver();
                    break;
             }
            webdriver.Manage().Window.Maximize();//bet kuris iskviestas metodas tures sias salygas
            webdriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            
            return webdriver;
        }
        private static IWebDriver getChromeWithIncognitoOption()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArgument("incognito");

            //options.AddArguments("incognito", "start-maximized");
            return new ChromeDriver(options);

        }
    }
}

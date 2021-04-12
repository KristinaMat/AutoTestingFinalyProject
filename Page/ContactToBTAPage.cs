using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace VCSchool.Page
{
    public class ContactToBTAPage : BasePage
    {
        private const string PageAddress = "https://www.bta.lt/lt/atstovybes";
        private IWebElement _cityBtaBranch => Driver.FindElement(By.XPath("//a[contains(text(),'Kaunas')]"));
        private IWebElement _resultTextElement => Driver.FindElement(By.XPath("//div[6]/p"));
        public ContactToBTAPage(IWebDriver webdriver) : base(webdriver) { }

        public ContactToBTAPage NavigateToDefaultPage()
        {
            if (Driver.Url != PageAddress)
                Driver.Url = PageAddress;
            return this;
        }
        public ContactToBTAPage ClosePop()
        {
            GetWait(5).Until(ExpectedConditions.ElementToBeClickable(By.XPath("//button[contains(.,'Sutikti')]")));
            Driver.FindElement(By.XPath("//button[contains(.,'Sutikti')]")).Click();
            return this;
        }

        public ContactToBTAPage SelectBTABranchcity()
        {
            _cityBtaBranch.Click();
            return this;
        }
        public ContactToBTAPage CheckBTABranchCity(string text)
        {
            WaitForElementToBeDisplayed(_resultTextElement);
            Assert.IsTrue(_resultTextElement.Text.Contains(text), $"Failed, expected result was {text}, but actual result was {_resultTextElement.Text}");
            return this;

        }
        private void WaitForElementToBeDisplayed(IWebElement element)
        {
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
            wait.Until(_driver => element.Displayed);
        }

    }
}

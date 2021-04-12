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
    public class TravelInsurancePage : BasePage
    {
        private const string PageAddress = "https://www.bta.lt/lt/privatiems/kelioniu-draudimas";
        private IWebElement _gotocalculateButton => Driver.FindElement(By.XPath("//button[contains(.,'Pasiskaičiuoti įmoka')]"));
        private IWebElement _fromdateInput => Driver.FindElement(By.XPath("//input"));
        private IWebElement _tilldateInput => Driver.FindElement(By.XPath("//div[2]/input"));
        private IWebElement _allWorldCheckBox => Driver.FindElement(By.Id("rb-VISASP"));
        private IWebElement _sportCheckBox => Driver.FindElement(By.Id("rb-SPORT"));
        private IWebElement _duration => Driver.FindElement(By.XPath("//div[3]/strong"));
        private IWebElement _textFromPage => Driver.FindElement(By.XPath("//div[2]/div[4]/div/label"));

        public TravelInsurancePage(IWebDriver webdriver) : base(webdriver) { }

        public TravelInsurancePage NavigateToDefaultPage()
        {
            if (Driver.Url != PageAddress)
                Driver.Url = PageAddress;
            return this;
        }
        public TravelInsurancePage ClosePop()
        {
            GetWait(5).Until(ExpectedConditions.ElementToBeClickable(By.XPath("//button[contains(.,'Sutikti')]")));
            Driver.FindElement(By.XPath("//button[contains(.,'Sutikti')]")).Click();
            return this;
        }

        public TravelInsurancePage ClickGoToCalculateButton()
        {
            _gotocalculateButton.Click();
            return this;
        }
        public TravelInsurancePage SwitchToFrame()
        {
            Driver.SwitchTo().Frame(0);
            return this;
        }
        public TravelInsurancePage InsertFromData(string datafrom)
        {
            _fromdateInput.Clear();
            _fromdateInput.SendKeys(datafrom);
            return this;
        }
        public TravelInsurancePage InsertTillData(string datatill)
        {
            _tilldateInput.Clear();
            _tilldateInput.SendKeys(datatill);
            return this;
        }
        public TravelInsurancePage CheckAllWorldCheckBox()
        {
            if (!_allWorldCheckBox.Selected)
                _allWorldCheckBox.Click();
            return this;
        }

        public TravelInsurancePage CheckTravelPurposeCheckBox()
        {
            if (!_sportCheckBox.Selected)
                _sportCheckBox.Click();
            return this;
        }

        public TravelInsurancePage VerifyTravelPurposeType(string text)
        {
            Assert.AreEqual(text, _textFromPage.Text, "Travel purpose type is not the same");
            return this;
        }
        public TravelInsurancePage VerifyTravelDuration(string text)
        {
            Assert.IsTrue(_duration.Text.Contains(text), $"Travel duration is not {_duration}");
            return this;
        }

    }
}

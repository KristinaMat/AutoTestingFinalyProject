using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VCSchool.Test
{
    public class TravelInsuranceTest:BaseTest
    {
        [Test]
        public static void TravelInsuranseDuration()
        {
            _travelInsurancePage.NavigateToDefaultPage()
                .ClosePop()
                .ClickGoToCalculateButton()
                .SwitchToFrame()
                .InsertFromData("2021-04-15")
                .InsertTillData("2021-04-19")
                .CheckAllWorldCheckBox()
                .VerifyTravelDuration("5");
        }
        [Test]
        public static void VerifyTravelPurpose ()
        {
            _travelInsurancePage.NavigateToDefaultPage()
                .ClosePop()
                .ClickGoToCalculateButton()
                .SwitchToFrame()
                .InsertFromData("2021-04-16")
                .InsertTillData("2021-04-20")
                .CheckAllWorldCheckBox()
                .CheckTravelPurposeCheckBox()
                .VerifyTravelPurposeType("Sportas");           
        }
    }
}

using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VCSchool.Test
{
    public class AutoInsuranceTest : BaseTest
    {

        [TestCase("JPS211", "47805120402", false, true, "106.96", TestName = "Mano automobilio privalomo draudimo kaina = 106.96")]

        public static void CalculateAutoInsurance(string autonumber, string idnumber, bool specialusage, bool agreeprivacy, string result)
        {
            _autoInsurancePage.NavigateToDefaultPage()
                .ClosePop()
                .InsertAutoNumber(autonumber)
                .InsertIDNumber(idnumber)
                .UnCheckSpecialCarUsageCheckBox(specialusage)
                .CheckAgreePrivacyCheckBox(agreeprivacy)
                .ClickCalculateButton()
                .CheckPolisyPrice(result);
        }
        [Test]
        public static void SpecialCarUsageAutoInsurance()
        {
            _autoInsurancePage.NavigateToDefaultPage()
                .ClosePop()
                .InsertAutoNumber("JPS211")
                .InsertIDNumber("47805120402")
                .UnCheckSpecialCarUsageCheckBox(true)
                .CheckSpecialCarUsageCheckBox()
                .CheckDriveTeachBox()
                .CheckAgreePrivacyCheckBox(true)
                .ClickCalculateButton()
                .CheckPolisyPrice("128.37");
        }
    }
}

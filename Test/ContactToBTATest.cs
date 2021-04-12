using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VCSchool.Test
{
    public class ContactToBTATest : BaseTest
    {
        [Test]
        public static void BTABranchContact()
        {
            _contactToBTAPage.NavigateToDefaultPage()
                .ClosePop()
                .SelectBTABranchcity()
                .CheckBTABranchCity("Kauno skyrius");
        }

    }
}

using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;

namespace WebBaseTests
{
    class ChangeBranchTests : TestBase
    {
        [Test]
        public void ChangeBranchUsingBranchTree()
        {
            Pages.LoginPage loginPage = new Pages.LoginPage(driver);
            loginPage.GoToPage();
            loginPage.PerformLogin("Калиниченко Антон", "123456");
            Pages.ConsultantPage consultantPage = new Pages.ConsultantPage(driver);
            consultantPage.ClickChangeBranchDialogButton();
            Pages.ChangeBranchDialog changeBranchDialog = new Pages.ChangeBranchDialog(driver);
            changeBranchDialog.ChangeBranch();
        }
    }
}

using NUnit.Framework;

namespace WebBaseTests
{
    class ChangeBranchTests : TestBase
    {
        [Test]
        public void ChangeBranchUsingBranchTree()
        {
            Region region = new Region("Сибирь");
            Town town = new Town(region,"Алейск");
            Pages.LoginPage loginPage = new Pages.LoginPage(driver);
            loginPage.GoToPage();
            loginPage.PerformLogin("Калиниченко Антон", "123456");
            Pages.ConsultantPage consultantPage = new Pages.ConsultantPage(driver);
            consultantPage.ClickChangeBranchDialogButton();
            Pages.ChangeBranchDialog changeBranchDialog = new Pages.ChangeBranchDialog(driver);
            changeBranchDialog.ChangeBranch(region, town);
            Assert.AreEqual(changeBranchDialog.branchName, consultantPage.GetCurrentBranchName());
        }
    }
}

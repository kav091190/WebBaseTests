﻿using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using SeleniumExtras.WaitHelpers;

namespace WebBaseTests.Pages
{
    class ConsultantPage : PageBase
    {
        public ConsultantPage(IWebDriver driver) : base(driver)
        {
            PageUrl = PageUrl + "/consultant";
        }

        [FindsBy(How = How.ClassName, Using = "loginDisplay")]
        private IWebElement LoginDisplay { get; set; }

        [FindsBy(How = How.ClassName, Using = "TextBranch")]
        private IWebElement CurrentBranchName { get; set; }

        [FindsBy(How = How.Id, Using = "modal")]
        private IWebElement ChangeBranchDialogButton { get; set; }

        public string GetLogedInUserNameText()
        {
           return LoginDisplay.Text;           
        }

        private string GetCurrentBranchName()
        {
            return CurrentBranchName.Text;
        }

        public void ClickChangeBranchDialogButton()
        {
            ChangeBranchDialogButton.Click();
            Wait.Until(ExpectedConditions.InvisibilityOfElementLocated(By.ClassName("waitbar")));
        }
    }
}

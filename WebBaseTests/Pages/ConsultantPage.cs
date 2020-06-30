using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using SeleniumExtras.WaitHelpers;
using System.Collections.Generic;
using WebBaseTests.Data;

namespace WebBaseTests.Pages
{
    class ConsultantPage : PageBase
    {
        public ConsultantPage(IWebDriver driver) : base(driver)
        {
            PageUrl += "/consultant";
        }

        [FindsBy(How = How.ClassName, Using = "loginDisplay")]
        private IWebElement LoginDisplay { get; set; }

        [FindsBy(How = How.ClassName, Using = "TextBranch")]
        private IWebElement CurrentBranchName { get; set; }

        [FindsBy(How = How.Id, Using = "modal")]
        private IWebElement ChangeBranchDialogButton { get; set; }

        [FindsBy(How = How.CssSelector, Using = "a[href=\"/consultant/\"]")]
        private IWebElement CatalogButton { get; set; }

        private IWebElement GetCategoryElement(Category category)
        {
            IWebElement categoryElement = Driver.FindElement(By.CssSelector("div[title='" + category.Name + "']"));
            return categoryElement;
        }

        //ВЗАИМОДЕЙСТВИЯ С ШАПКОЙ
        public string GetLogedInUserNameText() => LoginDisplay.Text;

        public string GetCurrentBranchName()
        {
            Wait.Until(ExpectedConditions.ElementIsVisible(By.ClassName("TextBranch")));
            return CurrentBranchName.Text.Replace("Филиал: ", string.Empty).Replace(" (A+) [ Сменить ]", string.Empty);
        }

        public void ClickChangeBranchDialogButton()
        {
            ChangeBranchDialogButton.Click();
            Wait.Until(ExpectedConditions.InvisibilityOfElementLocated(By.ClassName("waitbar")));
        }

        public void ClickCatalogButton() => CatalogButton.Click();

        //Взаимодействие с каталогом
        public void ClickCategoryButton(Category category)
        {
            WaitTillPageStatusBeComlete();
            Wait.Until(ExpectedConditions.InvisibilityOfElementLocated(By.CssSelector("div[class=\"blockUI blockMsg blockPage\"]")));
            GetCategoryElement(category).Click();
        }      
    }
}

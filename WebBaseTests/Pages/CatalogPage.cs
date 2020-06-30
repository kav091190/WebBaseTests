using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using WebBaseTests.Data;

namespace WebBaseTests.Pages 
{
    class CatalogPage : PageBase
    {
        public CatalogPage(IWebDriver driver) : base(driver)
        {

        }

        [FindsBy(How = How.Id, Using = "showGoodsAvailable")]
        private IWebElement ShowGoodsAvailableButton { get; set; }

        [FindsBy(How = How.Id, Using = "filter-submit")]
        private IWebElement FilterSubmitButton { get; set; }

        private IWebElement GetSubCategoryElement(Category category)
        {
            IWebElement categoryElement = Driver.FindElement(By.CssSelector("div[title='" + category.Name + "']"));
            return categoryElement;
        }

        internal void ClickCategoryButton(Category subcategory)
        {
            throw new NotImplementedException();
        }

        //ВЗАИМОДЕЙСТВИЕ С ФИЛЬТРАМИ
        public void ClickShowAvailableGoodsButton()
        {
            Wait.Until(ExpectedConditions.InvisibilityOfElementLocated(By.CssSelector("div[class=\"blockUI blockMsg blockPage\"]")));
            ShowGoodsAvailableButton.Click();
        }

        public void ClickFilterSubmitButton()
        {
            Wait.Until(ExpectedConditions.InvisibilityOfElementLocated(By.CssSelector("div[class=\"blockUI blockMsg blockPage\"]")));
            FilterSubmitButton.Click();
        }

        //ВЗАИМОДЕЙСТВИЯ С КАТАЛОГОМ
        public void ClickSubCategoryButton(Category category)
        {
            WaitTillPageStatusBeComlete();
            Wait.Until(ExpectedConditions.InvisibilityOfElementLocated(By.CssSelector("div[class=\"blockUI blockMsg blockPage\"]")));
            GetSubCategoryElement(category).Click();
        }
    }
}

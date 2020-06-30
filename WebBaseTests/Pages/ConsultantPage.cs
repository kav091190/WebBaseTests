using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using SeleniumExtras.WaitHelpers;
using System;
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

        [FindsBy(How = How.Id, Using = "showGoodsAvailable")]
        private IWebElement ShowGoodsAvailableButton { get; set; }

        [FindsBy(How = How.Id, Using = "filter-submit")]
        private IWebElement FilterSubmitButton { get; set; }

        private IWebElement GetCategoryElement(Category category)
        {
            IWebElement categoryElement = Driver.FindElement(By.CssSelector("div[title='" + category.Name + "']"));
            return categoryElement;
        }

        [FindsBy(How = How.XPath, Using = "//tr[starts-with(@class, 'product-row')]")]
        private IList<IWebElement> Products { get; set; }

        private string GetProductsStockCount(IWebElement s)
        {
            string productsStockCount = s.FindElement(By.ClassName("cons-col21")).Text;
            return productsStockCount;
        }

        private string GetReservedProductsCount(IWebElement s)
        {
            string reservedProductsCount = s.FindElement(By.ClassName("cons-col22")).Text;
            return reservedProductsCount;
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

        //ВЗАИМОДЕЙСТВИЯ С КАТАЛОГОМ
        public void ClickCategoryButton(Category category)
        {
            WaitTillPageStatusBeComlete();
            Wait.Until(ExpectedConditions.InvisibilityOfElementLocated(By.CssSelector("div[class=\"blockUI blockMsg blockPage\"]")));
            GetCategoryElement(category).Click();
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

        /// <summary>
        /// Переход с главной страницы каталога в список товаров в наличии
        /// </summary>
        public void GoToAvailableProductsList(Category category, Category subcategory)
        {
            ClickCategoryButton(category);
            ClickCategoryButton(subcategory);
            ClickShowAvailableGoodsButton();
            ClickFilterSubmitButton();            
        }
        
        /// <summary>
        /// Проверка, что сумма резервов и остатков не рана нулю. То есть товар есть в наличии.
        /// </summary>
        public bool IsThereOutofStockProduct ()
        {
            Wait.Until(ExpectedConditions.InvisibilityOfElementLocated(By.CssSelector("div[class=\"blockUI blockMsg blockPage\"]")));
            foreach (IWebElement s in Products)
            {
                int.TryParse(GetProductsStockCount(s), out int productsStockCount);
                int.TryParse(GetReservedProductsCount(s), out int reservedProductsCount);
                if (productsStockCount + reservedProductsCount == 0)
                    return false;
            }  
            return true;
        }
    }
}

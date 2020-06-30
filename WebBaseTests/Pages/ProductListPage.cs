using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using SeleniumExtras.WaitHelpers;
using System.Collections.Generic;
using WebBaseTests.Data;

namespace WebBaseTests.Pages
{
    class ProductListPage : PageBase
    {
        public ProductListPage(IWebDriver driver) : base(driver)
        {

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

        /// <summary>
        /// Проверка, что сумма резервов и остатков не рана нулю. То есть товар есть в наличии.
        /// </summary>
        public bool IsThereOutofStockProduct()
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

using NUnit.Framework;
using WebBaseTests.Data;

namespace WebBaseTests.Test
{
    class CatalogTests : TestBase
    {
        [Test]
        public void GoodsAvailableFilterShowsOnlyAvailableGoods()
        {
            Category category = new Category("00. Бытовая Техника");
            Category subcategory = new Category("01. КБТ Отдельностоящая");
            Pages.LoginPage loginPage = new Pages.LoginPage(driver);
            loginPage.GoToPage();
            loginPage.PerformLogin("Калиниченко Антон2", "123456");
            Pages.ConsultantPage consultantPage = new Pages.ConsultantPage(driver);
            consultantPage.GoToPage();
            consultantPage.GoToAvailableProductsList(category, subcategory);
            Assert.AreEqual(true, consultantPage.IsThereOutofStockProduct());
        }
    }
}

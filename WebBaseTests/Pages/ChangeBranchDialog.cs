using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using SeleniumExtras.WaitHelpers;
using System.Threading;

namespace WebBaseTests.Pages
{
    class ChangeBranchDialog : PageBase
    {
        public ChangeBranchDialog (IWebDriver driver) : base(driver)
        {

        }

        [FindsBy(How = How.Id, Using = "tree_filter_textbox")]
        private IWebElement SearchInTreeTextField { get; set; }

        [FindsBy(How = How.Id, Using = "search_in_tree")]
        private IWebElement SearchInTreeButton { get; set; }

        private IWebElement GetRegionElementInBranchTree(Region region)
        {
            IWebElement regionElement = Driver.FindElement(By.XPath("//span[text()='" + region.Name + "']"));
            return regionElement;
        }

        private IWebElement GetTownElementInBranchTree(Town town)
        {
            IWebElement townElement = Driver.FindElement(By.XPath("//li[span[text()='" + town.Region.Name + "']]/ul/li/span[text()='" + town.Name + "']"));
            return townElement;
        }

        private IWebElement GetBranchElementInBranchTree(Town town)
        {
            IWebElement branchElement = Driver.FindElement(By.XPath("//li[span[text()='" + town.Region.Name + "']]/ul/li[span[text()='" + town.Name + "']]/ul/li/a"));
            return branchElement;
        }

        private bool IsElementCollapsed(IWebElement element)
        {
           bool isElementCollapsed = element.FindElement(By.XPath("..")).GetAttribute("class").Equals("collapsable");
           return isElementCollapsed;
        }

        private void ClickOnElementInBranchTree(IWebElement element)
        {
            bool isElementCollapsed = IsElementCollapsed(element);
            if (isElementCollapsed == false)
            element.Click();
        }

        public void ClickOnRegion(Region region)
        {
            IWebElement regionElement = GetRegionElementInBranchTree(region);
            ClickOnElementInBranchTree(regionElement);
            Wait.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath("//li[span[text()='" + region.Name + "']]/ul/li")));
        }

        public void ClickOnTown(Town town)
        {
            IWebElement regionElement = GetTownElementInBranchTree(town);
            ClickOnElementInBranchTree(regionElement);
            Wait.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath("//li[span[text()='" + town.Region.Name + "']]/ul/li[span[text()='" + town.Name + "']]/ul/li")));
        }
             
        public void FillSearchInTreeTextField(string branch)
        {
            SearchInTreeTextField.SendKeys(branch);
        }

        public void ClickSearchInTreeButton()
        {
            SearchInTreeButton.Click();
        }

        public string branchName;
        private void GetBranchName(Region region, Town town)
        {
            ClickOnRegion(region);
            ClickOnTown(town);
            branchName = GetBranchElementInBranchTree(town).Text;
        }

        public void ChangeBranch(Region region, Town town)
        {
            GetBranchName(region, town);
            FillSearchInTreeTextField(branchName);
            ClickSearchInTreeButton();
            Thread.Sleep(20);

            /*
            IJavaScriptExecutor js = (IJavaScriptExecutor)Driver;
            bool condition() => (bool)js.ExecuteScript("return document.readyState == 'interactive'");

            while (!condition())
                Thread.Sleep(100);*/
        }
    }
}
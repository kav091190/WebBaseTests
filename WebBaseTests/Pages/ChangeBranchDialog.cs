using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using SeleniumExtras.WaitHelpers;

namespace WebBaseTests.Pages
{
    class ChangeBranchDialog : PageBase
    {
        public ChangeBranchDialog (IWebDriver driver) : base(driver)
        {

        }

        [FindsBy(How = How.Id, Using = "tree_filter_textbox")]
        private IWebElement BranchFilterTextField { get; set; }

        [FindsBy(How = How.Id, Using = "search_in_tree")]
        private IWebElement SearchInTreeButton { get; set; }

        [FindsBy(How = How.Id, Using = "branch_tree")]
        private IWebElement BranchTree { get; set; }

        public void FillBranchFilterTextField(string branch)
        {
            BranchFilterTextField.SendKeys(branch);
        }

        public void ClickSearchInTreeButton()
        {
            SearchInTreeButton.Click();
        }

        public void GetBranchFromBranchTree()
        {

        }

        public void ChangeBranch()
        {
            FillBranchFilterTextField("Алейск");
            ClickSearchInTreeButton();
        }
    }
}

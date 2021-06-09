using EAAutoFramework.Base;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace EAEmployeeTest.Pages
{
    class EmployeePage : BasePage
    {
        [FindsBy(How = How.Name, Using = "searchTerm")]
        public IWebElement txtSearch { get; set; }
        
        [FindsBy(How = How.LinkText, Using = "Create New")]
        public IWebElement lnkCreateNew { get; set; }

        public CreateEmployeePage ClickCreateNew()
        {
            lnkCreateNew.Click();
            return new CreateEmployeePage();
        }
    }
}

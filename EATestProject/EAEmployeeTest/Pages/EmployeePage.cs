using EAAutoFramework.Base;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace EAEmployeeTest.Pages
{
    class EmployeePage : BasePage
    {
        [FindsBy(How = How.Name, Using = "searchTerm")]
        IWebElement txtSearch { get; set; }
        
        [FindsBy(How = How.LinkText, Using = "Create New")]
        IWebElement lnkCreateNew { get; set; }

        [FindsBy(How = How.ClassName, Using = "table")]
        IWebElement tblEmployeeList { get; set; }

        public CreateEmployeePage ClickCreateNew()
        {
            lnkCreateNew.Click();
            return new CreateEmployeePage();
        }

        public IWebElement GetEmployeeList()
        {
            return tblEmployeeList;
        }
    }
}

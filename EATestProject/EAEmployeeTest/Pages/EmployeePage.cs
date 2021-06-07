using EAAutoFramework.Base;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace EAEmployeeTest.Pages
{
    class EmployeePage : BasePage
    {
        [FindsBy(How = How.Name, Using = "searchTerm")]
        public IWebElement txtSearchTerm { get; set; }
    }
}

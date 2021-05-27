using EAAutoFramework.Base;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace EAEmployeeTest.Pages
{
    class EmployeePage : BasePage
    {
        public EmployeePage(IWebDriver driver) : base(driver)
        {
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.Name, Using = "searchTerm")]
        public IWebElement txtSearchTerm { get; set; }
    }
}

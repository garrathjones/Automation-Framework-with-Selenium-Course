using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using EAAutoFramework.Base;

namespace EAEmployeeTest.Pages
{
    class LoginPage : BasePage
    {

        //Objects for login page
        [FindsBy(How = How.LinkText, Using = "Login")]
        IWebElement lnkLogin { get; set; }

        [FindsBy(How = How.LinkText, Using = "Employee List")]
        IWebElement lnkEmployeeList { get; set; }

        [FindsBy(How = How.Id, Using = "UserName")]
        IWebElement txtUserName { get; set; }

        [FindsBy(How = How.Id, Using = "Password")]
        IWebElement txtPassword { get; set; }

        [FindsBy(How = How.CssSelector, Using = ".btn-default")]
        IWebElement btnLogin { get; set; }

        public void Login(string userName, string password)
        {
            txtUserName.SendKeys(userName);
            txtPassword.SendKeys(password);
            btnLogin.Submit();
        }

        public void ClickLoginLink()
        {
            lnkLogin.Click();            
        }

        public EmployeePage ClickEmployeeList()
        {
            lnkEmployeeList.Click();
            return GetInstance<EmployeePage>();
        }
    }
}

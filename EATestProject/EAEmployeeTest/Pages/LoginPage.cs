using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using EAAutoFramework.Base;

namespace EAEmployeeTest.Pages
{
    class LoginPage : BasePage
    {
        //Initialise login page
        public LoginPage(IWebDriver driver) : base(driver)
        {
            PageFactory.InitElements(driver, this);
        }

        //Objects for login page
        [FindsBy(How = How.LinkText, Using = "Login")]
        public IWebElement lnkLogin { get; set; }

        [FindsBy(How = How.Id, Using = "UserName")]
        public IWebElement txtUserName { get; set; }

        [FindsBy(How = How.Id, Using = "Password")]
        public IWebElement txtPassword { get; set; }

        [FindsBy(How = How.CssSelector, Using = ".btn-default")]
        public IWebElement btnLogin { get; set; }
    }
}

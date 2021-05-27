using EAEmployeeTest.Pages;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace EAEmployeeTest
{
    [TestClass]
    public class UnitTest1
    {
        string url = "http://eaapp.somee.com";
        private IWebDriver _driver;

        [TestMethod]
        public void TestMethod1()
        {
            _driver = new ChromeDriver();
            _driver.Navigate().GoToUrl(url);
            Login();
        }

        public void Login()
        {
            ////click link for "Log in" Page
            //_driver.FindElement(By.LinkText("Login")).Click();
            ////enter username
            //_driver.FindElement(By.Id("UserName")).SendKeys("admin");
            ////enter password
            //_driver.FindElement(By.Id("Password")).SendKeys("password");
            ////click login
            //_driver.FindElement(By.CssSelector(".btn-default")).Submit();

            LoginPage page = new LoginPage(_driver);
            page.lnkLogin.Click();
            page.txtUserName.SendKeys("admin");
            page.txtPassword.SendKeys("password");
            page.btnLogin.Submit();
        }
    }
}

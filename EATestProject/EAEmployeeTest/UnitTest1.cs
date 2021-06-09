using EAEmployeeTest.Pages;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using EAAutoFramework.Base;

namespace EAEmployeeTest
{
    [TestClass]
    public class UnitTest1
    {
        string url = "http://eaapp.somee.com";

        [TestMethod]
        public void TestMethod1()
        {
            DriverContext.Driver = new ChromeDriver();
            DriverContext.Driver.Navigate().GoToUrl(url);

            LoginPage page = new LoginPage();
            page.ClickLoginLink();
            page.Login("admin", "password");

            var employeePage = page.ClickEmployeeList();
            employeePage.ClickCreateNew();
        }
    }
}

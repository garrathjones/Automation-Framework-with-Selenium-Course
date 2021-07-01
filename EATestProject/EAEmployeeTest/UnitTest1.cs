using EAEmployeeTest.Pages;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Chrome;
using EAAutoFramework.Base;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Firefox;
using System;
using EAAutoFramework.Helpers;

namespace EAEmployeeTest
{
    [TestClass]
    public class UnitTest1 : Base
    {
        string url = "http://eaapp.somee.com";

        public void OpenBrowser(BrowserType browserType = BrowserType.Chrome)
        {
            switch (browserType)
            {
                case BrowserType.InternetExplorer:
                    DriverContext.Driver = new InternetExplorerDriver();
                    DriverContext.Browser = new Browser(DriverContext.Driver);
                    break;
                case BrowserType.FireFox:
                    DriverContext.Driver = new FirefoxDriver();
                    DriverContext.Browser = new Browser(DriverContext.Driver);
                    break;
                case BrowserType.Chrome:
                    DriverContext.Driver = new ChromeDriver();
                    DriverContext.Browser = new Browser(DriverContext.Driver);
                    break;
            }
        }


        [TestMethod]
        public void TestMethod1()
        {
            string fileName = Environment.CurrentDirectory.ToString() + "\\Data\\Login.xlsx";

            ExcelHelpers.PopulateInCollection(fileName);

            LogHelpers.CreateLogFile();

            OpenBrowser(BrowserType.Chrome);
            LogHelpers.Write("Opened browser");
            DriverContext.Browser.GoToUrl(url);
            LogHelpers.Write("Navigated to given URL - " + url);

            //Login Page
            CurrentPage = GetInstance<LoginPage>();
            CurrentPage.As<LoginPage>().ClickLoginLink();
            CurrentPage.As<LoginPage>().Login(ExcelHelpers.ReadData(1,"UserName"),ExcelHelpers.ReadData(1,"Password"));

            //Employee Page            
            CurrentPage = CurrentPage.As<LoginPage>().ClickEmployeeList();
            CurrentPage.As<EmployeePage>().ClickCreateNew();        
        }

        [TestMethod]
        public void TableOperation()
        {
            string fileName = Environment.CurrentDirectory.ToString() + "\\Data\\Login.xlsx";

            ExcelHelpers.PopulateInCollection(fileName);

            LogHelpers.CreateLogFile();

            OpenBrowser(BrowserType.Chrome);
            LogHelpers.Write("Opened browser");
            DriverContext.Browser.GoToUrl(url);
            LogHelpers.Write("Navigated to given URL - " + url);

            //Login Page
            CurrentPage = GetInstance<LoginPage>();
            CurrentPage.As<LoginPage>().ClickLoginLink();
            CurrentPage.As<LoginPage>().Login(ExcelHelpers.ReadData(1, "UserName"), ExcelHelpers.ReadData(1, "Password"));

            //Employee Page            
            CurrentPage = CurrentPage.As<LoginPage>().ClickEmployeeList();

            var table = CurrentPage.As<EmployeePage>().GetEmployeeList();

            HtmlTableHelper.ReadTable(table);
            HtmlTableHelper.PerformActionOnCell("5", "Name", "Ramesh", "Edit");

        }

    }
}
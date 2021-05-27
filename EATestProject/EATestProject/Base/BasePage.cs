using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace EAAutoFramework.Base
{
    public abstract class BasePage
    {
        public BasePage(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
        }
        
    }
}

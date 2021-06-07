using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace EAAutoFramework.Base
{
    public abstract class BasePage
    {
        public BasePage()
        {
            PageFactory.InitElements(DriverContext.Driver, this);
        }
        
    }
}

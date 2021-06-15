using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace EAAutoFramework.Base
{
    public class Base
    {
        public BasePage CurrentPage { get; set; }

        private IWebDriver _driver { get; set; }

        protected TPage GetInstance<TPage>() where TPage : BasePage, new()
        {
            TPage pageInstance = new TPage()
            {
                _driver = DriverContext.Driver
            };
            PageFactory.InitElements(DriverContext.Driver, pageInstance);

            return pageInstance;
        }

        public TPage As<TPage>() where TPage : BasePage
        {
            return (TPage)this;
        }
    }
}

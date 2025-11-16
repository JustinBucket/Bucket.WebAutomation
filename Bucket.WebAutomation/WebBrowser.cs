using System;
using System.Threading.Tasks;
using Bucket.WebAutomation.Browser;
using Bucket.WebAutomation.Elements;
using OpenQA.Selenium;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Interactions;

namespace Bucket.WebAutomation
{
    public class WebBrowser
    {
        // should be more of a factory, right?
        // do we nee this as a property?
        // public BrowserType Type { get; }
        public WebDriver Driver { get; }
        public WebBrowser(BrowserType type)
        {
            // Type = type;

            switch (type)
            {
                case BrowserType.Edge:
                    Driver = new EdgeDriver();
                    break;

                case BrowserType.Firefox:
                    Driver = new FirefoxDriver();
                    break;

                default:
                    throw new NotImplementedException($"{type} not supported");
            };
        }

        public void NavigateToUrl(string url)
        {
            Driver.Navigate().GoToUrl(url);
        }

        public void Launch()
        {
            Driver.Navigate();
        }

        public void Close()
        {
            Driver.Quit();
        }

        public T CreateElement<T>() where T: Element
        {
            var element = Activator.CreateInstance<T>();
            element.driver = Driver;

            return element;
        }

        public void Maximize()
        {
            Driver.Manage().Window.Maximize();
        }        
    }
}

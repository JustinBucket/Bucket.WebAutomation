using System;
using Bucket.WebAutomation.Browser;
using OpenQA.Selenium;
using OpenQA.Selenium.Edge;

namespace Bucket.WebAutomation
{
    public class WebBrowser
    {
        // should be more of a factory, right?
        public BrowserType Type { get; }
        public WebDriver Driver { get; }
        public WebBrowser(BrowserType type)
        {
            Type = type;
            Driver = new EdgeDriver();
        }

        // TODO: add some launch options
        // We should launch from the constructor?
        public void NavigateToUrl(string url)
        {
            Driver.Navigate().GoToUrl(url);
        }

        // TODO: add default url
        // TODO: would be good to have it default to home page
        public void Launch()
        {
            Driver.Navigate();
        }
    }
}

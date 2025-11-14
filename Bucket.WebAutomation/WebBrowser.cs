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

        public void Click(Element ele, ClickType type = ClickType.Single)
        {
            if (ele.WebElement == null)
            {
                FindElement(ele);
            }

            Actions action;

            switch (type)
            {
                case ClickType.Single:
                    action = new Actions(Driver).Click(ele.WebElement);
                    break;

                case ClickType.Double:
                    action = new Actions(Driver).DoubleClick(ele.WebElement);
                    break;

                case ClickType.Right:
                    action = new Actions(Driver).ContextClick(ele.WebElement);
                    break;
                default:
                    throw new NotImplementedException($"'{type}' not handled");
            }


            action.Perform();
        }

        public bool ElementExists(Element ele)
        {
            FindElement(ele);

            if (ele.WebElement != null)
            {
                return true;
            }

            return false;
        }

        public void FindElement(Element ele)
        {
            // fire these in parralel
            Parallel.Invoke(
                () =>
                {
                    // if we've been provided the identifier type 
                    // and the web element hasn't already been found
                    if (!string.IsNullOrWhiteSpace(ele.Selector.XPath) && ele.WebElement == null)
                    {
                        ele.WebElement = Driver.FindElement(By.XPath(ele.Selector.XPath));
                    }
                },
                () =>
                {
                    if (!string.IsNullOrWhiteSpace(ele.Selector.Id) && ele.WebElement == null)
                    {
                        ele.WebElement = Driver.FindElement(By.Id(ele.Selector.Id));
                    }
                },
                () =>
                {
                    if (!string.IsNullOrWhiteSpace(ele.Selector.Name) && ele.WebElement == null)
                    {
                        ele.WebElement = Driver.FindElement(By.Name(ele.Selector.Name));
                    }
                },
                () =>
                {
                    if (!string.IsNullOrWhiteSpace(ele.Selector.ClassName) && ele.WebElement == null)
                    {
                        ele.WebElement = Driver.FindElement(By.ClassName(ele.Selector.ClassName));
                    }
                },
                () =>
                {
                    if (!string.IsNullOrWhiteSpace(ele.Selector.TagName) && ele.WebElement == null)
                    {
                        ele.WebElement = Driver.FindElement(By.TagName(ele.Selector.TagName));
                    }
                },
                () =>
                {
                    if (!string.IsNullOrWhiteSpace(ele.Selector.LinkText) && ele.WebElement == null)
                    {
                        ele.WebElement = Driver.FindElement(By.LinkText(ele.Selector.LinkText));
                    }
                },
                () =>
                {
                    if (!string.IsNullOrWhiteSpace(ele.Selector.PartialLinkText) && ele.WebElement == null)
                    {
                        ele.WebElement = Driver.FindElement(By.PartialLinkText(ele.Selector.PartialLinkText));
                    }
                },
                () =>
                {
                    if (!string.IsNullOrWhiteSpace(ele.Selector.CSS) && ele.WebElement == null)
                    {
                        ele.WebElement = Driver.FindElement(By.CssSelector(ele.Selector.CSS));
                    }
                }
            );
        }
    }
}

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Bucket.WebAutomation.Browser;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace Bucket.WebAutomation.Elements
{
    // idea here is that consumers can create concrete element classes
    // representing specific elements they want to interact with
    // e.g. LoginButton, DateOfBirthDropdown, etc.
    // elements can then be passed as arguments to browser methods
    public abstract class Element
    {
        private IWebElement webElement;
        public IWebElement WebElement
        {
            get { return webElement; }
            set
            {
                webElement = value;
                if (value != null)
                {
                    WebElementFound?.Invoke(this, EventArgs.Empty);
                }
            }
        }

        internal IWebDriver driver;

        public event EventHandler WebElementFound;
        
        public Selector Selector { get; set; } = new Selector();
        public Element(
            string className = "",
            string css = "",
            string id = "",
            string name = "",
            string linkText = "",
            string partialLinkText = "",
            string tagName = "",
            string xpath = "")
        {
            Selector.ClassName = className;
            Selector.CSS = css;
            Selector.Id = id;
            Selector.Name = name;
            Selector.LinkText = linkText;
            Selector.PartialLinkText = partialLinkText;
            Selector.TagName = tagName;
            Selector.XPath = xpath;
        }

        public void Click(Element ele, ClickType type = ClickType.Single)
        {
            if (ele.WebElement == null)
            {
                FindElement();
            }

            Actions action;

            switch (type)
            {
                case ClickType.Single:
                    action = new Actions(driver).Click(ele.WebElement);
                    break;

                case ClickType.Double:
                    action = new Actions(driver).DoubleClick(ele.WebElement);
                    break;

                case ClickType.Right:
                    action = new Actions(driver).ContextClick(ele.WebElement);
                    break;
                default:
                    throw new NotImplementedException($"'{type}' not handled");
            }


            action.Perform();
        }

        public bool ElementExists()
        {
            FindElement();

            if (WebElement != null)
            {
                return true;
            }

            return false;
        }

        protected void FindElement()
        {
            // look for elements matcing given parameters
            // shift away from parallel programming worked.
            // TODO: how do we bring parallel back?
            // are the tasks not waiting properly? Manually performing the actions in the debug window finds the element
            var driverEles = new ReadOnlyCollection<IWebElement>(new List<IWebElement>());

            if (!string.IsNullOrWhiteSpace(Selector.XPath) && driverEles.Count == 0)
            {
                driverEles = driver.FindElements(By.XPath(Selector.XPath));
            }

            if (!string.IsNullOrWhiteSpace(Selector.Id) && driverEles.Count == 0)
            {
                driverEles = driver.FindElements(By.Id(Selector.Id));
            }

            if (!string.IsNullOrWhiteSpace(Selector.Name) && driverEles.Count == 0)
            {
                driverEles = driver.FindElements(By.Name(Selector.Name));
            }

            if (!string.IsNullOrWhiteSpace(Selector.ClassName) && driverEles.Count == 0)
            {
                driverEles = driver.FindElements(By.ClassName(Selector.ClassName));
            }

            if (!string.IsNullOrWhiteSpace(Selector.TagName) && driverEles.Count == 0)
            {
                driverEles = driver.FindElements(By.TagName(Selector.TagName));
            }

            if (!string.IsNullOrWhiteSpace(Selector.LinkText) && driverEles.Count == 0)
            {
                driverEles = driver.FindElements(By.LinkText(Selector.LinkText));
            }

            if (!string.IsNullOrWhiteSpace(Selector.PartialLinkText) && driverEles.Count == 0)
            {
                driverEles = driver.FindElements(By.PartialLinkText(Selector.PartialLinkText));
            }

            if (!string.IsNullOrWhiteSpace(Selector.CSS) && driverEles.Count == 0)
            {
                driverEles = driver.FindElements(By.CssSelector(Selector.CSS));
            }

            // try
            // {
            //     var tasks = new List<Task>();

            //     if (!string.IsNullOrWhiteSpace(Selector.XPath))
            //     {
            //         var xpathTask = Task.Run(() =>
            //             {
            //                 if (driverEles.Count == 0)
            //                 {
            //                     driverEles = driver.FindElements(By.XPath(Selector.XPath));
            //                 }
            //             }
            //         );

            //         tasks.Add(xpathTask);
            //     }

            //     if (!string.IsNullOrWhiteSpace(Selector.Id))
            //     {
            //         var idTask = Task.Run(() =>
            //             {
            //                 if (driverEles.Count == 0)
            //                 {
            //                     driverEles = driver.FindElements(By.Id(Selector.Id));
            //                 }
            //             }
            //         );

            //         tasks.Add(idTask);
            //     }

            //     if (!string.IsNullOrWhiteSpace(Selector.Name))
            //     {
            //         var nameTask = Task.Run(() =>
            //             {
            //                 if (driverEles.Count == 0)
            //                 {
            //                     driverEles = driver.FindElements(By.Name(Selector.Name));
            //                 }
            //             }
            //         );

            //         tasks.Add(nameTask);
            //     }

            //     if (!string.IsNullOrWhiteSpace(Selector.ClassName))
            //     {
            //         var classTask = Task.Run(() =>
            //             {
            //                 if (driverEles.Count == 0)
            //                 {
            //                     driverEles = driver.FindElements(By.ClassName(Selector.ClassName));
            //                 }
            //             }
            //         );

            //         tasks.Add(classTask);
            //     }

            //     if (!string.IsNullOrWhiteSpace(Selector.TagName))
            //     {
            //         var tagTask = Task.Run(() =>
            //             {
            //                 if (driverEles.Count == 0)
            //                 {
            //                     driverEles = driver.FindElements(By.TagName(Selector.TagName));
            //                 }
            //             }
            //         );

            //         tasks.Add(tagTask);
            //     }
                
            //     if (!string.IsNullOrWhiteSpace(Selector.LinkText))
            //     {
            //         var linkTask = Task.Run(() =>
            //             {
            //                 if (driverEles.Count == 0)
            //                 {
            //                     driverEles = driver.FindElements(By.LinkText(Selector.LinkText));
            //                 }
            //             }
            //         );

            //         tasks.Add(linkTask);
            //     }

            //     if (!string.IsNullOrWhiteSpace(Selector.PartialLinkText))
            //     {
            //         var partialLinkTask = Task.Run(() =>
            //             {
            //                 if (driverEles.Count == 0)
            //                 {
            //                     driverEles = driver.FindElements(By.PartialLinkText(Selector.PartialLinkText));
            //                 }
            //             }
            //         );

            //         tasks.Add(partialLinkTask);
            //     }

            //     if (!string.IsNullOrWhiteSpace(Selector.CSS))
            //     {
            //         var cssTask = Task.Run(() =>
            //             {
            //                 if (driverEles.Count == 0)
            //                 {
            //                     driverEles = driver.FindElements(By.CssSelector(Selector.CSS));
            //                 }
            //             }
            //         );

            //         tasks.Add(cssTask);
            //     }

            //     Task.WaitAll(tasks.ToArray());
            // }
            // catch
            // {
            //     Console.WriteLine("element check failed");
            // }
            // Parallel.Invoke(
            //     () =>
            //     {
            //         // if we've been provided the identifier type 
            //         // and the web element hasn't already been found
            //         if (!string.IsNullOrWhiteSpace(Selector.XPath) && driverEles.Count == 0)
            //         {
            //             driverEles = driver.FindElements(By.XPath(Selector.XPath));
            //         }
            //     },
            //     () =>
            //     {
            //         if (!string.IsNullOrWhiteSpace(Selector.Id) && driverEles.Count == 0)
            //         {
            //             driverEles = driver.FindElements(By.Id(Selector.Id));
            //         }
            //     },
            //     () =>
            //     {
            //         if (!string.IsNullOrWhiteSpace(Selector.Name) && driverEles.Count == 0)
            //         {
            //             driverEles = driver.FindElements(By.Name(Selector.Name));
            //         }
            //     },
            //     () =>
            //     {
            //         if (!string.IsNullOrWhiteSpace(Selector.ClassName) && driverEles.Count == 0)
            //         {
            //             driverEles = driver.FindElements(By.ClassName(Selector.ClassName));
            //         }
            //     },
            //     () =>
            //     {
            //         if (!string.IsNullOrWhiteSpace(Selector.TagName) && driverEles.Count == 0)
            //         {
            //             driverEles = driver.FindElements(By.TagName(Selector.TagName));
            //         }
            //     },
            //     () =>
            //     {
            //         if (!string.IsNullOrWhiteSpace(Selector.LinkText) && driverEles.Count == 0)
            //         {
            //             driverEles = driver.FindElements(By.LinkText(Selector.LinkText));
            //         }
            //     },
            //     () =>
            //     {
            //         if (!string.IsNullOrWhiteSpace(Selector.PartialLinkText) && driverEles.Count == 0)
            //         {
            //             driverEles = driver.FindElements(By.PartialLinkText(Selector.PartialLinkText));
            //         }
            //     },
            //     () =>
            //     {
            //         if (!string.IsNullOrWhiteSpace(Selector.CSS) && driverEles.Count == 0)
            //         {
            //             driverEles = driver.FindElements(By.CssSelector(Selector.CSS));
            //         }
            //     }
            // );

            WebElement = driverEles.Count > 0 ? driverEles[0] : null;
        }
    }
}
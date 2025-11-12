using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OpenQA.Selenium;

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
                WebElementFound?.Invoke(this, EventArgs.Empty);
            }
        }

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

        public Element()
        {
            
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.UI;

namespace Bucket.WebAutomation.Elements
{
    public abstract class Select : Element
    {
        public List<string> Options { get; set; }

        protected Select(
            string className = "",
            string css = "",
            string id = "",
            string name = "",
            string linkText = "",
            string partialLinkText = "",
            string tagName = "",
            string xpath = "") 
                : base(className, css, id, name, linkText, partialLinkText, tagName, xpath)
        {
            WebElementFound += RetrieveOptions;
        }

        public void RetrieveOptions(object sender, EventArgs e)
        {
            // would be good to fire this when the element is found
            var selectEle = new SelectElement(WebElement);

            foreach (var option in selectEle.Options)
            {
                Options.Add(option.Text);
            }
        }
    }
}
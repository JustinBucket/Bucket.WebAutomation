using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bucket.WebAutomation.Elements
{
    public class Input : Element
    {

        public Input(string className = "", string css = "", string id = "", string name = "", string linkText = "", string partialLinkText = "", string tagName = "", string xpath = "") : base(className, css, id, name, linkText, partialLinkText, tagName, xpath)
        {
            WebElementFound += RetrieveInputText;
        }
        public string Text { get; private set; }
        public void RetrieveInputText(object sender, EventArgs e)
        {
            GetText();
        }

        public void GetText()
        {
            Text = WebElement.GetAttribute("value");
        }

        public void TypeInto(string text)
        {
            if (WebElement == null)
            {
                FindElement();
            }

            WebElement.SendKeys(text);
        }
    }
}
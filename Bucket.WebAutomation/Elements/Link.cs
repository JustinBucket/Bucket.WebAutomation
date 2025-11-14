using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bucket.WebAutomation.Elements
{
    public class Link : Element
    {
        public Link(
            string className = "",
            string css = "",
            string id = "",
            string name = "",
            string linkText = "",
            string partialLinkText = "",
            string tagName = "",
            string xpath = "") 
                
                : base(
                    className,
                    css,
                    id,
                    name,
                    linkText,
                    partialLinkText,
                    tagName,
                    xpath)
        {
            WebElementFound += RetrieveLinkAddress;
        }

        public string LinkAddress { get; private set; }

        public void RetrieveLinkAddress(object sender, EventArgs e)
        {
            // link is stored as the href attribute
            LinkAddress = WebElement.GetAttribute("href");
        }

        
    }
}
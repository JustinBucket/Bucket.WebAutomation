using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bucket.WebAutomation;
using Bucket.WebAutomation.Browser;
using Testing.TestElements;

namespace Testing
{
    [TestClass]
    public class TestSelect
    {
        [TestMethod]
        public void TestOptionRetrieval()
        {
            var browser = new WebBrowser(BrowserType.Edge);
            browser.NavigateToUrl("https://formsmarts.com/html-form-example");

            var selectElement = new FormExampleSelect();
            browser.FindElement(selectElement);

            Assert.IsTrue(selectElement.Options.Count > 0);
        }
    }
}
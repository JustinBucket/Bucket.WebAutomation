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
    public class TestElement
    {
        [TestMethod]
        public void TestOptionRetrieval()
        {
            var browser = new WebBrowser(BrowserType.Edge);
            browser.NavigateToUrl("https://www.telerik.com/blogs/understanding-parallel-programming-aspnet-core");

            var selectElement = new TestSelect();
            browser.FindElement(selectElement);
            browser.Close();

            Assert.IsTrue(selectElement.Options.Count > 0);
        }

        [TestMethod]
        public void TestLinkRetrieval()
        {
            var browser = new WebBrowser(BrowserType.Edge);
            browser.NavigateToUrl("https://www.lcbo.com/en/recipe/vegetable-cheese-strudel/200105024");

            var linkElement = new TestLink();
            browser.FindElement(linkElement);
            browser.Close();

            Assert.AreEqual(
                @"https://www.lcbo.com/content/lcbo/en/corporate-pages/faq.html#how-do-i-track-my-order", 
                linkElement.LinkAddress);
        }
    }
}
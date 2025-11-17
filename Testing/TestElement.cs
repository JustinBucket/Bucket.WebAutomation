using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
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

            var selectElement = browser.CreateElement<TestSelect>();
            selectElement.ElementExists();
            browser.Close();

            Assert.IsTrue(selectElement.Options.Count > 0);
        }

        [TestMethod]
        public void TestLinkRetrieval()
        {
            var browser = new WebBrowser(BrowserType.Edge);
            browser.NavigateToUrl("https://www.lcbo.com/en/recipe/vegetable-cheese-strudel/200105024");

            var linkElement = browser.CreateElement<TestLink>();
            linkElement.ElementExists();
            browser.Close();

            Assert.AreEqual(
                @"https://www.lcbo.com/content/lcbo/en/corporate-pages/faq.html#how-do-i-track-my-order", 
                linkElement.LinkAddress);
        }

        [TestMethod]
        public void TestMultipleSelectorStrategyOneFailOneSuccess()
        {
            // TODO: this test is failing
            // intermittent - maybe a loading thing?
            var browser = new WebBrowser(BrowserType.Edge);
            browser.NavigateToUrl("https://www.pathofexile.com/");
            
            // Thread.Sleep(5000);

            var linkElement = browser.CreateElement<DualSelectorLink>();
            var eleExists = linkElement.ElementExists();
            browser.Close();

            Assert.IsTrue(eleExists);
            Assert.AreEqual(
                @"https://www.pathofexile.com/account/create", 
                linkElement.LinkAddress);
        }

        [TestMethod]
        public void TestInputEntry()
        {
            var browser = new WebBrowser(BrowserType.Edge);
            browser.NavigateToUrl("https://secure.royalbank.com/statics/login-service-ui/index#/full/signin?_gl=1*1fz79nq*_gcl_au*NzI0MzM1ODM4LjE3NjMyNzMyOTE.*_ga*OTMzODMxNS4xNzYzMjczMjky*_ga_89NPCTDXQR*czE3NjMyNzMyOTEkbzEkZzAkdDE3NjMyNzMyOTIkajU5JGwwJGgw&LANGUAGE=ENGLISH");

            Thread.Sleep(1000);

            var inputElement = browser.CreateElement<TestInput>();
            inputElement.TypeInto("test");
            inputElement.GetText();

            browser.Close();

            Assert.AreEqual("test", inputElement.Text);
        }
    }
}
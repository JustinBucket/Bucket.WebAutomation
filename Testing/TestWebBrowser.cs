using Bucket.WebAutomation;
using Bucket.WebAutomation.Browser;
using OpenQA.Selenium.Edge;

namespace Testing;

[TestClass]
public class TestWebBrowser
{
    [TestMethod]
    public void TestWebBrowserInstantion()
    {
        var browser = new WebBrowser(BrowserType.Edge);

        Assert.IsTrue(browser.Driver.GetType().IsAssignableFrom(typeof(EdgeDriver)));

        browser.Close();
    }

    [TestMethod]
    public void TestLaunch()
    {
        var browser = new WebBrowser(BrowserType.Edge);
        browser.Launch();
        browser.Close();

        // Assert.AreEqual("Example Domain", browser.Driver.Title);
    }

    [TestMethod]
    public void TestNavigateToUrl()
    {
        var browser = new WebBrowser(BrowserType.Edge);
        browser.Launch();
        browser.NavigateToUrl("https://www.google.com");

        Assert.AreEqual("https://www.google.com/", browser.Driver.Url);

        browser.Close();
    }
    
}
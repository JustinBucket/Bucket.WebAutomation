using Bucket.WebAutomation;
using Bucket.WebAutomation.Browser;

namespace Testing;

[TestClass]
public class TestWebBrowser
{
    [TestMethod]
    public void TestWebBrowserInstantion()
    {
        var browser = new WebBrowser(BrowserType.Edge);

        Assert.AreEqual(BrowserType.Edge, browser.Type);
    }

    [TestMethod]
    public void TestLaunch()
    {
        var browser = new WebBrowser(BrowserType.Edge);
        browser.Launch();

        // Assert.AreEqual("Example Domain", browser.Driver.Title);
    }
    
    [TestMethod]
    public void TestNavigateToUrl()
    {
        var browser = new WebBrowser(BrowserType.Edge);
        browser.Launch();
        browser.NavigateToUrl("https://www.google.ca");

        // Assert.AreEqual("Example Domain", browser.Driver.Title);
    }
}
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
        browser.NavigateToUrl("https://www.google.com");

        Assert.AreEqual("https://www.google.com/", browser.Driver.Url);

        browser.Close();
    }

    [TestMethod]
    public void TestOpenGoogleAbout()
    {
        var browser = new WebBrowser(BrowserType.Edge);
        browser.Launch();
        browser.NavigateToUrl("https://www.google.com/");

        var prefLink = new GoogleAboutLink();
        browser.Click(prefLink);

        Assert.AreEqual("https://about.google/?fg=1&utm_source=google-CA&utm_medium=referral&utm_campaign=hp-header", browser.Driver.Url);

        browser.Close();
    }
}
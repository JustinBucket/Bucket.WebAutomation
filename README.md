# Bucket.WebAutomation

Bucket.WebAutomation provides a wrapper for the Selenium.NET library to simplify tasks for the purpose of business process automation.

## Installation

Use the dotnet add command to install Bucket.WebAutomation.

```bash
dotnet add Bucket.WebAutomation
```

## Usage
### Example element
```csharp
// Create element objects to represent elements from the target webpage
using Bucket.WebAutomation.Elements;

namespace Testing.TestElements
{
    public class TestLink : Link
    {
        public TestLink()
            : base(className: "track-order-header-link")
        {
            
        }
    }
}
```
### Example usage
```csharp
class Program
{
    static void Main(string[] args)
    {
        [TestMethod]
        public void TestInputEntry()
        {
            // Create a WebBrowser object, passing the desired browser type
            var browser = new WebBrowser(BrowserType.Edge);
            
            // Navigate to the target site
            browser.NavigateToUrl("https://secure.royalbank.com/statics/login-service-ui/index#/full");

            // Create a copy of the desired element
            var inputElement = browser.CreateElement<TestInput>();
            // send text to the element
            inputElement.TypeInto("test");

            // close out the browser
            browser.Close();
        }
    }
}
```
## License

[MIT](https://choosealicense.com/licenses/mit/)

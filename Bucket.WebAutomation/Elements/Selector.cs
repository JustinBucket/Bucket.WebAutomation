using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bucket.WebAutomation.Elements
{
    public class Selector
    {
        public string ClassName { get; set; }
        public string CSS { get; set; }
        public string Id { get; set; }
        public string Name { get; set; }
        public string LinkText { get; set; }
        public string PartialLinkText { get; set; }
        public string TagName { get; set; }
        public string XPath { get; set; }
    }
}
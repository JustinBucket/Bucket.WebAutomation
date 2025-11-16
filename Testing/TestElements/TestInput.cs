using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bucket.WebAutomation.Elements;

namespace Testing.TestElements
{
    public class TestInput : Input
    {
        public TestInput()
            : base(id: "userName")
        { }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bucket.WebAutomation.Elements;

namespace Testing.TestElements
{
    public class TestSelect : Select
    {
        //<select name="u_duC_338367" id="u_duC_338367" aria-required="true">
        public TestSelect()
            : base(id: "Country-1")
        {
            
        }
    }
}
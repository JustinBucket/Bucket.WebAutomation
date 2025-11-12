using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bucket.WebAutomation.Elements;

namespace Testing.TestElements
{
    public class RwCoWomenLink : Element
    {
        // <a href="https://www.rw-co.com/en/women" class="level-1" id="category-women-link" data-id="women" data-name="Women">Women</a>
        public RwCoWomenLink()
            : base(id: "category-women-link")
        { }
    }
}
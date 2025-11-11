using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bucket.WebAutomation
{
    // idea here is that consumers can create concrete elements
    // representing specific elements they want to interact with
    // e.g. LoginButton, DateOfBirthDropdown, etc.
    // elements can then be passed as arguments to browser methods
    public abstract class Element
    {
        public string Selector { get; set; }
    }
}
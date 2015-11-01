using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Decorator1
{
    abstract class Component
    {
        public string text;
        public abstract string ViewText();
    }
}

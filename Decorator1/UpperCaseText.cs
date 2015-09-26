using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Decorator1
{
    class UpperCaseText : Component
    {
        string addUpperCaseText = " (UpperCaseText)";

        Component Component;

        public UpperCaseText(Component component)
        {
            Component = component;
        }

        public override string  ViewText()
        {
            if (Component.ViewText().Contains(addUpperCaseText))
                return Component.ViewText();
            return Component.ViewText() + addUpperCaseText;
        }

        public override string ToString()
        {
            return this.ViewText();
        }
    }
}

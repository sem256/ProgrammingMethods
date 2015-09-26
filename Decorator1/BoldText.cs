using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Decorator1
{
    class BoldText : Component// клас робить текст жирним
    {
        string addBoldText = " (BoldText) ";

        Component Component;

        public BoldText(Component component)
        {
            Component = component;
        }

        public override string ViewText()
        {
            if (Component.ViewText().Contains(addBoldText))
                return Component.ViewText();
            return Component.ViewText() + addBoldText;
        }
        public override string ToString()
        {
            return this.ViewText();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Decorator1
{
    class UnderLineText : Component// клас декорує текст підкресленням
    {
        string addUnderLineText = " (UnderLineText)";
        Component Component;

        public UnderLineText(Component component)
        {
            Component = component;
        }

        public override string  ViewText()//перевизначаємо метод, щоб відповідав класу
        {
            if (Component.ViewText().Contains(addUnderLineText))
                return Component.ViewText().Replace(addUnderLineText,"");
            return Component.ViewText() + addUnderLineText;
        }
        public override string ToString()
        {
            return this.ViewText();
        }
    }
}

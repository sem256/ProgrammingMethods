using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Decorator1
{
    class PrimaryText : Component// конкретний клас з текстом
    {
        public PrimaryText(string text)
        {
            base.text = text;
        }

        public override string ViewText()
        {
            return text;
        }
        public override string ToString()
        {
            return this.ViewText();
        }
    }
}

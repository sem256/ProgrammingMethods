using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Decorator1
{
    class Program
    {
        static void Display(Component c)
        {
            Console.WriteLine(c.ToString());
        }
        static void Main(string[] args)
        {
            Component primaryText = new PrimaryText("I love С# ");// створюємо початковий текст

            Display(new UpperCaseText(new BoldText(new BoldText(new BoldText(new UnderLineText(new UpperCaseText(primaryText)))))));// вивід на екран результату
            Console.ReadKey();
        }
    }
}

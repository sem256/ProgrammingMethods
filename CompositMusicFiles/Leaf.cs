using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CompositMusicFiles
{
    [Serializable]
    class Leaf : Component
    {
        // клас для роботи з листками
        public Leaf(string name)
            : base(name)
        {
        }
        public override void Operation(int values = 0)
        {
            values += 1;
            Console.WriteLine(new string(' ', values * 2) + name);
        }
        public override void Add(Component component)
        {
            throw new InvalidOperationException();
        }
        public override void Remove(Component component)
        {
            throw new InvalidOperationException();
        }
        public override Component GetChild(int index)
        {
            throw new InvalidOperationException();
        }
        public override int Length()
        {
            return -1;
        }
        public override string GetName()
        {
            return name;
        }
    }
}

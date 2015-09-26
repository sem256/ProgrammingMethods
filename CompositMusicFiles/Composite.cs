using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CompositMusicFiles
{
    [Serializable]
    class Composite : Component
    {
        // клас для створення гілок
        ArrayList nodes = new ArrayList();
        public Composite(string name)
            : base(name)
        {
        }
        public override void Operation(int values = 1)// метод для відображення
        {
            values += 1;
            Console.WriteLine(new string(' ', values * 2) + name);
            foreach (Component component in nodes)
                component.Operation(values);
        }
        public override void Add(Component component)
        {
            nodes.Add(component);
        }
        public override void Remove(Component component)
        {
            nodes.Remove(component);
        }
        public override Component GetChild(int index)
        {
            return nodes[index] as Component;
        }
        public override int Length()
        {
            return nodes.Count;
        }
        public override string GetName()
        {
            return name;
        }
    }
}

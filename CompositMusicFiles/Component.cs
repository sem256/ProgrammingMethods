using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CompositMusicFiles
{
    [Serializable]
    abstract class Component
    {
        protected string name;
        public Component(string name)
        {
            this.name = name;
        }
        public abstract void Operation(int values = 0);
        public abstract void Add(Component component);// для створення елемента
        public abstract void Remove(Component component);// для видалення елемента
        public abstract Component GetChild(int index);// знаходження елемента по індексу
        
        public abstract int Length();// отримуємо довжину елемента
        public abstract string GetName();// отримуємо імя елемента
    }



}

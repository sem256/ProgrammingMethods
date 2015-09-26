using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace CompositMusicFiles
{
    [Serializable]
    class MusicFiles : IMusicFilesPrototype<MusicFiles>
    {
        public Component Root { get; set; }

        public MusicFiles(Component root)
        {
            Root = root;
        }

        // метод який за допомогою итерації проходить по дереву
        private void DeepCopyIterativeMethod(Component copyElement, Component father, int number)
        {
            if (number != 0)
            {
                int length = father.Length();
                switch (length)// перевіка який елемент ми отримали
                {
                        // якщо гілка без листя та інших гілок
                    case 0: copyElement.Add((Component)new Composite(father.GetName()));
                        break;
                        // якщо листок
                    case -1: copyElement.Add((Component)new Leaf(father.GetName()));
                        break;
                        // якщо гілка з нащадками
                    default:
                        {
                            copyElement.Add((Component)new Composite(father.GetName()));
                            for (int i = 0; i < length; i++)
                                DeepCopyIterativeMethod(copyElement.GetChild(copyElement.Length() - 1), father.GetChild(i), number - 1);
                        }
                        break;
                }
            }
            else
                number += 1;// збільшуємо рахівник щоб потрапити на рівень више по дереву
        }

        // копіювання( створення нового елемента з певнім параметром глибини)
        public MusicFiles DeepCopyWithNumber(int number)
        {
            Component copyElement = new Composite(Root.GetName());
            for (int i = 0; i < Root.Length(); i++)
                DeepCopyIterativeMethod(copyElement, Root.GetChild(i), number - 1);

            return new MusicFiles(copyElement);
        }

        public override string ToString()// метод для зображення на екран
        {
            Root.Operation();
            return "";
        }
    }
}

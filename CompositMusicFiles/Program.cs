using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CompositMusicFiles
{
    class Program
    {
        static Component root;
        static void Main(string[] args)
        {
            // завовнюємо композит
            root = new Composite("Music File");

            Component Genre1 = new Composite("Rap");
            Component Genre2 = new Composite("Rock");

            Component Performer1_1 = new Composite("Eminem");
            Component Performer1_2 = new Composite("Noize MC");
            Component Performer2_1 = new Composite("Rock Performer");

            Component leaf1_1_1 = new Leaf("The slim shady lp");
            Component leaf1_1_2 = new Leaf("Recovery");


            Component leaf1_2_1 = new Leaf("Выдыхай");
            Component leaf1_2_2 = new Leaf("Nokia 3310");

            root.Add(Genre1);
            root.Add(Genre2);

            Genre1.Add(Performer1_1);
            Genre1.Add(Performer1_2);

            Performer1_1.Add(leaf1_1_1);
            Performer1_1.Add(leaf1_1_2);

            Performer1_2.Add(leaf1_2_1);
            Performer1_2.Add(leaf1_2_2);

            // створюємо екземпляр класу 
            MusicFiles m = new MusicFiles(root);
            m.ToString();
            Console.WriteLine(new string('-', 20));

            var m1 = m.DeepCopyWithNumber(4);
            m1.ToString();

            Console.ReadKey();
        }
        public static void Operation()
        {

        }
    }
}

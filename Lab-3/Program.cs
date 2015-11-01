using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lab_3
{
    class Program
    {
        static void Main(string[] args)
        {
            Context context = new Context();
            context.EstablishedClosed();//передача та закриття звязку

            Console.WriteLine(new string('-', 30));
            context.EstablishedListening();//передача та  підтримка звязку 

            Console.WriteLine(new string('-', 30));
            context.EstablishedClosed();//передача та закриття звязку
            
            Console.ReadKey();
        }
    }

    interface State
    {
        void Up(Context context);
        void Down(Context context);
    }

    // конкретний стан
    class Closed : State
    {
        public void Up(Context context)
        {
            context.State = context.ListeningState;
            Console.WriteLine("--Closed up to Listening");
            ClosedState();
        }

        public void Down(Context context)
        {
            Console.WriteLine("--Closed");
        }

        public void ClosedState()
        {
            Console.WriteLine("(Step 1 of the 3-way-handshake)");
        }
    }

    // конкретний стан
    class Established : State
    {
        public void Up(Context context)
        {
            context.State = context.ClosedState;
            Console.WriteLine("--Established up to Closed");
            EstablishedToClose();
        }

        public void Down(Context context)
        {
            context.State = context.ListeningState;
            Console.WriteLine("--Established down to Listening");
            EstablishedToListening();
        }

        public void EstablishedToClose()
        {
            Console.WriteLine("CLOSE/FIN or FIN/ACK");
        }
        public void EstablishedToListening()
        {
            Console.WriteLine("SYN/SYN+ACK (simultaneous open)");
        }
    }

    // конкретний стан
    class Listening : State
    {
        public void Up(Context context)
        {
            context.State = context.EstablishedState;
            Console.WriteLine("--Listening up to Established");
            ListeningToEstablished();
        }

        public void Down(Context context)
        {
            context.State = context.ClosedState;
            Console.WriteLine("--Listening down to Closed");
            ListeningToClose();
        }
        public void ListeningToEstablished()
        {
            Console.WriteLine("SYN/SYN+ACK");
        }
        public void ListeningToClose()
        {
            Console.WriteLine("CLOSE/- unusual event");
        }
    }

    class Context
    {
        internal State ClosedState, ListeningState, EstablishedState;

        public State State { get; set; }

        public Context()
        {// ініціалізація станів
            this.ClosedState = new Closed();
            this.ListeningState = new Listening();
            this.EstablishedState = new Established();
            this.State = ClosedState;
        }

        public void EstablishedClosed()  // обробка запиту
        {
            if (State.GetType() == ClosedState.GetType())//якщо в стані ClosedState
            {
                State.Up(this);// перехів в стан ListeningState
                State.Up(this);// перехів в стан EstablishedState
                State.Up(this);// перехів в стан ClosedState
            }
            else
            {
                if (State.GetType() == ListeningState.GetType())//якщо в стані ListeningState
                {
                    State.Up(this);// перехів в стан EstablishedState
                    State.Up(this);// перехів в стан ClosedState
                }
                else
                    Console.WriteLine("state EstablishedState is work");
            }
        }

        public void ChangedStateToClosed()// закрыття зєднання при будь якій умові
        {
            if (State.GetType() == ListeningState.GetType())
                State.Down(this);// перехів в стан ClosedState

            if (State.GetType() == EstablishedState.GetType())
                State.Up(this);// перехів в стан ClosedState
        }

        public void ChangedStateToListening()// перехід в Listening при будь якій умові
        {
            if (State.GetType() == ClosedState.GetType())
                State.Up(this);// перехів в стан ClosedState

            if (State.GetType() == EstablishedState.GetType())
                State.Down(this);// перехів в стан ClosedState
        }

        public void EstablishedListening()  // обробка запиту
        {
            if (State.GetType() == ClosedState.GetType())//якщо в стані ClosedState
            {
                State.Up(this);// перехів в стан ListeningState
                State.Up(this);// перехів в стан EstablishedState
                State.Down(this);// перехів в стан ListeningState
            }
            else
            {
                if (State.GetType() == ListeningState.GetType())//якщо в стані ListeningState
                {
                    State.Up(this);// перехів в стан EstablishedState
                    State.Down(this);// перехів в стан ListeningState
                }
                else
                    Console.WriteLine("state EstablishedState is work");
            }
        }
        
    }
}
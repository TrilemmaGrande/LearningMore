using System;

namespace Aufgabe.Event
{
    class MyEventArgs : EventArgs
    {
        private string operation { get; }

        public MyEventArgs(string operation)
        {
            this.operation = operation;
        }
    }
}

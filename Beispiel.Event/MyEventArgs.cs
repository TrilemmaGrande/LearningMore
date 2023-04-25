namespace Beispiel.Event
{
    class MyEventArgs : EventArgs
    {
        private string operation;
        private string reason;

        public MyEventArgs(string operation, string reason)
        {
            this.operation = operation;
            this.reason = reason;
        }
        public string GetOperation()
        {
            return this.operation;
        }
        public string GetReason()
        {
            return this.reason;
        }
    }

}
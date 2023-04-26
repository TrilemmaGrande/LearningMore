namespace Beispiel.Event
{
    class AuslaufenEventArgs : EventArgs
    {
        private string operation;
        private string reason;
        private string beispielText;

        public AuslaufenEventArgs(string operation, string reason, string beispielText)
        {
            this.operation = operation;
            this.reason = reason;
            this.beispielText = beispielText;
        }
        public string GetOperation()
        {
            return this.operation;
        }
        public string GetReason()
        {
            return this.reason;
        }
        public string GetBeispielText()
        {
            return this.beispielText;
        }
    }

}
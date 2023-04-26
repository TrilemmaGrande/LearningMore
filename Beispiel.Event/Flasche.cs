namespace Beispiel.Event
{
    class Flasche
    {
        private string myString = "hier ist ein Beispiel";


        public event EventHandler<AuslaufenEventArgs> OnAuslaufen;
        public void Auslaufen()
        {
            Console.WriteLine("Das hier kommt aus Flasche - Die Flasche läuft aus!");
            OnAuslaufen?.Invoke(this, new AuslaufenEventArgs("Flasche.Auslaufen()", "geplatzt", myString));
        }   
    }

}
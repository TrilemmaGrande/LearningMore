namespace Beispiel.MVC
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Repository r = new Repository();
            View v = new View(r);

            v.ShowData();

            string s = string.Empty;

            do
            {
                s = Console.ReadLine();
                if (s != string.Empty)
                {
                    if (s[0] == '-')
                    {
                        r.RemoveData(s.Substring(1));
                    }
                    else
                    {
                        r.AddData(s);
                    }
                }
            } while (s != string.Empty);
        }
    }
}
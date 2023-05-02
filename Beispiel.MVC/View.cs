using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beispiel.MVC
{
    internal class View
    {
        private Repository repo;
        public View(Repository repo)
        {
            this.repo = repo;
            this.repo.DataChanged += ShowData;
        }
        public void ShowData()
        {
            List<string> liste = repo.GetAllData();

            Console.Clear();
            Console.WriteLine("Datenbestand:");
            foreach (string s in liste)
            {
                Console.WriteLine(s);
            }
            Console.WriteLine();
        }
    }
}

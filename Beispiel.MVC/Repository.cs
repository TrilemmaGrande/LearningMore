using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beispiel.MVC
{
    internal class Repository
    {
        private List<string> dataList;
        private Action dataChanged;
        public event Action DataChanged
        {
            add { dataChanged += value; }
            remove { dataChanged -= value;  }
        }
        public Repository()
        {
            dataList = new List<string>() { "Hallo", "C#" };
        }
        public void AddData(string s)
        {
            dataList.Add(s);
            dataChanged?.Invoke();
        }
        public void RemoveData(string s)
        {
            dataList.Remove(s);
            dataChanged?.Invoke();
        }
        public List<string> GetAllData()
        {
            return dataList;
        }
    }

}

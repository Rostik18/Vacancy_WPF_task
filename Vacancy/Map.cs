using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vacancy.Model;

namespace Vacancy
{
    class MapOfEmployee : IEnumerable
    {
        private List<Employee> list;

        public MapOfEmployee()
        {
            list = new List<Employee>();
        }

        public void Add(Employee item)
        {
            foreach (var _item in list)
            {
                if (_item.GetName() == item.GetName()) return;
            }
            list.Add(item);
        }

        public void RemoveAt(int id)
        {
            list.RemoveAt(id);
        }
        public void Sort()
        {
            list.Sort();
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable<Employee>)list).GetEnumerator();
        }
    }
}

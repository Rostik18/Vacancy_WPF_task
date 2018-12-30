using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vacancy.Model
{
    class Employee : IComparable<Employee>
    {
        private string name;
        private string position;
        private Birthday birthday;
        private int old;

        public Employee(Birthday _birthday, string _name = "", string _position = "")
        {
            name = _name;
            position = _position;
            birthday = _birthday;
            old = birthday.GetOld();
        }
        public Employee(string _name = "", string _position = "", int _d = 0, int _m = 0, int _y = 0)
        {
            name = _name;
            position = _position;
            birthday = new Birthday(_d, _m, _y);
            old = birthday.GetOld();
        }
        public override string ToString()
        {
            return $"{name} працює на позиції: {position}.   Вік: {old}";
        }
        public string GetName() { return name; }
        public int CompareTo(Employee p)
        {
            return this.name.CompareTo(p.name);
        }
    }

    class Birthday
    {
        private int d;
        private int m;
        private int y;
        private const int toD = 28, toM = 12, toY = 2018;
        public Birthday(int _d = 0, int _m = 0, int _y = 0)
        {
            d = _d;
            m = _m;
            y = _y;
        }
        public int GetOld()
        {
            if (toM > m && toD > d)
                return toY - y;
            else return toY - y + 1;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Vacancy.Model;

namespace Vacancy
{
    public partial class MainWindow : Window
    {
        List<Employee> Piple;
        List<Employee> Workers;
        public MainWindow()
        {
            InitializeComponent();
            Piple = new List<Employee>();
            Workers = new List<Employee>();
        }
        private void Add_button_Click(object sender, RoutedEventArgs e)
        {
            string name = NameBox.Text;
            string position = positionBox.Text;
            Birthday birthday = GetBirthday(birthdayBox.Text);

            Piple.Add(new Employee(birthday, name, position));
            if (position == "працівник")
                Workers.Add(new Employee(birthday, name, position));

            Piple.Sort();
            Workers.Sort();

            WorkersList.Items.Clear();
            PipleList.Items.Clear();

            foreach(var person in Piple)
            {
                PipleList.Items.Add(person);
            }
            foreach (var person in Workers)
            {
                WorkersList.Items.Add(person);
            }

            //Messeger.Text = "work";
        }

        private void Del_button_Click(object sender, RoutedEventArgs e)
        {
            string name = NameBox.Text;
            for (int i = 0; i < PipleList.Items.Count; i++)
            {
                Employee person = (Employee)PipleList.Items[i];
                if (person.GetName() == name)
                {
                    int id = PipleList.Items.IndexOf(person);
                    PipleList.Items.RemoveAt(id);
                }
            }
            for (int i = 0; i < WorkersList.Items.Count; i++)
            {
                Employee person = (Employee)WorkersList.Items[i];
                if (person.GetName() == name)
                {
                    int id = WorkersList.Items.IndexOf(person);
                    WorkersList.Items.RemoveAt(id);
                }
            }
        }

        private void EditPost(object sender, RoutedEventArgs e)
        {
            //Employee emp = (Employee)sender;
            MessageBox.Show("шось");
        }

        private Birthday GetBirthday(string data)
        {
            int d, m, y;

            List<int> rez = new List<int>();
            string local = "";
            for (int i = 0; i < data.Length; i++)
            {
                while (true)
                {
                    if (data[i] != ' ' && data[i] != '.' && data[i] != '/' && data[i] != ',')
                    {
                        local += data[i];
                        i++;
                        if (i == data.Length) break; //Костиль.
                    }
                    else break;
                }
                if (local != "")
                {
                    rez.Add(Convert.ToInt32(local));
                    local = "";
                }
            }
            d = rez[0];
            m = rez[1];
            y = rez[2];
            return new Birthday(d, m, y);
        }
    }
}

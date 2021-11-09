using AngleSharp.Dom;
using AngleSharp.Html.Parser;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using WpfApp1.Control;
using WpfApp1.Controls;
using WpfApp1.Models;

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            textBoxt();
        }
        private void textBoxt()
        {
            string x = "Горобчук Александр";
            textBoxName.Text = x;
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            //Employee employee = new Employee(textBoxName.Text);
            //await employee.searcheCv();

            
            await addDb();
            

        }

        private async Task addDb() {

            using (ApplicationContext db = new ApplicationContext())
            {
                db.Database.EnsureCreated();
                EmployeeDb employee = new EmployeeDb();
                HumanDb hDb = new HumanDb(); 
                hDb.Name = "Александр";
                hDb.SurName = "Горобчук";
                employee.humanDb = hDb;
                db.Add(employee);
                db.SaveChangesAsync();
            }

        }
    }
}

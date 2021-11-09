using AngleSharp.Dom;
using AngleSharp.Html.Parser;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using WpfApp1.Control;

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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Employee employee = new Employee(textBoxName.Text);
            employee.searcheCv();
            //textBoxName.Text = employee._CvWorkUa.Id.ToString();
            //textBoxName.Text = textBoxName.Text + Environment.NewLine + employee._CvRabotaUa.Id.ToString();
            Console.ReadLine();
        }
    }
}

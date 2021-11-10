using AngleSharp.Dom;
using AngleSharp.Html.Parser;
using System;
using System.Collections.Generic;
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
            Employee employee2 = new Employee(textBoxName.Text);
            await employee2.searcheCv();


            await InserEmployee(employee2);
        }

        private async Task InserEmployee(Employee value) {

            using (ApplicationContext db = new ApplicationContext())
            {
                db.Database.EnsureCreated();
                EmployeeDb EmployeeDb = new EmployeeDb();
                db.Add(EmployeeDb);
                db.SaveChanges();
                

                HumanDb Hdb = new HumanDb() {Name = value.Name, SurName = value.SurName, EmployeeDb = EmployeeDb};                
                db.HumanDbs.Add(Hdb);
                db.SaveChanges();
                //try {
                //    List<WorkUaDb> workUas = new List<WorkUaDb>();
                //    foreach (var item in value.ListWorkUa.cvWorkUas)
                //    {
                //        WorkUaDb obj = new WorkUaDb();
                //        obj.Link = item.Link;
                //        obj.City = item.City;
                //        obj.UpdateDate = item.UpdateDate;
                //        obj.Speciality = item.Speciality;
                //        obj.EmployeeDb = EmployeeDb;
                //        workUas.Add(obj);
                //        db.WorkUaDb.Add(obj);
                //        db.SaveChanges();
                //    }
                //} catch (Exception e) { }
                
                //db.workUaDb.AddRange(workUas);
                //db.SaveChanges();
                //List<RabotaUaDb> rabotaUas = new List<RabotaUaDb>();

                //foreach (var item in value.ListRabotaUa.cvRabotaUas)
                //{
                //    RabotaUaDb obj = new RabotaUaDb();
                //    obj.Link = item.Link;
                //    obj.City = item.City;
                //    obj.UpdateDate = item.UpdateDate;
                //    obj.Speciality = item.Speciality;
                //    rabotaUas.Add(obj);
                //}

                //employee.workUas.AddRange(workUas);
                //employee.rabotaUas.AddRange(rabotaUas);

                //db.workUaDb.AddRange(workUas);
                //db.rabotaUaDb.AddRange(rabotaUas);

            }

        }
    }
}

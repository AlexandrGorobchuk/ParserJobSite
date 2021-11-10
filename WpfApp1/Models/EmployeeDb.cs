using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.Control;

namespace WpfApp1.Models
{
    public class EmployeeDb
    {
        public int Id { get; set; }
        public  HumanDb humanDb { get; set; }


       // public  List<Cv> rabotaUas { get; set; }
        //public  ICollection<WorkUaDb> WorkUaDbs { get; set; }

        //public EmployeeDb() { 
        //    WorkUaDbs = new List<WorkUaDb>();
        //}
    }
}

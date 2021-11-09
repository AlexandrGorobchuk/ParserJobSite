using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Models
{
    internal class EmployeeDb
    {
        public int Id { get; set; }
        public HumanDb humanDb { get; set; }
        //public List<RabotaUaDb> rabotaUas { get; set; }
        //public List<WorkUaDb> workUas { get; set; }
    }
}

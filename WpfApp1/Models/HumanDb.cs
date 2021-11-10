using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Models
{
    public class HumanDb
    {
        [Key]
        [ForeignKey("EmployeeDb")]
        public int Id { get; set; }
        public string Name { get; set; }
        public string SurName { get; set; }
        public  EmployeeDb EmployeeDb { get; set; }
    }
}

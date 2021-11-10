using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.Control;

namespace WpfApp1.Models
{
    internal class WorkUaDb
    {
        [Key]
        [ForeignKey("EmployeeDb")]
        public int Id { get; set; }
        public string Speciality { get; set; }
        public string City { get; set; }
        public string UpdateDate { get; set; }
        public string Link { get; set; }
        public int? EmployeeDbId { get; set; }
        public EmployeeDb EmployeeDb { get; set; }
    }
}

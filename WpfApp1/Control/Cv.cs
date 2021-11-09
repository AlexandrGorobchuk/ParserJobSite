using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Control
{
    internal class Cv
    {
        public string Id { get; set; }
        public string Speciality { get; set; }
        public string City { get; set; }
        public string UpdateDate { get; set; }
        public string Link { get; set; }

        public string toString()
        {
            return $"Id = {Id}, Speciality = {Speciality}, City = {City}, UpdateDate = {UpdateDate}, Link = {Link}";
        }
    }
}

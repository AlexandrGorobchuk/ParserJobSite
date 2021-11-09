using AngleSharp.Dom;
using AngleSharp.Html.Parser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace WpfApp1.Control
{
    internal class Employee
    {
        public string Name { get; }
        public string SurName { get; }

        public CvRabotaUa _CvRabotaUa = new CvRabotaUa();

        public CvWorkUa _CvWorkUa = new CvWorkUa();

        public Employee(string value)
        {
            string[] values = value.Split(' ');
            this.Name = values[0];
            this.SurName = values[1];
        }
        public async Task searcheCv() {
            List<Task> tasks = new List<Task>();
            await _CvRabotaUa.SearcheCv(Name + " " + SurName);
            await _CvWorkUa.SearcheCv(Name + " " + SurName);
        }
    }
}


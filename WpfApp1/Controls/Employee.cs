using System.Threading.Tasks;

namespace WpfApp1.Control
{
    internal class Employee
    {
        public string Name { get; set; }
        public string SurName { get; set; }
        public ListCvWorkUa ListWorkUa = new ListCvWorkUa();
        public ListCvRabotaUa ListRabotaUa = new ListCvRabotaUa();
        public Employee(string value)
        {
            string[] values = value.Split(' ');
            this.Name = values[0];
            this.SurName = values[1];
        }
        public async Task searcheCv() {
            await ListWorkUa.SearcheCv(Name + " " + SurName);
            await ListRabotaUa.SearcheCv(Name + " " + SurName);
        }
    }

}


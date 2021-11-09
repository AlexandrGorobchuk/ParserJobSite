using AngleSharp.Dom;
using AngleSharp.Html.Parser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Control
{
    internal class Employee
    {
        public string Name { get; }
        public string SurName { get; }
        public Cv _CvRabotaUa { get; }
        public Cv _CvWorkUa { get; }

        public Employee(string value) {
            string[] values = value.Split(' ');
            this.Name = values[0];
            this.SurName = values[1];
            List<Task> tasks = new List<Task>();
            CvRabotaUa CvRabotaUa = new CvRabotaUa();
            
            CvWorkUa CvWorkUa = new CvWorkUa();
            CvWorkUa.SearcheCv(Name + " " + SurName);

            Task.WaitAll();


            if(CvRabotaUa.Id != null)
                this._CvRabotaUa = CvRabotaUa;
            if (CvWorkUa.Id != null)
                this._CvWorkUa = CvWorkUa;
        }
    }

    public class Cv
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

    public class CvRabotaUa : Cv, ICv
    {
        public async void SearcheCv(string value)
        {
            IHtmlParser htmlParser = new HtmlParser();
            string path = $"https://rabota.ua/candidates/{value}/вся_украина?period=\"All\"&searchType=\"everywhere\"";
            using (HttpClient httpClient = new HttpClient())
            {
                IDocument html = await htmlParser.ParseDocumentAsync(await httpClient.GetStringAsync(path));
                var collect = html.QuerySelectorAll("section.cv-card");
                if (collect.Count() > 0)
                {
                    this.Link = collect[0].QuerySelector("a.santa-no-underline").GetAttribute("href");
                    this.Id = this.Link.Split('/').Last();
                    this.City = collect[0].QuerySelector("p.santa-typo-secondary").Text();
                    this.Speciality = collect[0].QuerySelector("p.santa-m-0.santa-typo-h3.santa-pb-10").Text();
                    this.UpdateDate = collect[0].QuerySelector("p.santa-typo-additional.santa-text-black-500.santa-mr-20").Text();
                }
                Task.Delay(3000);
            }
            

        }
    }

    public class CvWorkUa : Cv, ICv
    {
        public async void SearcheCv(string value)
        {
            IHtmlParser htmlParser = new HtmlParser();
            string path = $"https://www.work.ua/resumes-{value}?notitle=1&period=6";
            using (HttpClient httpClient = new HttpClient())
            {
                IDocument html = await htmlParser.ParseDocumentAsync(await httpClient.GetStringAsync(path));
                var collect = html.QuerySelectorAll("#pjax-resume-list div:nth-child(2)");
                this.Link = "https://www.work.ua" + collect[0].QuerySelector("h2 a").GetAttribute("href");
                this.Id = collect[0].QuerySelector("h2 a").GetAttribute("href").Split('/')[2];
                this.City = collect[0].QuerySelector("div span:nth-child(5)").Text();
                this.Speciality = collect[0].QuerySelector("h2 a").GetAttribute("Title");
                this.UpdateDate = collect[0].QuerySelector("div.text-muted.pull-right").Text();
                Console.WriteLine(html.TextContent);
                Task.Delay(3000);
            }
        }
    }

    public interface ICv
    {
        void SearcheCv(string value);
    }
}


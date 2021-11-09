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
    internal class CvRabotaUa : Cv, ICv
    {
        public async Task SearcheCv(string value)
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
            }
        }
    }
}

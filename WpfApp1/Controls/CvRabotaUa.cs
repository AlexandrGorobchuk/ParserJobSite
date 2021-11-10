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
    internal class ListCvRabotaUa : IListCv
    {
        public List<Cv> cvRabotaUas = new List<Cv>();
        public async Task<List<Cv>> SearcheCv(string value)
        {
            string pathStart = $"https://rabota.ua/candidates/";
            string pathEnd = "/вся_украина?period=\"All\"&searchType=\"everywhere\"";
            IHtmlParser htmlParser = new HtmlParser();
            string path = $"{pathStart}{value}{pathEnd}";

            using (HttpClient httpClient = new HttpClient())
            {
                IDocument html = await htmlParser.ParseDocumentAsync(await httpClient.GetStringAsync(path));
                var collect = html.QuerySelectorAll("section.cv-card");
                if (collect.Count() == 0)
                    return new List<Cv>() { new CvRabotaUa() };

                foreach (var cvCard in collect)
                {
                    CvRabotaUa cvRabotaUa = new CvRabotaUa();
                    cvRabotaUa.Link = cvCard.QuerySelector("a.santa-no-underline").GetAttribute("href");
                    cvRabotaUa.Id = cvRabotaUa.Link.Split('/').Last();
                    cvRabotaUa.City = cvCard.QuerySelector("p.santa-typo-secondary").Text();
                    cvRabotaUa.Speciality = cvCard.QuerySelector("p.santa-m-0.santa-typo-h3.santa-pb-10").Text();
                    cvRabotaUa.UpdateDate = cvCard.QuerySelector("p.santa-typo-additional.santa-text-black-500.santa-mr-20").Text();
                    cvRabotaUas.Add(cvRabotaUa);
                }
            }
            return cvRabotaUas;
        }
    }

    internal class CvRabotaUa : Cv
    {
    }
}

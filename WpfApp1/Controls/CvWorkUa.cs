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

    internal class ListCvWorkUa: IListCv
    {
        public List<Cv> cvWorkUas = new List<Cv>();
        public async Task<List<Cv>> SearcheCv(string value)
        {
            IHtmlParser htmlParser = new HtmlParser();
            string path = $"https://www.work.ua/resumes-{value}?notitle=1&period=6";
            using (HttpClient httpClient = new HttpClient())
            {
                IDocument html = await htmlParser.ParseDocumentAsync(await httpClient.GetStringAsync(path));
                var collect = html.QuerySelectorAll("#pjax-resume-list div.resume-link");
                if (collect.Count() == 0)
                    return new List<Cv>() { new CvWorkUa() };
                foreach (IElement cvCard in collect)
                {
                    CvWorkUa cv = new CvWorkUa();
                    cv.Link = "https://www.work.ua" + cvCard.QuerySelector("h2 a").GetAttribute("href");
                    cv.Id = cvCard.QuerySelector("h2 a").GetAttribute("href").Split('/')[2];
                    cv.City = cvCard.QuerySelector("div span:nth-child(5)").Text();
                    cv.Speciality = cvCard.QuerySelector("h2 a").GetAttribute("Title");
                    cv.UpdateDate = cvCard.QuerySelector("div.text-muted.pull-right").Text();
                    cvWorkUas.Add(cv);
                }
            }
            return cvWorkUas;
        }
    }

    internal class CvWorkUa : Cv
    {

    }
}

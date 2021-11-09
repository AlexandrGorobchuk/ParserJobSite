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
    internal class CvWorkUa : Cv, ICv
    {
        public async Task SearcheCv(string value)
        {
            IHtmlParser htmlParser = new HtmlParser();
            string path = $"https://www.work.ua/resumes-{value}?notitle=1&period=6";
            using (HttpClient httpClient = new HttpClient())
            {
                IDocument html = await htmlParser.ParseDocumentAsync(await httpClient.GetStringAsync(path));
                var collect = html.QuerySelectorAll("#pjax-resume-list div:nth-child(2)");
                Link = "https://www.work.ua" + collect[0].QuerySelector("h2 a").GetAttribute("href");
                Id = collect[0].QuerySelector("h2 a").GetAttribute("href").Split('/')[2];
                City = collect[0].QuerySelector("div span:nth-child(5)").Text();
                Speciality = collect[0].QuerySelector("h2 a").GetAttribute("Title");
                UpdateDate = collect[0].QuerySelector("div.text-muted.pull-right").Text();
            }
        }
    }
}

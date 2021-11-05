using AngleSharp.Dom;
using AngleSharp.Html.Parser;
using System;
using System.Net.Http;
using System.Windows;

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            textBoxt();
        }
        private void textBoxt()
        {
            string x = "Горобчук Александр";
            string y = "Горобчук Виктор";
            textBoxName.Text = x + Environment.NewLine + y;
        }

        private async void ParseRabotaUa(string value)
        {
            IHtmlParser htmlParser = new HtmlParser();
            string path = $"https://rabota.ua/candidates/{value}/вся_украина?pg=3&period=" + "\"All\"&searchType=\"everywhere\"";
            using (HttpClient httpClient = new HttpClient())
            {
                IDocument html = await htmlParser.ParseDocumentAsync(await httpClient.GetStringAsync(path));
                var collect = html.QuerySelectorAll(@"section.cv-card");
                //var ee = collect[0].Text().Split('\n');

                Console.WriteLine(html.TextContent);
            };

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ParseRabotaUa("Аврора");
        }
    }
}

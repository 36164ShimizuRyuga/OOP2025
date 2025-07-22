using System.Net;
using System.Security.Policy;
using System.Windows.Forms;
using System.Xml.Linq;

namespace RssReader {
    public partial class Form1 : Form {

        private List<ItemData> items;

        public Form1() {
            InitializeComponent();
        }

        private async void btRssGet_Click(object sender, EventArgs e) {
            using (var hc = new HttpClient()) {
                string xml = await hc.GetStringAsync(tbUrl.Text);
                XDocument xdoc = XDocument.Parse(xml);



                //RSSを分析して必要な要素を取得
                items = xdoc.Root.Descendants("item")
                    .Select(x => new ItemData {
                        Title = (string?)x.Element("title"),
                        Link = (string?)x.Element("link")
                    }).ToList();


                //リストボックスへタイトルを表示
                lbTitles.Items.Clear();
                items.ForEach(item => lbTitles.Items.Add(item.Title));

            }


        }

        //タイトルを選択(クリック)したときに呼ばれるイベントハンドラ
        private void lbTitles_Click(object sender, EventArgs e) {
            int index = lbTitles.SelectedIndex;
            wvRssLink.Source = new Uri(items[index].Link);
        }

        private void btNext_Click_1(object sender, EventArgs e) {
                wvRssLink.GoForward();
            
        }

        private void btReturn_Click(object sender, EventArgs e) {
                wvRssLink.GoBack();
            
        }

        private void wvRssLink_SourceChanged(object sender, Microsoft.Web.WebView2.Core.CoreWebView2SourceChangedEventArgs e) {

        }
    }
}

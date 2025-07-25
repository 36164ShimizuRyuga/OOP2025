using System.ComponentModel;
using System.Net;
using System.Security.Policy;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Net.WebRequestMethods;

namespace RssReader {
    public partial class Form1 : Form {

        private List<ItemData> items;

        Dictionary<string, string> rssUrlDict = new Dictionary<string, string>() {
            {" "," " },
            {"バスケ","https://news.yahoo.co.jp/rss/media/bballk/all.xml" },
            {"主要","https://news.yahoo.co.jp/rss/topics/top-picks.xml" },
            {"経済","https://news.yahoo.co.jp/rss/topics/business.xml" },
            {"IT","https://news.yahoo.co.jp/rss/topics/it.xml" },
            {"国内","https://news.yahoo.co.jp/rss/topics/domestic.xml" },
            {"エンタメ","https://news.yahoo.co.jp/rss/topics/entertainment.xml" },

        };

        public Form1() {
            InitializeComponent();
        }


        private void Form1_Load(object sender, EventArgs e) {
            btReturn.Enabled = wvRssLink.CanGoBack;
            btNext.Enabled = wvRssLink.CanGoForward;
            cbUrl.DataSource = new BindingList<string>(rssUrlDict.Keys.ToList());

        }


        private async void btRssGet_Click(object sender, EventArgs e) {
            using (var hc = new HttpClient()) {
                string xml = await hc.GetStringAsync(getRssUrl(cbUrl.Text));
                XDocument xdoc = XDocument.Parse(xml);



                //RSSを分析して必要な要素を取得
                items = xdoc.Root.Descendants("item")
                    .Select(x => new ItemData {
                        Title = (string?)x.Element("title"),
                        Link = (string?)x.Element("link")
                    }).ToList();


                //リストボックスへタイトルを表示
                lbTitles.Items.Clear();
                items.ForEach(item => lbTitles.Items.Add(item.Title ?? "データなし"));

            }


        }

        //コンボボックスの文字列型をチェックしてアクセス可能なURLを返す
        private string getRssUrl(string str) {
            if (rssUrlDict.ContainsKey(str)) {
                return rssUrlDict[str];
            } else {
                return str;
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

        //マスクさせる
        private void wvRssLink_SourceChanged(object sender, Microsoft.Web.WebView2.Core.CoreWebView2SourceChangedEventArgs e) {
            btReturn.Enabled = wvRssLink.CanGoBack;
            btNext.Enabled = wvRssLink.CanGoForward;
        }

        //お気に入り登録URLをコンボボックスに登録する。        
        //登録するときの名前はtbFavoritNameに書いた名前とする
        private void btRegistration_Click(object sender, EventArgs e) {
            var rssName = tbFavoritName.Text;
            var rssUrl = cbUrl.Text;

            if (!rssUrlDict.ContainsKey(rssName)) {
                rssUrlDict.Add(rssName, rssUrl);

                var bindingList = new BindingList<string>(rssUrlDict.Keys.ToList());
                cbUrl.DataSource = bindingList;
                tbFavoritName.Clear();
            }
        }

        private void btDelete_Click(object sender, EventArgs e) {

        }
    }
}

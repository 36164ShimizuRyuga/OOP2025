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
            {"�o�X�P","https://news.yahoo.co.jp/rss/media/bballk/all.xml" },
            {"��v","https://news.yahoo.co.jp/rss/topics/top-picks.xml" },
            {"�o��","https://news.yahoo.co.jp/rss/topics/business.xml" },
            {"IT","https://news.yahoo.co.jp/rss/topics/it.xml" },
            {"����","https://news.yahoo.co.jp/rss/topics/domestic.xml" },
            {"�G���^��","https://news.yahoo.co.jp/rss/topics/entertainment.xml" },

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



                //RSS�𕪐͂��ĕK�v�ȗv�f���擾
                items = xdoc.Root.Descendants("item")
                    .Select(x => new ItemData {
                        Title = (string?)x.Element("title"),
                        Link = (string?)x.Element("link")
                    }).ToList();


                //���X�g�{�b�N�X�փ^�C�g����\��
                lbTitles.Items.Clear();
                items.ForEach(item => lbTitles.Items.Add(item.Title ?? "�f�[�^�Ȃ�"));

            }


        }

        //�R���{�{�b�N�X�̕�����^���`�F�b�N���ăA�N�Z�X�\��URL��Ԃ�
        private string getRssUrl(string str) {
            if (rssUrlDict.ContainsKey(str)) {
                return rssUrlDict[str];
            } else {
                return str;
            }
        }

        //�^�C�g����I��(�N���b�N)�����Ƃ��ɌĂ΂��C�x���g�n���h��
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

        //�}�X�N������
        private void wvRssLink_SourceChanged(object sender, Microsoft.Web.WebView2.Core.CoreWebView2SourceChangedEventArgs e) {
            btReturn.Enabled = wvRssLink.CanGoBack;
            btNext.Enabled = wvRssLink.CanGoForward;
        }

        //���C�ɓ���o�^URL���R���{�{�b�N�X�ɓo�^����B        
        //�o�^����Ƃ��̖��O��tbFavoritName�ɏ��������O�Ƃ���
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

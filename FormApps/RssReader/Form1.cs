using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace RssReader {
    public partial class Form1 : Form {
        List<ItemData> ItemDatas = new List<ItemData>();

        public Form1() {
            InitializeComponent();
            ItemDatas.Add(new ItemData() { Title = "主要", Link = "https://news.yahoo.co.jp/rss/topics/top-picks.xml" });
            ItemDatas.Add(new ItemData() { Title = "エンタメ", Link = "https://news.yahoo.co.jp/rss/topics/entertainment.xml" });
            ItemDatas.Add(new ItemData() { Title = "経済", Link = "https://news.yahoo.co.jp/rss/topics/business.xml" });
            ItemDatas.Add(new ItemData() { Title = "スポーツ", Link = "https://news.yahoo.co.jp/rss/topics/sports.xml" });
        }

        private void btGet_Click(object sender, EventArgs e) {
            if (tbUrl.Text == "")
                return;

            lbRssTitle.Items.Clear();

            using (var wc = new WebClient()) {
                var url = wc.OpenRead(tbUrl.Text);
                XDocument xdoc = XDocument.Load(url);

                ItemDatas = xdoc.Root.Descendants("item").Select(x => new ItemData {
                    Title = (string)x.Element("title"),
                    Link = (string)x.Element("link")
                }).ToList();
                
                foreach (var itemData in ItemDatas) {
                    lbRssTitle.Items.Add(itemData.Title);
                }
            }
        }

        private void lbRssTitle_Click(object sender, EventArgs e) {
            if (lbRssTitle.SelectedItem != null)
                wbBrowser.Navigate(ItemDatas[lbRssTitle.SelectedIndex].Link);
        }

        private ItemData.Topics getSelectedMaker() {
            foreach (var item in gbTopics.Controls) {
                if (((RadioButton)item).Checked) {
                    return (ItemData.Topics)int.Parse(((RadioButton)item).Tag.ToString());
                }
            }
            return ItemData.Topics.その他;
        }

        private void gbTopics_VisibleChanged(object sender, EventArgs e) {
            foreach (var itemData in ItemDatas) {
            //if(itemData.Title==getSelectedMaker())
                lbRssTitle.Items.Add(itemData.Title);
            }
        }
    }
}

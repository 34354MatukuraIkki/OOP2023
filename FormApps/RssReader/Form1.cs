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
    }
}

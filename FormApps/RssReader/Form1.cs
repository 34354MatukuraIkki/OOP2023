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
        List<ItemData> Favorites = new List<ItemData>();

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
            lbFavorite.SelectedItem = false;
        }

        private void btFavorite_Click(object sender, EventArgs e) {
            Favorites.Select(x => new ItemData {
                FavoriteTitle = ItemDatas[lbRssTitle.SelectedIndex].Title,
                FavoriteLink = ItemDatas[lbRssTitle.SelectedIndex].Link
            });
            lbFavorite.Items.Add(ItemDatas[lbRssTitle.SelectedIndex].Title);
        }

        private void lbFavorite_Click(object sender, EventArgs e) {
            if (lbFavorite.SelectedItem != null)
                wbBrowser.Navigate(Favorites[lbFavorite.SelectedIndex].FavoriteLink);
            lbRssTitle.SelectedItem = false;
        }
    }
}

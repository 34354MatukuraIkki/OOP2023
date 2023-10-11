using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RssReader {
    public class ItemData {
        public string Title { get; set; }
        public string Link { get; set; }

        public enum Topics {
            主要,
            エンタメ,
            経済,
            スポーツ,
            その他,
        }
    }
}

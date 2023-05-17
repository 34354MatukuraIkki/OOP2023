using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise01 {
    class Song {
        public string Titles { get; set; }//歌のタイトル
        public string ArtistName { get; set; }//アーティスト名
        public int Length { get; set; }//演奏時間、単位は秒

        public Song(string title, string artistname, int length) {
            Titles = title;
            ArtistName = artistname;
            Length = length;
        }
    }
}

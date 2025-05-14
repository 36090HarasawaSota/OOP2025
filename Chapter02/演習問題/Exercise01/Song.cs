using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise01 {

    //2.1.1
    public class song {
        public string Title { get; private set; } = String.Empty;

        public string ArtistName { get; private set; } = String.Empty;

        public int Length { get; set; }

        

        //2.1.2
        public song(String title, String artistName, int length) {
            Title = title;
            ArtistName = artistName;
            Length = length;

        }
    }
}
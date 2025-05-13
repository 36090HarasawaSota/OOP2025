﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise01 {

    //2.1.1
    public class Song {
        public string Title { get; set; } = String.Empty;

        public string ArtistName { get; set; } = String.Empty;

        public int Length { get; set; }

        

        //2.1.2
        public Song(String title, String artistName, int length) {
            Title = title;
            ArtistName = artistName;
            Length = length;

        }
    }
}
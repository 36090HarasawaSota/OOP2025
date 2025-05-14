namespace Exercise01 {
    internal class Program {

        static void Main(string[] args) {
            //2.1.3
            var songs = new song[] {
        new song("Let it be", "The Beatles", 243),
        new song("Close To You", "Carpenters", 276),
        new song("Honesty", "Billy Joel", 231),
        new song("I Will Always Love You", "Whitney Houston", 273),
        };
             }





    //2.1.4
       // public static void printSongs(Song[] songs) {
       //  foreach(var song in songs) {　　　      //songsの各要素をsongに格納しながら処理する
       //   var minutes = song.Length / 60;
       //    var seconds = song.Length % 60;
       //    Console.WriteLine($"{song.Title},{song.ArtistName} {Minutes}:{Seconds:00}");
       //   }
       //   Console.WriteLine();
       // }
            
            //TimeSpan構造体を使った場合
            foreach(var song in songs) {
                var timespan = TimeSpan.FromSeconds(song.Length);
                Console.WriteLine($"{song.Title},{song.ArtistName} {timespan.Minutes}:{timespan.Seconds:00}");
         
            }
    }
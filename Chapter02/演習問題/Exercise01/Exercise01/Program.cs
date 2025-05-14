namespace Exercise01 {
    public class Program {
        static void Main(string[] args) {
            //2.1.3
            //数データを入れるリストオブジェクト生成
            var songs = new List<Song>();


                //"*****曲の登録******"を出力
                Console.WriteLine("*****曲の登録*****");

                //何件入力があるかわからないので無限ループ
                while (true) {

                //"曲名を出力"
                Console.Write("曲名：");
                //入力された曲名を取得
                string? title = Console.ReadLine();

                //endが入力されたら終了 (StringComparison.OrdinalIgnoreCase = 大文字小文字どちらにも対応)
                if (title.Equals("end", StringComparison.OrdinalIgnoreCase)) break;


                //アーティスト名を出力
                Console.WriteLine("アーティスト名:");
                //入力されたアーティスト名を取得
                string ArtistName = Console.ReadLine();

                //"演奏時間(秒):"を出力
                Console.WriteLine("演奏時間(秒):");
                //入力された演奏時間を取得
                int Length = int.Parse(Console.ReadLine());

                //songインスタンスを生成
                //Song song = new Song(title,artistName,length)
                Song song = new Song() {
                    Title = title,
                    ArtistName = ArtistName,
                    Length = Length
                };

                //歌データを入れるリストオブジェクトへ移動
                songs.Add(song);

                Console.WriteLine(); //改行

            }
            printSongs(songs);
        }

        //2.1.4
        private static void printSongs(IEnumerable<Song> songs) {
            foreach (var song in songs) {
                var minutes = song.Length / 60;
                var seconds = song.Length % 60;

                Console.WriteLine($"{song.Title}, {song.ArtistName} {minutes}:{seconds:00}"); //:00 ＝ なにも
            }                                                                                 //打たれなかったら00をだす
            Console.WriteLine();
        }
    }
}

   


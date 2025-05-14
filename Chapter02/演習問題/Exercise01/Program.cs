namespace Exercise01 {
    public class Program {
        static void Main(string[] args) {
            //2.1.3
            Console.WriteLine("****曲名登録****");
            var songs = new List<Song>();

            //無限ループ
            while (true) {
                //曲名を入力
                Console.Write("曲名:");
                string title = Console.ReadLine();
                if (title == "end") {   //曲名がendのとき出力に移動
                    break;
                }
                //アーティスト名を入力
                Console.Write("アーティスト名:");
                string ArtistName = Console.ReadLine();

                //演奏時間入力
                Console.Write("演奏時間(秒):");
                int Length = int.Parse(Console.ReadLine());
                //改行
                Console.WriteLine();



            }



            printSongs(songs);
        }

        //2.1.4
        private static void printSongs(List<Song> songs) {
            Console.WriteLine("****登録曲一覧****");
#if fales

            foreach (Song song in songs) {
                int minutes = song.Length / 60;
                int seconds = song.Length % 60;
                Console.WriteLine($"Title: {song.Title}, Artist: {song.ArtistName}, Length: {minutes}:{seconds:00}");
            }
#else
            //TimeSpan構造体を使った場合
            foreach (var song in songs) {
                var timespan = TimeSpan.FromSeconds(song.Length);
                Console.WriteLine($"Title: {song.Title}, Artist: {song.ArtistName}, Length: {timespan.Minutes}:{timespan.Seconds:00}");

            }
            //または以下でも可
            // foreach (var song in songs) {
            //   Console.WriteLine(@"{0},{1} {2:m\:ss}",
            //     song.Title, song.ArtistName, TimeSpan.FromSeconds(song.Length));
            //  }

#endif
            Console.WriteLine();
        }

    }
}
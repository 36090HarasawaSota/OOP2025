namespace Test01 {
    public class ScoreCounter {
        private readonly IEnumerable<Student> _score;

        // コンストラクタ
        public ScoreCounter(string filePath) {
            GetPerStudentScore();

        }

        //メソッドの概要： 
        private static IEnumerable<Student> ReadScore(string filePath) {
            //売り上げデータを入れるリストオブジェクトを生成
            var sales = new List<Student>();
            //ファイルを一気に読み込み
            var lines = File.ReadAllLines(filePath);
            //読み込んだ行数分繰り返し
            foreach (var line in lines) {
                var items = line.Split(',');
                //Saleオブジェクトを生成
                var sale = new Student() {
                    Name = items[0],
                    Subject = items[1],
                    Score = items[2]
                };
                sales.Add(sale);
            }
                return sales;
        }
      
        

        //メソッドの概要： 
        public IDictionary<string, int> GetPerStudentScore() {
            var dict = new SortedDictionary<string, int>();
            foreach (var score in _score) {
                if (dict.ContainsKey(score.Subject)) {
                    dict[score.Subject] += score.Score;
                } else {
                    dict[score.Subject] = score.Score;
                }
            }
        return dict;
        }
    }
}

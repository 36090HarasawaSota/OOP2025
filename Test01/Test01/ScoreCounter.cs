namespace Test01 {
    public class ScoreCounter {
        private readonly IEnumerable<Student> _score;

        // コンストラクタ
        public ScoreCounter(string filePath) {
            //_sales = ReadScore(filePath);

        }

        //メソッドの概要： 
        //private static IEnumerable<Student> ReadScore(string filePath) {
         //   var sales = new List<Student>();
         //   var lines = File.ReadAllLines(filePath);
         //
         //   foreach (var line in lines) {
          //      var items = line.Split(',');
          //      var Score = new Student() {
          //          Name = items[0],
          //          Subject = items[1],
          //          Score = items[2]
           //     };
            //    sales.Add(Score);
           // }
           //     return sales;
        //}
      
        

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

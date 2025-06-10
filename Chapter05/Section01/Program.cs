using System.Collections.Immutable;

namespace Section01 {
    internal class Program {
        static void Main(string[] args) {
            var obj = new MySample();
           
           // var newList = obj.MyList.Add(6).RemoveAt(0); //0番目を削除
            //obj.MyList.ForEach(n => Console.WriteLine(n));　//繰り返し行う
            //Console.WriteLine();
           // newList.ForEach(n => Console.WriteLine(n));
            //Console.WriteLine();

            //obj.MyList[6]= 10直接中のものはいじれない


        }
    }
    public class MySample {
        public object MyList { get; internal set; }

        public class Person {
            public string GivenName { get; private set; }

            public string FamilyName { get; private set; }

            public Person(string familyName, string givenName) {
                FamilyName = familyName;
                GivenName = givenName;
            }

            //式形式で書く
            public void ChangeFamilyName(string name) => FamilyName = name;

            //public void ChangeFamilyName(string name) {           {}を省略されている
            //FamilyName = name;                             
            //}
        }
    }
}
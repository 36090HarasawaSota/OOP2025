using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace TextFileProcessorDI {
    public class TextFileProcessor {
        private ITextFileService _servics;

        //コンストラクタ
        public TextFileProcessor(ITextFileService servics) {
            _servics = servics;
        }

        public void Run(string fileName) {
            _servics.Initialize(fileName);

            var lines = File.ReadLines(fileName);
            foreach(var line in lines) {
                _servics.Execute(line);
            }
            _servics.Terminate();
        }

    }
}

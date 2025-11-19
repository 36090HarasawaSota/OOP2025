using System;

namespace TextFileProcessorDI {
    internal class LineOutputService : ITextFileService {
        private int _lineNumber = 0;

        public void Initialize(string fname) {
            _lineNumber = 0;
        }

        public void Execute(string line) {
            if (_lineNumber < 20) {
                Console.WriteLine(line);
                _lineNumber++;
            }
        }

        public void Terminate() {
            // 特に何もしない
        }
    }
}

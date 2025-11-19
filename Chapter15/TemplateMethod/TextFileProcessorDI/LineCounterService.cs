using System;

namespace TextFileProcessorDI {
    internal class LineCounterService : ITextFileService {
        private int _count;
        private ITextFileService _childService; // 注入用

        public LineCounterService(ITextFileService childService) {
            _childService = childService;
        }

        public void Initialize(string fname) {
            _count = 0;
            _childService.Initialize(fname);
        }

        public void Execute(string line) {
            _count++;
            _childService.Execute(line); // 注入されたサービスを呼ぶ
        }

        public void Terminate() {
            _childService.Terminate();
        }
    }
}

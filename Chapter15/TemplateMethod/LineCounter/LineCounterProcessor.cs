using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextFileProcessor;

namespace LineCounter {
    internal class LineCounterProcessor : TextProcessor {
        private int _count = 0;
        private string _target = "";

        protected override void Initialize(string fname) {
            _count = 0;
            _target = "public";
        }

        protected override void Execute(string line) {
            if (line.Contains(_target)) {
                _count++;
            }
        }

        protected override void Terminate() {
            Console.WriteLine("{0} : {1} 個", _target, _count);

        }

    }
}

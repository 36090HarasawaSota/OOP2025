using System;

namespace TextFileProcessorDI {
    internal class Program {
        static void Main(string[] args) {
            Console.WriteLine("パスの入力");
            var path = Console.ReadLine().Trim('"');

            // 半角変換サービス（出力はしないように修正）
            var lineToHalfNumberServics = new LineToHalfNumberServics();

            // 20行制限サービス
            var lineOutputService = new LineOutputService();

            // 半角変換した結果を20行制限サービスに渡す
            var combinedService = new TransformThenOutputService(lineToHalfNumberServics, lineOutputService);

            var processor = new TextFileProcessor(combinedService);
            processor.Run(path);
        }
    }

    // 「変換してから出力する」サービス
    internal class TransformThenOutputService : ITextFileService {
        private readonly LineToHalfNumberServics _transformer;
        private readonly LineOutputService _output;

        public TransformThenOutputService(LineToHalfNumberServics transformer, LineOutputService output) {
            _transformer = transformer;
            _output = output;
        }

        public void Initialize(string fname) {
            _transformer.Initialize(fname);
            _output.Initialize(fname);
        }

        public void Execute(string line) {
            // 半角変換した結果を出力サービスに渡す
            string result = new string(
                line.Select(c => ('０' <= c && c <= '９') ? (char)(c - '０' + '0') : c).ToArray()
            );
            _output.Execute(result);
        }

        public void Terminate() {
            _transformer.Terminate();
            _output.Terminate();
        }
    }
}
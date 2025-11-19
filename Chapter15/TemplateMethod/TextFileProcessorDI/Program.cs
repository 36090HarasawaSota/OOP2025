using System;

namespace TextFileProcessorDI {
    internal class Program {
        static void Main(string[] args) {
            Console.WriteLine("パスの入力");
            var path = Console.ReadLine().Trim('"');

            var lineToHalfNumberServics = new LineToHalfNumberServics();
            var counterService = new LineCounterService(lineToHalfNumberServics); 

            var processor = new TextFileProcessor(counterService);
            processor.Run(path);
        }
    }
}

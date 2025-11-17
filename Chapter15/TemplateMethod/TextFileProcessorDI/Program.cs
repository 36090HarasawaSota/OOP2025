namespace TextFileProcessorDI {
    internal class Program {
        static void Main(string[] args) {
            var servics = new LineCounterService();
            var processor = new TextFileProcessor(servics);
            Console.WriteLine("パスの入力");

            processor.Run(Console.ReadLine());
        }

    }
}

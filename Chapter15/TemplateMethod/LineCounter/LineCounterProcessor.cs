using TextFileProcessor;

internal class LineCounterProcessor : TextProcessor {
    private int _count = 0;
    private string _target = "";

    public static string TargetKeyword { get; set; } 

    protected override void Initialize(string fname) {
        _count = 0;
        _target = TargetKeyword;
    }

    protected override void Execute(string line) {
        int index = 0;
        while ((index = line.IndexOf(_target, index, StringComparison.OrdinalIgnoreCase)) >= 0) {
            _count++;
            index += _target.Length;
        }
    }


    protected override void Terminate() {
        Console.WriteLine("{0} : {1} 個", _target, _count);
    }
}

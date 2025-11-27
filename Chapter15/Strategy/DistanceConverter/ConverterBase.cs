namespace DistanceConverter {
    public abstract class ConverterBase {
        // nameで与えられた単位が自分のものか判断（入力を正規化して比較）
        public abstract bool IsMyUnit(string name);

        // メートルとの比較(この比率をかけるとメートルに変換できる)
        protected abstract double Ratio { get; }

        // 距離の単位名(たとえば、"メートル","フィート"など)
        public abstract string UnitName { get; }

        // メートルからの変換
        public double FromMeter(double meter) => meter / Ratio;

        // メートルへの変換
        public double ToMeter(double value) => value * Ratio;

        // 英語入力用の名前（標準化した表示用）
        public virtual string GetEnglishName() => GetType().Name.Replace("Converter", "").ToLower();
    }
}
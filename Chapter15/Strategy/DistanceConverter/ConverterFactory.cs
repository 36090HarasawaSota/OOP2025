using System.Linq;

namespace DistanceConverter {
    public static class ConverterFactory {
        // あらかじめインスタンスを生成し、配列に入れておく
        private readonly static ConverterBase[] _converters = {
            new MeterConverter(),
            new FeetConverter(),
            new YardConverter(),
            new InchConverter(),
            new MileConverter(),
            new KilometerConverter(),
        };

        public static ConverterBase? GetInstance(string name) =>
            _converters.FirstOrDefault(x => x.IsMyUnit(name));

        // 全部返す
        public static ConverterBase[] GetAllConverters() => _converters;
    }
}
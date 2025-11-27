namespace DistanceConverter {
    public class MeterConverter : ConverterBase {
        public override bool IsMyUnit(string name) {
            var n = Normalize(name);
            return n == "meter" || n == "メートル" || n == "m";
        }
        protected override double Ratio => 1;
        public override string UnitName => "メートル";
        private static string Normalize(string s) => s?.Trim().ToLower() ?? "";
    }

    public class FeetConverter : ConverterBase {
        public override bool IsMyUnit(string name) {
            var n = Normalize(name);
            return n == "feet" || n == "foot" || n == "フィート" || n == "ft";
        }
        protected override double Ratio => 0.3048;
        public override string UnitName => "フィート";
        private static string Normalize(string s) => s?.Trim().ToLower() ?? "";
    }

    public class InchConverter : ConverterBase {
        public override bool IsMyUnit(string name) {
            var n = Normalize(name);
            return n == "inch" || n == "インチ" || n == "in";
        }
        protected override double Ratio => 0.0254;
        public override string UnitName => "インチ";
        private static string Normalize(string s) => s?.Trim().ToLower() ?? "";
    }

    public class YardConverter : ConverterBase {
        public override bool IsMyUnit(string name) {
            var n = Normalize(name);
            return n == "yard" || n == "ヤード" || n == "yd";
        }
        protected override double Ratio => 0.9144;
        public override string UnitName => "ヤード";
        private static string Normalize(string s) => s?.Trim().ToLower() ?? "";
    }

    public class MileConverter : ConverterBase {
        public override bool IsMyUnit(string name) {
            var n = Normalize(name);
            return n == "mile" || n == "マイル" || n == "mi";
        }
        protected override double Ratio => 1609.344;
        public override string UnitName => "マイル";
        private static string Normalize(string s) => s?.Trim().ToLower() ?? "";
    }

    public class KilometerConverter : ConverterBase {
        public override bool IsMyUnit(string name) {
            var n = Normalize(name);
            return n == "kilometer" || n == "kilometre" || n == "キロメートル" || n == "km";
        }
        protected override double Ratio => 1000;
        public override string UnitName => "キロメートル";
        private static string Normalize(string s) => s?.Trim().ToLower() ?? "";
    }
}
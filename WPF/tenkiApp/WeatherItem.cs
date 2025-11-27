using System;

namespace tenkiApp {
    public class WeatherItem {
        public string Time { get; set; }      // 時刻
        public string Weather { get; set; }   // 天気
        public string Temp { get; set; }      // 気温
        public string Wind { get; set; }      // 風速
        public string Pop { get; set; }       // 降水確率
        public string Rain { get; set; }      // 降水量
    }
}

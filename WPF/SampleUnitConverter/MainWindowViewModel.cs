using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SampleUnitConverter{
    internal class MainWindowViewModel : ViewModel {

        //フィールド
        private double metricValue;
        private double imperialValue; 

        //▲で呼ばれるコマンド
            public ICommand ImperalUnitToMetric { get; private set; }
        //▼で呼ばれるコマンド
            public ICommand MetricToImperialunit { get; private set; }

        //上のコンボボックスで選択されている値を入れる箱
        public MetricUnit CurrentMetricUnit { get; set; }
        //下のコンボボックスで選択されている値を入れる箱
        public ImperialUnit CurrentImperialUnit { get; set; }

        //プロパティ
        public double MetricValue {
            get => metricValue;
            set {
                this.metricValue = value;
                this.OnPropertyChanged();
            }
        }

        public double ImperialValue {
            get => imperialValue;
            set {
                this.imperialValue = value;
                this.OnPropertyChanged();

            }
        }

        public MainWindowViewModel() {

            CurrentMetricUnit = MetricUnit.Units.First();
            CurrentImperialUnit = ImperialUnit.Units.First();

            ImperalUnitToMetric = new DelegateCommand(
                () => MetricValue = CurrentMetricUnit.FromImperialUnit(CurrentMetricUnit, ImperialValue));

            MetricToImperialunit = new DelegateCommand(
                () => ImperialValue = CurrentImperialUnit.FromMetricUnit(CurrentImperialUnit, MetricValue));


        }


    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SampleUnitConverter {
    public class MainWindowViewModel : ViewModel {
        private double metricValue, imperialValue, gramValue, weightValue;

        public double MetricValue {
            get { return this.metricValue; }
            set {
                this.metricValue = value;
                this.OnPropertyChanged();
            }
        }

        public double ImperialValue {
            get { return this.imperialValue; }
            set {
                this.imperialValue = value;
                this.OnPropertyChanged();
            }
        }

        public double GramValue {
            get { return this.gramValue; }
            set {
                this.gramValue = value;
                this.OnPropertyChanged();
            }
        }

        public double WeightValue {
            get { return this.weightValue; }
            set {
                this.weightValue = value;
                this.OnPropertyChanged();
            }
        }
        //上のComboBoxで選択されている値（単位）
        //public MetricUnit CurrentMetricUnit { get; set; }
        public GramUnit CurrentGramUnit { get; set; }

        //下のComboBoxで選択されている値（単位）
        //public ImperialUnit CurrentImperialUnit { get; set; }
        public WeightUnit CurrentWeightUnit { get; set; }

        //▲ボタンで呼ばれるコマンド
        //public ICommand ImperialUnitToMetric { get; private set; }
        public ICommand WeightUnitToGram { get; private set; }

        //▼ボタンで呼ばれるコマンド
        //public ICommand MetricToImperialUnit { get; private set; }
        public ICommand GramToWeightUnit { get; private set; }

        //コンストラクタ
        public MainWindowViewModel() {
            //this.CurrentMetricUnit = MetricUnit.Units.First();
            //this.CurrentImperialUnit = ImperialUnit.Units.First();
            this.CurrentGramUnit = GramUnit.Units.First();
            this.CurrentWeightUnit = WeightUnit.Units.First();

            //this.MetricToImperialUnit = new DelegateCommand(
            //    () => this.ImperialValue = this.CurrentImperialUnit.FromMetricUnit(
            //        this.CurrentMetricUnit, this.metricValue));

            //this.ImperialUnitToMetric = new DelegateCommand(
            //    () => this.MetricValue = this.CurrentMetricUnit.FromImperialUnit(
            //        this.CurrentImperialUnit, this.imperialValue));

            this.GramToWeightUnit = new DelegateCommand(
                () => this.WeightValue = this.CurrentWeightUnit.FromGramUnit(
                    this.CurrentGramUnit, this.gramValue));

            this.WeightUnitToGram = new DelegateCommand(
                () => this.GramValue = this.CurrentGramUnit.FromWeightUnit(
                    this.CurrentWeightUnit, this.weightValue));
        }
    }
}
using Prism.Commands;
using Prism.Mvvm;
using System.Linq;
using System.Windows.Input;

namespace SampleUnitConverter {
    class MainWindowViewModel : BindableBase {
        private double metricValue;
        private double imperialValue;

        private MetricUnit currentMetricUnit;
        private ImperialUnit currentImperialUnit;

        // PrismのDelegateCommandを使ったコマンド
        public ICommand ImperialUnitToMetric { get; }
        public ICommand MetricToImperialUnit { get; }

        public MetricUnit CurrentMetricUnit {
            get => currentMetricUnit;
            set => SetProperty(ref currentMetricUnit, value);
        }

        public ImperialUnit CurrentImperialUnit {
            get => currentImperialUnit;
            set => SetProperty(ref currentImperialUnit, value);
        }

        public double MetricValue {
            get => metricValue;
            set => SetProperty(ref metricValue, value);
        }

        public double ImperialValue {
            get => imperialValue;
            set => SetProperty(ref imperialValue, value);
        }

        public MainWindowViewModel() {
            CurrentMetricUnit = MetricUnit.Units.First();
            CurrentImperialUnit = ImperialUnit.Units.First();

            ImperialUnitToMetric = new DelegateCommand(
                () => MetricValue =
                    CurrentMetricUnit.FromImperialUnit(CurrentImperialUnit, ImperialValue));

            MetricToImperialUnit = new DelegateCommand(
                () => ImperialValue =
                    CurrentImperialUnit.FromMetricUnit(CurrentMetricUnit, MetricValue));
        }
    }
}

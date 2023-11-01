using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CollarChecker {
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window {
        
        List<MyColor> stockColors = new List<MyColor>();

        public MainWindow() {
            InitializeComponent();
            SetColor();

            DataContext = GetColorList();
        }

        private MyColor[] GetColorList() {
            return typeof(Colors).GetProperties(BindingFlags.Public | BindingFlags.Static)
                            .Select(i => new MyColor() { Color = (Color)i.GetValue(null), Name = i.Name }).ToArray();
        }

        private void changeColor(object sender, RoutedPropertyChangedEventArgs<double> e) {
            SetColor();
        }

        public void SetColor() {
            Color color = Color.FromRgb((byte)rSlider.Value, (byte)gSlider.Value, (byte)bSlider.Value);
            SolidColorBrush solidColor = new SolidColorBrush(color);
            colorArea.Background = solidColor;
        }

        private void stockButton_Click(object sender, RoutedEventArgs e) {
            stockColors.Add(new MyColor() { Color = Color.FromRgb((byte)rSlider.Value, (byte)gSlider.Value, (byte)bSlider.Value), Name = $"R = {rValue.Text},G = {gValue.Text},B = {bValue.Text}" });

            foreach (var color in stockColors) {
                if (!stockList.Items.Contains(color.Name))
                    stockList.Items.Add(color.Name);
            }
        }

        private void stockList_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            var selectColor = (MyColor)sender;
            var color = selectColor.Color;
            rSlider.Value = color.R;
            gSlider.Value = color.G;
            bSlider.Value = color.B;
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            var mycolor = (MyColor)((ComboBox)sender).SelectedItem;
            var color = mycolor.Color;
            rSlider.Value = color.R;
            gSlider.Value = color.G;
            bSlider.Value = color.B;
        }
    }

    public class MyColor {
        public Color Color { get; set; }
        public string Name { get; set; }
    }
}

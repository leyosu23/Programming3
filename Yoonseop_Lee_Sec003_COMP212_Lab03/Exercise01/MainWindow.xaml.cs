using System;
using System.Collections.Generic;
using System.Linq;
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

namespace Exercise01
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ButtonCalculate_Click(object sender, RoutedEventArgs e)
        {
            double result = 0;
            if (CheckBoxFlossing.IsChecked?? true)
            {
                result += 20;
            }
            if (CheckBoxFilling.IsChecked ?? true)
            {
                result += 75;
            }
            if (CheckBoxRootCanal.IsChecked ?? true)
            {
                result += 150;
            }

            if (ComboBoxAddress.SelectionBoxItem.ToString() == "Ontario")
            {
                result = result * 1.13;
            }
            else if (ComboBoxAddress.SelectionBoxItem.ToString() == "Alberta")
            {
                result = result * 1.07;
            }
            else if (ComboBoxAddress.SelectionBoxItem.ToString() == "Quebec")
            {
                result = result * 1.06;
            }

            if (RadioButtonSenior.IsChecked ?? true)
            {
                result = result * 0.9;
            }
            else if (RadioButtonKids.IsChecked ?? true)
            {
                result = result * 0.85;
            }

            LabelOutput.Content = $"Patient {TextBoxName.Text} costs ${result}";

        }
    }
}

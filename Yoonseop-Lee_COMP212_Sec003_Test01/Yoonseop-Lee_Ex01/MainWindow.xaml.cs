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

namespace Yoonseop_Lee_Ex01
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

        private void ButtonSubmit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                decimal price = 0;

                if (RadioButtonSmall.IsChecked ?? true)
                {
                    price += 10;
                }
                else if (RadioButtonMedium.IsChecked ?? true)
                {
                    price += 12;
                }
                else if (RadioButtonLarge.IsChecked ?? true)
                {
                    price += 14;
                }


                if (CheckBoxOnion.IsChecked ?? true)
                {
                    price += 2;
                }
                if (CheckBoxPepper.IsChecked ?? true)
                {
                    price += 2;
                }
                if (CheckBoxTamato.IsChecked ?? true)
                {
                    price += 2;
                }
                if (CheckBoxMushroom.IsChecked ?? true)
                {
                    price += 2;
                }

                TextBoxSubTotal.Text = price.ToString();
                price *= 1.13M;

                TextBoxTotal.Text = price.ToString();

                TextboxDetail.Text = $" Order Id: {TextBoxOrderID.Text} Customer: {TextBoxCustName.Text} Price: ${price:f2}";
            }
            catch (Exception)
            {
                TextboxDetail.Text = "ERROR: fill out the content properly";
            }
        }
    }
}

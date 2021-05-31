using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Numerics;
using System.Collections.Generic;
using System.Linq;

namespace Yoonseop_Lee_Sec003_Exercise01
{
    public partial class AsynchronousProgramming : Form
    {
        public AsynchronousProgramming()
        {
            InitializeComponent();
        }

        private async void CalculateFactorialButton_Click(object sender, EventArgs e)
        {
            try
            {
                int number = int.Parse(FactorialTextBox.Text);

                asyncResultLabel.Text = "Calculating...";

                Task<BigInteger> factorialTask = Task.Run(() => Factorial(number));

                await factorialTask;

                asyncResultLabel.Text = factorialTask.Result.ToString();
            }
            catch (Exception ex)
            {
                errorTextBox.Text = ex.Message;
            }
        }

        public BigInteger Factorial(BigInteger n)
        {
            // resursive factorial 
            try
            {
                if (n == 1 || n == 0)
                    return 1;
                else

                    return n * Factorial(n - 1);
            }
            catch (Exception ex)
            {

                errorTextBox.Text = ex.Message;
            }
            return -1;
        }

        // delegate
        public delegate bool NumberPredicate(int number);

        public bool IsOdd(int n)
        {
            // lambda
            NumberPredicate evenPredicate = number => number % 2 == 0;
            if (evenPredicate(n))
            {
                return false;
            }
            else
            {
                return true;
            }

        }

        private async void checkNumButton_Click(object sender, EventArgs e)
        {
            try
            {
                int number = int.Parse(checkingNumberTextBox.Text);

                Task<bool> isOddTask = Task.Run(() => IsOdd(number));

                await isOddTask;

                if (await isOddTask)
                {
                    isOddEvenLabel.Text = $"{number} is odd number";

                }
                else
                {
                    isOddEvenLabel.Text = $"{number} is even number";
                }
            }
            catch (Exception ex)
            {
                errorTextBox.Text = ex.Message;
            }

        }

        private void generateNumbersButton_Click(object sender, EventArgs e)
        {
            try
            {
                Random rand = new Random();

                if (intRadioButton.Checked == true)
                {
                    randomValueListBox.Items.Clear();
                    for (int i = 0; i < 10; i++)
                    {
                        int randNum = rand.Next(10, 100);
                        randomValueListBox.Items.Add(randNum.ToString());
                    }
                }
                else if (doubleRadioButton.Checked == true)
                {
                    randomValueListBox.Items.Clear();
                    for (int i = 0; i < 10; i++)
                    {
                        double randNum = rand.Next(10, 100);
                        randomValueListBox.Items.Add(randNum.ToString());
                    }
                }

                else
                {
                    randomValueListBox.Items.Clear();
                    for (int i = 0; i < 10; i++)
                    {
                        int randNum = rand.Next(26);

                        randomValueListBox.Items.Add((char)(randNum + 65));
                    }
                }
            }
            catch (Exception ex)
            {

                errorTextBox.Text = ex.Message;
            }
        }

        private void numberSearchButton_Click(object sender, EventArgs e)
        {
            try
            {
                bool existence;
                if (charRadioButton.Checked)
                {
                    var genericListchar = randomValueListBox.Items.Cast<char>().ToList();
                    existence = SearchDateChar(genericListchar);
                    MessageBox.Show(existence ? "Character exists" : "Character does not exists", "Is the Character in the list?");
                }
                else
                {
                    var genericList = randomValueListBox.Items.Cast<string>().ToList();
                    existence = SearchDate(genericList);
                    MessageBox.Show(existence ? "Number exists" : "Number does not exists", "Is the number in the list?");
                }

            }
            catch (Exception ex)
            {

                errorTextBox.Text = ex.Message;
            }

        }
        private void numberDisplayButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (charRadioButton.Checked)
                {
                    var genericList = randomValueListBox.Items.Cast<char>().ToList();
                    displayCharFilteredNumber(genericList);
                }
                else
                {
                    var genericList = randomValueListBox.Items.Cast<string>().ToList();
                    displayFilteredNumber(genericList);
                }
            }
            catch (Exception ex)
            {
                errorTextBox.Text = ex.Message;
            }
        }

        public bool SearchDate(List<string> list)
        {
            for (int i = 0; i < 10; i++)
            {
                if (list[i] == searchInputTextBox.Text)
                {
                    return true;
                }

            }
            return false;
        }

        public bool SearchDateChar(List<char> list)
        {
            for (int i = 0; i < 10; i++)
            {
                if (list[i] == searchInputTextBox.Text.ToString().First())
                {
                    return true;
                }

            }
            return false;
        }

        public void displayFilteredNumber(List<string> list)
        {
            try
            {
                string[] strArr = new string[10];
                for (int i = 0; i < list.Count; i++)
                {
                    if (int.Parse(list.ElementAt(i)) >= int.Parse(lowIndexTextBox.Text) && int.Parse(list.ElementAt(i)) <= int.Parse(highIndexTextBox.Text))
                    {
                        strArr[i] = list.ElementAt(i);
                    }
                }
                OutputTextBox.Text = null;
                foreach (var item in strArr)
                {
                    OutputTextBox.Text += $"{item} ";
                }

            }
            catch (Exception ex)
            {
                errorTextBox.Text = ex.Message;
            }
        }

        public void displayCharFilteredNumber(List<char> list)
        {
            try
            {
                if (charRadioButton.Checked)
                {
                    char[] strArr = new char[10];
                    for (int i = 0; i < list.Count; i++)
                    {
                        if (list.ElementAt(i) >= lowIndexTextBox.Text.First() && list.ElementAt(i) <= highIndexTextBox.Text.First())
                        {
                            strArr[i] = list.ElementAt(i);
                        }
                    }
                    OutputTextBox.Text = null;
                    foreach (var item in strArr)
                    {
                        OutputTextBox.Text += $"{item} ";
                    }
                }


            }
            catch (Exception ex)
            {
                errorTextBox.Text = ex.Message;
            }
        }

    }
}

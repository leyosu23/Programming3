using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Numerics;
namespace Exercise03
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        TimeData StartFibonacci(int n)
        {
            try
            {

            
            // create a TimeData object to store start/end times
            var result = new TimeData();

            AppendText($"Calculating Fibonacci({n})");
            result.StartTime = DateTime.Now;
            BigInteger fibonacciValue = Fibonacci(n);
            result.EndTime = DateTime.Now;

            AppendText($"Fibonacci({n}) = {fibonacciValue}");
            double minutes =
               (result.EndTime - result.StartTime).TotalMinutes;
            AppendText($"Calculation Fibonacci {n} times = {minutes:F6} minutes\r\n");

            return result;

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

        }


        TimeData StartFactorial(int n)
        {
            try
            {

            
            // create a TimeData object to store start/end times
            var result = new TimeData();

            AppendText($"Calculating Factorial({n})");
            result.StartTime = DateTime.Now;
            BigInteger factorialiValue = Factorial(n);
            result.EndTime = DateTime.Now;

            AppendText($"Factorial({n}) = {factorialiValue}");
            double minutes =
               (result.EndTime - result.StartTime).TotalMinutes;
            AppendText($"Calculation factorial {n} times = {minutes:F6} minutes\r\n");

            return result;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

        }

      
        TimeData StartRollDie(int n)
        {
            try
            {

            
            // create a TimeData object to store start/end times
            var result = new TimeData();

            AppendText($"Calculating RollDie({n})");
            result.StartTime = DateTime.Now;
            RollDie(n);
            result.EndTime = DateTime.Now;

            double minutes =
               (result.EndTime - result.StartTime).TotalMinutes;
            AppendText($"Calculation RollDie {n} times = {minutes:F6} minutes\r\n");

            return result;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

        }

        public BigInteger Factorial(BigInteger n)
        {
            try
            {
                if (n == 1 || n == 0)
                    return 1;
                else

                    return n * Factorial(n - 1);
            }
            catch (Exception)
            {
                // add excption handler
            }
            return -1;
        }

         public BigInteger Fibonacci(BigInteger n)
          {

            int a = 0;
            int b = 1;
            for (int i = 0; i < n; i++)
            {
                int temp = a;
                a = b;
                b = temp + b;
            }
            return a;
            //if (n == 0 || n == 1)
            //{
            //   return n;
            //}
            //else
            //{
            //   return Fibonacci(n - 1) + Fibonacci(n - 2);
            //}
        }

        int[] freqDie = new int[6];
        public void RollDie(int n)
        {
            try
            {

            
            Random rand = new Random();
            for (int i = 0; i < n; i++)
            {
                freqDie[rand.Next(6)]++;
            }
            int max = freqDie[0];
            int indexOfMax = 0;
            for (int i = 1; i < 6; i++)
            {
                if (max < freqDie[i])
                {
                    max = freqDie[i];
                    indexOfMax = i;
                }
            }


            outputTextBox.AppendText($"The number \"{indexOfMax + 1}\" is highest of all and  appeared {max} times\r\n");

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }


        // append text to outputTextBox in UI thread
        public void AppendText(String text)
        {
            if (InvokeRequired) // not GUI thread, so add to GUI thread
            {
                Invoke(new MethodInvoker(() => AppendText(text)));
            }
            else // GUI thread so append text
            {
                outputTextBox.AppendText(text + "\r\n");
            }
        }
        private async void startButton_Click(object sender, EventArgs e)
        {
            try
            {

            
            outputTextBox.Text = "Starting Task to calculate Factorial(46)\r\n";

            // create Task to perform Fibonacci(46) calculation in a thread
            Task<TimeData> task1 = Task.Run(() => StartFactorial(46));

            outputTextBox.AppendText(
               "Starting Task to calculate Fibonacci(45)\r\n");

            // create Task to perform Fibonacci(45) calculation in a thread
            Task<TimeData> task2 = Task.Run(() => StartFibonacci(45));

            outputTextBox.AppendText(
               "Starting Task to calculate StartRollDie(6000000)\r\n");

            // create Task to perform StartRollDie(6000000) calculation in a thread
            Task<TimeData> task3 = Task.Run(() => StartRollDie(60000000));

            await Task.WhenAll(task1, task2, task3); // wait for both to complete

            // determine time that first thread started
            DateTime startTime=
            (task1.Result.StartTime < task2.Result.StartTime) ?
           task1.Result.StartTime : task2.Result.StartTime;
            //if (task1.Result.EndTime <= task2.Result.EndTime && task1.Result.EndTime <= task3.Result.EndTime)
            //    startTime = task1.Result.EndTime;
            //else if (task2.Result.EndTime <= task1.Result.EndTime && task2.Result.EndTime <= task3.Result.EndTime)
            //    startTime = task2.Result.EndTime;
            //else
            //    startTime = task3.Result.EndTime;

            // determine time that last thread ended
            DateTime endTime=
            (task2.Result.EndTime > task3.Result.EndTime) ?
           task2.Result.EndTime : task3.Result.EndTime;
            //if (task1.Result.EndTime >= task2.Result.EndTime && task1.Result.EndTime >= task3.Result.EndTime)
            //   endTime = task1.Result.EndTime;
            //else if(task2.Result.EndTime >= task1.Result.EndTime && task2.Result.EndTime >= task3.Result.EndTime)
            //    endTime = task2.Result.EndTime;
            //else
            //   endTime = task3.Result.EndTime;

            // display total time for calculations
            double totalMinutes = (endTime - startTime).TotalMinutes;
            outputTextBox.AppendText(
               $"Total calculation time = {totalMinutes:F6} minutes\r\n\r\n");

            foreach (var item in freqDie)
            {
                outputTextBox.AppendText($"{item} ");
            }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

        }


    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Exercise02
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        private BaseballExample.BaseballEntities dbcontext =
         new BaseballExample.BaseballEntities();

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {

           
            // load Authors table ordered by LastName then FirstName
            dbcontext.Players
               .OrderBy(author => author.FirstName)
               .ThenBy(author => author.LastName)
               .Load();

            // specify DataSource for authorBindingSource
            playersBindingSource.DataSource = dbcontext.Players.Local;

            var BattingAverage =
             from player in dbcontext.Players
             select new { player.BattingAverage };

            decimal highest = 0;
            decimal temp = 0;
            foreach (var item in BattingAverage)
            {
               temp+= item.BattingAverage;
            }

            foreach (var item in BattingAverage)
            {
                if (highest < item.BattingAverage)
                {
                    highest = item.BattingAverage;
                }
            }

                var highestPlayer =
                 from player in dbcontext.Players
                 where player.BattingAverage == highest
                 select player.FirstName + player.LastName;

                playerHighestBettingTextBox.Text = $"{highestPlayer.SingleOrDefault()} ({highest})";
            BattingAverageTextBox.Text = $"{temp / BattingAverage.Count() }";


            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            try
            {

           
            // load Authors table ordered by LastName then FirstName
            playersBindingSource.DataSource =
                  dbcontext.Players.Local
                     .Where(
                        book => book.PlayerID.ToString().EndsWith($"{playerIDTextBox.Text}"));
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

        }

        private void resetButton_Click(object sender, EventArgs e)
        {
            try
            {

          
            playersBindingSource.DataSource = dbcontext.Players.Local;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

        }

        private void LastNamesearchButton_Click(object sender, EventArgs e)
        {
            try
            {
                // load Authors table ordered by LastName then FirstName
                playersBindingSource.DataSource =
                      dbcontext.Players.Local
                         .Where(
                            book => book.LastName.EndsWith($"{lastNameTextBox.Text}"));
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

        }
    }
}

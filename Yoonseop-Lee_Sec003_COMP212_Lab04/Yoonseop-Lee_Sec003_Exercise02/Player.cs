using System;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Windows.Forms;

namespace Yoonseop_Lee_Sec003_Exercise02
{
    public partial class Player : Form
    {
        public Player()
        {
            InitializeComponent();
        }

        private BaseballExamples.BaseballEntities dbcontext =
         new BaseballExamples.BaseballEntities();

        private void Player_Load(object sender, EventArgs e)
        {
            // load Authors table ordered by LastName then FirstName
            dbcontext.Players
               .OrderBy(author => author.FirstName)
               .ThenBy(author => author.LastName)
               .Load();

            // specify DataSource for authorBindingSource
            playerBindingSource.DataSource = dbcontext.Players.Local;
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            // load Authors table ordered by LastName then FirstName
            playerBindingSource.DataSource =
                  dbcontext.Players.Local
                     .Where(
                        book => book.LastName.EndsWith($"{lastNameTextBox.Text}"));
        }

        private void resetButton_Click(object sender, EventArgs e)
        {
            playerBindingSource.DataSource = dbcontext.Players.Local;
        }
    }
}

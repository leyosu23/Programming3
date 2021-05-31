using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Exercise01
{
    public partial class book : Form
    {
        public book()
        {
            InitializeComponent();
        }

        private void queriesComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

            // Entity Framework DbContext
            var dbcontext = new BooksExample.BooksEntities();


            // set the data displayed according to what is selected
            switch (queriesComboBox.SelectedIndex)
            {

                case 0:


                    outputTextBox.Clear();



                    var titlesbyauthor =
                       //select title
                       from title in dbcontext.Titles
                           // orderby title
                       orderby title.Title1
                       select new
                       {
                           // select title name
                           bookTitle = title.Title1,
                           // select  author by title name
                           authors =
                             from author in title.Authors
                             orderby author.FirstName, author.LastName
                             select author.FirstName + " " + author.LastName
                       };

                    outputTextBox.AppendText("\r\n\r\nauthors grouped by title:");

                    // display titles written by each author, grouped by author
                    foreach (var title in titlesbyauthor)
                    {
                        // display author's name
                        outputTextBox.AppendText($"\r\n\t{title.bookTitle}:");

                        // display titles written by that author
                        int temp = 0;
                        foreach (var author in title.authors)
                        {
                            //outputTextBox.AppendText($"\r\n\t\t{author}");
                            temp++;
                        }

                        outputTextBox.AppendText($"\r\n\t\t{temp++}");
                    }
                    break;


                case 1:

                    outputTextBox.Clear();


                    var titlesByAuthor =
                       from author in dbcontext.Authors
                       orderby author.LastName, author.FirstName
                       select new
                       {
                           Name = author.FirstName + " " + author.LastName,
                           Titles =
                             from book in author.Titles
                             orderby book.Title1
                             select book.Title1
                       };

                    outputTextBox.AppendText("\r\n\r\nTitles grouped by author:");

                    // display titles written by each author, grouped by author
                    foreach (var author in titlesByAuthor)
                    {
                        // display author's name
                        outputTextBox.AppendText($"\r\n\t{author.Name}:");

                        // display titles written by that author
                        foreach (var title in author.Titles)
                        {
                            outputTextBox.AppendText($"\r\n\t\t{title}");
                        }
                    }

                    break;
            }

            }
            catch (Exception ex)
            {

               MessageBox.Show(ex.Message);
            }
        }
    }
}

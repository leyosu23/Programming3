using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Yoonseop_Lee_Sec003_Exercise01
{
    public partial class Book : Form
    {
        public Book()
        {
            InitializeComponent();
        }

        private void Book_Load(object sender, EventArgs e)
        {

        }

        private void queriesComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Entity Framework DbContext
            var dbcontext = new BooksExamples.BooksEntities();


            // set the data displayed according to what is selected
            switch (queriesComboBox.SelectedIndex)
            {

                case 0:


                    outputTextBox.Clear();

                    var authorsAndISBNs =
                       from author in dbcontext.Authors
                       from book in author.Titles
                       orderby book.Title1
                       select new { author.FirstName, author.LastName, book.Title1 };

                    outputTextBox.AppendText("Authors and Titles (Sort by title):");

                    foreach (var element in authorsAndISBNs)
                    {
                        outputTextBox.AppendText($"\r\n\t{element.FirstName,-10} " +
                           $"{element.LastName,-10} {element.Title1,-10}");
                    }
                    break;
                case 1:

                    outputTextBox.Clear();

                    var authorsAndISBNs2 =
                        from author in dbcontext.Authors
                        from book in author.Titles
                        orderby book.Title1, author.LastName, author.FirstName
                        select new { author.FirstName, author.LastName, book.Title1 };

                    outputTextBox.AppendText("Authors and Titles (Sort by title and authors name):");

                    foreach (var element in authorsAndISBNs2)
                    {
                        outputTextBox.AppendText($"\r\n\t{element.FirstName,-10} " +
                           $"{element.LastName,-10} {element.Title1,-10}");
                    }
                    break;
                case 2:

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
                        foreach (var author in title.authors)
                        {
                            outputTextBox.AppendText($"\r\n\t\t{author}");
                        }
                    }


                    break;
            }
        }
    }
}

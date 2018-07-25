using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BookRegistrationEF
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            PopulateBookComboBox();
        }

        private void PopulateBookComboBox()
        {
            List<Book> books = BookDB.GetAllBooks();

            cboBookList.DataSource = books;
            cboBookList.DisplayMember = nameof(Book.Title);
        }
    }
}

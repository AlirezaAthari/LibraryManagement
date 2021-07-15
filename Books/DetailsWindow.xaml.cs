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
using wpf_start.Models;

namespace wpf_start.Books
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>


    public partial class DetailsWindow : Window
    {

        public User CurrentUser { get; set; }
        public bool s { get; set; }
        public bool notsearch { get; set; }
        public DetailsWindow()
        {
            InitializeComponent();
        }
        protected void Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        protected void Add_Click(object sender, RoutedEventArgs e)
        {
            if ((lfullname.Text == "" || lauthor.Text == "" || lpart.Text == "" || lsituation.Text == "") && notsearch == true)
            {
                MessageBox.Show("Please fill all of the blanks!");
            }
            else
            {
                using (var db = new LibraryDatabase())
                {
                    var book = db.Books.FirstOrDefault(m => m.FullName == lfullname.Text);
                    var user = db.Members.FirstOrDefault(m => m.Username == lsituation.Text);
                    if ((book == null || s == true) && ( user != null || notsearch == false ))
                    {
                        DialogResult = true;
                        Close();
                    }
                    else if (user == null)
                    {
                        MessageBox.Show("Invalid username");
                        lsituation.Text = "";
                        lsituation.Focus();
                    }
                    else
                    {
                        MessageBox.Show("There is a book with this name in our server please change it.");
                    }
                }
            }
        }
    }
}
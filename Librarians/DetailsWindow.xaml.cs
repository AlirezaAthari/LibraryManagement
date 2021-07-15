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

namespace wpf_start.Librarians
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
            if ((lusername.Text == "" || lpart.Text == "" || laddress.Text == "" || lemail.Text == "" || lmobile.Text == "" || lpassword.Password == "") && notsearch == true)
            {
                MessageBox.Show("Please fill all of the blanks!");
            }
            else
            {
                if (lpassword.Password == lcpassword.Password)
                {
                    using (var db = new LibraryDatabase())
                    {
                        var user = db.Users.FirstOrDefault(m => m.Username == lusername.Text);
                        if (user == null || s == true)
                        {
                            DialogResult=true;
                            Close();
                        }
                        else
                        {
                            MessageBox.Show("There is a user with this username in our server please change it.");
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Password and Confirm Password are not match! please solve the problem.");
                    lpassword.Password = "";
                    lcpassword.Password = "";
                    lpassword.Focus();
                }
            }
        }
    }
}
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

namespace wpf_start
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {


        public LoginWindow()
        {
            InitializeComponent();
            using(var db = new LibraryDatabase())
            {
                if (db.Users.Count() == 0)
                {
                    db.Users.Add(new User{Username="Alireza",Password="1234"});
                    db.SaveChanges();
                }
            }
        }
        protected void Exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        protected void Login_Click(object sender, RoutedEventArgs e)
        {
            using (var db = new LibraryDatabase())
            {
                var user = db.Users.FirstOrDefault(m => (m.Password == lpassword.Password && m.Username == lusername.Text));
                if (user != null)
                {
                    var mainwindow = new MainWindow();
                    mainwindow.CurrentUser=user;
                    mainwindow.Show();
                    Close();
                }
                else
                {
                    MessageBox.Show("Error! Wrong username or password!");
                }

            }
        }
        protected void Sign_Up(object sender, RoutedEventArgs e)
        {
            var signupwindow = new SignUpWindow();
            signupwindow.Show();
        }
    }
}
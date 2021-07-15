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
    public partial class SignUpWindow : Window
    {
        public User CurrentUser { get; set; }
        public SignUpWindow()
        {
            InitializeComponent();
        }
        protected void Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        protected void Add_Click(object sender, RoutedEventArgs e)
        {
            if (lusername.Text != "" && laddress.Text != "" && lemail.Text != "" && lmobile.Text != "" && lpassword.Password != "")
            {
                if (lpassword.Password == lcpassword.Password)
                {
                    using (var db = new LibraryDatabase())
                    {
                        var user = db.Users.FirstOrDefault(m => m.Username == lusername.Text);
                        if (user == null)
                        {
                            /*if (lrole.Text == "Manager")
                            {
                                db.Managers.Add(new Manager
                                { Username = lusername.Text, Password = lpassword.Password, Role = "Manager", Mobile = lmobile.Text, Email = lemail.Text, Address = laddress.Text });
                                db.SaveChanges();
                                this.Close();
                            }
                            else if (lrole.Text == "Librarian")
                            {
                                db.Librarians.Add(new Librarian
                                { Username = lusername.Text, Password = lpassword.Password, Role = "Librarian", Mobile = lmobile.Text, Email = lemail.Text, Address = laddress.Text });
                                db.SaveChanges();
                                this.Close();
                            }*/
                            if (lrole.Text == "Member")
                            {
                                db.Members.Add(new Member
                                { Username = lusername.Text, Password = lpassword.Password, Role = "Member", Mobile = lmobile.Text, Email = lemail.Text, Address = laddress.Text });
                                db.SaveChanges();
                                this.Close();
                            }
                            else
                            {
                                MessageBox.Show("Invalid role please solve it");
                            }
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
            else
            {
                MessageBox.Show("Please fill all of the blanks!");
            }
        }
    }
}

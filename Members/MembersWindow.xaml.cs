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
using System.Windows.Threading;
using wpf_start.Books;
using wpf_start.Models;

namespace wpf_start.Members
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MembersWindow : Window
    {
        public User CurrentUser { get; set; }
        public MembersWindow()
        {
            InitializeComponent();
        }

        protected void WindowLoad(object sender, RoutedEventArgs e)
        {
            using (var db = new LibraryDatabase())
            {
                dgList.ItemsSource = db.Users.Where(k => k.Role == "Member" && k.Username != "Free").ToList();
            }
        }
        protected void Back_Button(object sender, RoutedEventArgs e)
        {
            var mainWindow = new MainWindow();
            mainWindow.CurrentUser = CurrentUser;
            mainWindow.Show();
            this.Close();
        }
        protected void Add(object sender, RoutedEventArgs e)
        {
            var detailsWindow = new DetailsWindow();
            detailsWindow.CurrentUser = CurrentUser;
            detailsWindow.s = false;
            detailsWindow.notsearch = true;
            using (var db = new LibraryDatabase())
            {
                if (detailsWindow.ShowDialog() == true)
                {
                    db.Members.Add(new Member
                    { Username = detailsWindow.lusername.Text, Password = detailsWindow.lpassword.Password, Role = "Member", Mobile = detailsWindow.lmobile.Text, Email = detailsWindow.lemail.Text, Address = detailsWindow.laddress.Text });
                    db.SaveChanges();
                    dgList.ItemsSource = db.Users.Where(k => k.Role == "Member" && k.Username != "Free").ToList();
                }
            }
        }
        protected void Edit(object sender, RoutedEventArgs e)
        {
            var detailsWindow = new DetailsWindow();
            detailsWindow.CurrentUser = CurrentUser;
            detailsWindow.s = true;
            detailsWindow.notsearch = true;
            var selected = dgList.SelectedItem as Member;
            if (selected == null)
            {
                MessageBox.Show("Please choose one of the items");
                return;
            }
            detailsWindow.lusername.Text = selected.Username;
            detailsWindow.lusername.IsReadOnly = true;
            detailsWindow.laddress.Text = selected.Address;
            detailsWindow.lemail.Text = selected.Email;
            detailsWindow.lmobile.Text = selected.Mobile;
            detailsWindow.lpassword.Password = selected.Password;
            detailsWindow.lcpassword.Password = selected.Password;
            if (detailsWindow.ShowDialog() == true)
            {
                using (var db = new LibraryDatabase())
                {
                    var edited = db.Members.FirstOrDefault(k => k.Id == selected.Id);
                    edited.Username = detailsWindow.lusername.Text;
                    edited.Mobile = detailsWindow.lmobile.Text;
                    edited.Email = detailsWindow.lemail.Text;
                    edited.Address = detailsWindow.laddress.Text;
                    edited.Password = detailsWindow.lpassword.Password;
                    dgList.ItemsSource = db.Users.Where(k => k.Role == "Member" && k.Username != "Free").ToList();
                }
            }
        }
        protected void Remove(object sender, RoutedEventArgs e)
        {
            var detailsWindow = new DetailsWindow();
            detailsWindow.CurrentUser = CurrentUser;
            detailsWindow.s = true;
            detailsWindow.notsearch = true;
            var selected = dgList.SelectedItem as Member;
            if (selected == null)
            {
                MessageBox.Show("Please choose one of the items");
                return;
            }
            detailsWindow.lmessage.Visibility = Visibility.Visible;
            detailsWindow.lusername.Text = selected.Username;
            detailsWindow.lusername.IsReadOnly = true;
            detailsWindow.laddress.Text = selected.Address;
            detailsWindow.laddress.IsReadOnly = true;
            detailsWindow.lemail.Text = selected.Email;
            detailsWindow.lemail.IsReadOnly = true;
            detailsWindow.lmobile.Text = selected.Mobile;
            detailsWindow.lmobile.IsReadOnly = true;
            detailsWindow.llpassword.Visibility = Visibility.Hidden;
            detailsWindow.llcpassword.Visibility = Visibility.Hidden;
            detailsWindow.lpassword.Password = selected.Password;
            detailsWindow.lpassword.Visibility = Visibility.Hidden;
            detailsWindow.lcpassword.Password = selected.Password;
            detailsWindow.lcpassword.Visibility = Visibility.Hidden;
            if (detailsWindow.ShowDialog() == true)
            {
                using (var db = new LibraryDatabase())
                {
                    var deleted = db.Members.FirstOrDefault(m => m.Id == selected.Id);
                    db.Managers.Remove(deleted);
                    db.SaveChanges();
                    dgList.ItemsSource = db.Users.Where(k => k.Role == "Member" && k.Username != "Free").ToList();
                }
            }
        }
        protected void Details(object sender, RoutedEventArgs e)
        {
            var selected = dgList.SelectedItem as Member;
            if (selected == null)
            {
                MessageBox.Show("Please choose one of the items");
                return;
            }
            using(var db = new LibraryDatabase())
            {
                var booksWindow = new BooksWindow();
                booksWindow.FromMembersWindow = true;
                booksWindow.Show();
                booksWindow.dgList.ItemsSource = db.Books.Where(k => k.Deposited == selected.Username).ToList();
                booksWindow.BackMembers.Visibility=Visibility.Visible;
                booksWindow.CurrentUser = CurrentUser;
                this.Close();
            }
        }
        protected void Search(object sender, RoutedEventArgs e)
        {
            var detailsWindow = new DetailsWindow();
            detailsWindow.CurrentUser = CurrentUser;
            detailsWindow.s = true;
            detailsWindow.notsearch = false;
            detailsWindow.lpassword.Visibility = Visibility.Hidden;
            detailsWindow.lcpassword.Visibility = Visibility.Hidden;
            detailsWindow.llpassword.Visibility = Visibility.Hidden;
            detailsWindow.llcpassword.Visibility = Visibility.Hidden;
            if (detailsWindow.ShowDialog() == true)
            {
                using (var db = new LibraryDatabase())
                {
                    dgList.ItemsSource = db.Members.Where(m => (m.Role == "Member" && m.Username != "Free") && (detailsWindow.lusername.Text == "" || m.Username.Contains(detailsWindow.lusername.Text)) &&
                                                                (detailsWindow.laddress.Text == "" || m.Address.Contains(detailsWindow.laddress.Text)) &&
                                                                (detailsWindow.lmobile.Text == "" || m.Mobile.Contains(detailsWindow.lmobile.Text)) &&
                                                                (detailsWindow.lemail.Text == "" || m.Email.Contains(detailsWindow.lemail.Text))).ToList();
                }
            }
        }
    }
}

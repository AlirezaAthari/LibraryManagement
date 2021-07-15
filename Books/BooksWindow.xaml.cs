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
using wpf_start.Members;
using wpf_start.Models;

namespace wpf_start.Books
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class BooksWindow : Window
    {
        public User CurrentUser { get; set; }
        public bool FromMembersWindow { get; set; }
        public BooksWindow()
        {
            InitializeComponent();
        }

        protected void WindowLoad(object sender, RoutedEventArgs e)
        {
            if (FromMembersWindow == true)
            {
                FromMembersWindow = false ;
                return;
            }
            BallBooks.Visibility=Visibility.Collapsed;
            using (var db = new LibraryDatabase())
            {
                dgList.ItemsSource = db.Books.ToList();
            }
            if (CurrentUser.Role == "Member")
            {
                Badd.Visibility=Visibility.Collapsed;
                Bedit.Visibility=Visibility.Collapsed;
                Bremove.Visibility=Visibility.Collapsed;
                BaddBook.Visibility=Visibility.Visible;
                BmyBooks.Visibility=Visibility.Visible;
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
            detailsWindow.lsituation.Text = "Free";
            detailsWindow.lsituation.IsReadOnly = true;
            using (var db = new LibraryDatabase())
            {
                if (detailsWindow.ShowDialog() == true)
                {
                    db.Books.Add(new Book
                    { FullName = detailsWindow.lfullname.Text , author = detailsWindow.lauthor.Text , Deposited = "Free" , Part = detailsWindow.lpart.Text});
                    db.SaveChanges();
                    dgList.ItemsSource = db.Books.ToList();
                }
            }
        }
        protected void Edit(object sender, RoutedEventArgs e)
        {
            var detailsWindow = new DetailsWindow();
            detailsWindow.CurrentUser = CurrentUser;
            detailsWindow.s = true;
            detailsWindow.notsearch = true;
            var selected = dgList.SelectedItem as Book;
            if (selected == null)
            {
                MessageBox.Show("Please choose one of the items");
                return;
            }
            detailsWindow.lfullname.Text = selected.FullName;
            detailsWindow.lauthor.Text = selected.author;
            detailsWindow.lpart.Text = selected.Part;
            detailsWindow.lsituation.Text = selected.Deposited;
            if (detailsWindow.ShowDialog() == true)
            {
                using (var db = new LibraryDatabase())
                {
                    var edited = db.Books.FirstOrDefault(k => k.Id == selected.Id);
                    edited.FullName = detailsWindow.lfullname.Text;
                    edited.Part = detailsWindow.lpart.Text;
                    edited.author = detailsWindow.lauthor.Text;
                    edited.Deposited = detailsWindow.lsituation.Text;
                    dgList.ItemsSource = db.Books.ToList();
                }
            }
        }
        protected void Remove(object sender, RoutedEventArgs e)
        {
            var detailsWindow = new DetailsWindow();
            detailsWindow.CurrentUser = CurrentUser;
            detailsWindow.s = true;
            detailsWindow.notsearch = true;
            var selected = dgList.SelectedItem as Book;
            if (selected == null)
            {
                MessageBox.Show("Please choose one of the items");
                return;
            }
            detailsWindow.lmessage.Visibility = Visibility.Visible;
            detailsWindow.lfullname.Text = selected.FullName;
            detailsWindow.lfullname.IsReadOnly = true;
            detailsWindow.lpart.Text = selected.Part;
            detailsWindow.lpart.IsReadOnly = true;
            detailsWindow.lsituation.Text = selected.Deposited;
            detailsWindow.lsituation.IsReadOnly = true;
            detailsWindow.lauthor.Text = selected.author;
            detailsWindow.lauthor.IsReadOnly = true;
            if (detailsWindow.ShowDialog() == true)
            {
                using (var db = new LibraryDatabase())
                {
                    var deleted = db.Books.FirstOrDefault(m => m.Id == selected.Id);
                    deleted.Deposited = "Free" ;
                    db.SaveChanges();
                    dgList.ItemsSource = db.Books.ToList();
                }
            }
        }
        protected void Search(object sender, RoutedEventArgs e)
        {
            var detailsWindow = new DetailsWindow();
            detailsWindow.CurrentUser = CurrentUser;
            detailsWindow.s = true;
            detailsWindow.notsearch = false;
            if (detailsWindow.ShowDialog() == true)
            {
                using (var db = new LibraryDatabase())
                {
                    dgList.ItemsSource = db.Books.Where(m =>    (detailsWindow.lfullname.Text == "" || m.FullName.Contains(detailsWindow.lfullname.Text)) &&
                                                                (detailsWindow.lpart.Text == "" || m.Part.Contains(detailsWindow.lpart.Text)) &&
                                                                (detailsWindow.lauthor.Text == "" || m.author.Contains(detailsWindow.lauthor.Text)) &&
                                                                (detailsWindow.lsituation.Text == "" || m.Deposited.Contains(detailsWindow.lsituation.Text))).ToList();
                }
            }
        }
        protected void AddBook (object sender , RoutedEventArgs e)
        {
            var selected = dgList.SelectedItem as Book;
            if (selected == null)
            {
                MessageBox.Show("Please choose one of the items");
                return;
            }
            else if (selected.Deposited == "Free")
            {
                using(var db = new LibraryDatabase())
                {
                    var book = db.Books.FirstOrDefault(k => k.Id == selected.Id);
                    book.Deposited = CurrentUser.Username;
                    db.SaveChanges();
                    dgList.ItemsSource = db.Books.ToList();
                }
                return;
            }
            else
            {
                MessageBox.Show("The book has been deposited to another member");
                return;
            }

        }
        protected void MyBooks (object sender , RoutedEventArgs e)
        {
            BallBooks.Visibility = Visibility.Visible;
            using(var db = new LibraryDatabase())
            {
                dgList.ItemsSource=db.Books.Where(k => k.Deposited == CurrentUser.Username).ToList();
            }
        }
        protected void Members(object sender , RoutedEventArgs e)
        {
            var membersWindow = new MembersWindow();
            membersWindow.CurrentUser=CurrentUser;
            membersWindow.Show();
            this.Close();
        }
    }
}

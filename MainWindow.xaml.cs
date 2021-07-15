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
using wpf_start.Librarians;
using wpf_start.Managers;
using wpf_start.Members;
using wpf_start.Models;

namespace wpf_start
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public User CurrentUser { get; set; }
        DispatcherTimer timer = new DispatcherTimer();
        public MainWindow()
        {
            InitializeComponent();
        }
        protected void WindowLoad(object sender, RoutedEventArgs e)
        {
            lUsername.Content = CurrentUser.Username;
            lRole.Content=CurrentUser.Role;
            timer.Tick += new EventHandler(timer_Tick);
            timer.Interval = new TimeSpan(0,0,1);
            timer.Start();
            if (CurrentUser.Role == "Member")
            {
                Bmembers.Visibility= Visibility.Hidden;
                Bmanagers.Visibility= Visibility.Hidden;
                Blibrarians.Visibility= Visibility.Hidden;
            }
            else if (CurrentUser.Role == "Librarian")
            {
                Bmanagers.Visibility= Visibility.Hidden;
                Blibrarians.Visibility= Visibility.Hidden;
            }

        }
        void timer_Tick(object sender, EventArgs e)
		{
			lDate.Content = DateTime.Now.ToString();
		}
        protected void Managers(object sender , RoutedEventArgs e)
        {
            var managersWindow = new ManagersWindow();
            managersWindow.CurrentUser=CurrentUser;
            managersWindow.Show();
            this.Close();
        }
        protected void Librarians(object sender , RoutedEventArgs e)
        {
            var librariansWindow = new LibrariansWindow();
            librariansWindow.CurrentUser=CurrentUser;
            librariansWindow.Show();
            this.Close();
        }
        protected void Members(object sender , RoutedEventArgs e)
        {
            var membersWindow = new MembersWindow();
            membersWindow.CurrentUser=CurrentUser;
            membersWindow.Show();
            this.Close();
        }
        protected void Books(object sender , RoutedEventArgs e)
        {
            var booksWindow = new BooksWindow();
            booksWindow.FromMembersWindow = false;
            booksWindow.CurrentUser=CurrentUser;
            booksWindow.Show();
            this.Close();
        }
        protected void Exit_Click(object sender, RoutedEventArgs e)
        {
            var LoginWindow = new LoginWindow();
            LoginWindow.Show();
            this.Close();
        }
    }
}

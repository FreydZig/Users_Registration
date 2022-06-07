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
using System.Windows.Media.Animation;

namespace Registration
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        ApplicationContext db;

        public MainWindow()
        {
            InitializeComponent();

            db = new ApplicationContext();

            DoubleAnimation doubleAnimation = new DoubleAnimation();

            doubleAnimation.From = 0;
            doubleAnimation.To = 500;
            doubleAnimation.Duration = TimeSpan.FromSeconds(2);
            regButton.BeginAnimation(Button.WidthProperty, doubleAnimation);
        }

        private void Button_Click_Sign(object sender, RoutedEventArgs e)
        {
            string login = textBoxLogin.Text.Trim();
            string password = passwordBoxPassword.Password.Trim();
            string passwordRep = passwordBoxPasswordRep.Password.Trim();
            string email = textBoxEmail.Text.Trim().ToLower();
            bool CheckLog = false, CheckPas = false, CheckPasR = false, CheckEmail = false;

            if (login.Length < 5)
            {
                textBoxLogin.ToolTip = "This field is not correct";
                textBoxLogin.Background = Brushes.IndianRed;
                CheckLog = false;
            }
            else
            {
                textBoxLogin.ToolTip = null;
                textBoxLogin.Background = Brushes.White;
                CheckLog = true;
            }

            if (password.Length < 5)
            {
                passwordBoxPassword.ToolTip = "This field is not correct";
                passwordBoxPassword.Background = Brushes.IndianRed;
                CheckPas = false;
            }
            else
            {
                passwordBoxPassword.ToolTip = null;
                passwordBoxPassword.Background = Brushes.White;
                CheckPas = true;
            }

            if (passwordRep != password)
            {
                passwordBoxPasswordRep.ToolTip = "This field is not correct";
                passwordBoxPasswordRep.Background = Brushes.IndianRed;
                CheckPasR = false;
            }
            else
            {
                passwordBoxPasswordRep.ToolTip = null;
                passwordBoxPasswordRep.Background = Brushes.White;
                CheckPasR = true;
            }

            if (email.Length < 5 || !email.Contains("@") || !email.Contains("."))
            {
                textBoxEmail.ToolTip = "This field is not correct";
                textBoxEmail.Background = Brushes.IndianRed;
                CheckEmail = false;
            }
            else
            {
                textBoxEmail.ToolTip = null;
                textBoxEmail.Background = Brushes.White;
                CheckEmail = true;
            }
            if(CheckLog && CheckPas && CheckPasR && CheckEmail)
            {
                textBoxLogin.ToolTip = null;
                textBoxLogin.Background = Brushes.Transparent;
                passwordBoxPassword.ToolTip = null;
                passwordBoxPassword.Background = Brushes.Transparent;
                passwordBoxPasswordRep.ToolTip = null;
                passwordBoxPasswordRep.Background = Brushes.Transparent;
                textBoxEmail.ToolTip = null;
                textBoxEmail.Background = Brushes.Transparent;

                MessageBox.Show("Correct!");

                User user = new User(login, password, email);

                db.Users.Add(user);
                db.SaveChanges();

                AuthWindow authWindow = new AuthWindow();
                authWindow.Show();
                this.Hide();
            }
        }

        private void Button_WindowAuth_Click(object sender, RoutedEventArgs e)
        {
            AuthWindow authWindow = new AuthWindow();
            authWindow.Show();
            this.Hide();
        }
    }
}

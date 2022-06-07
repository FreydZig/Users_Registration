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
using System.Windows.Shapes;

namespace Registration
{
    /// <summary>
    /// Логика взаимодействия для AuthWindow.xaml
    /// </summary>
    public partial class AuthWindow : Window
    {
        public AuthWindow()
        {
            InitializeComponent();
        }

        private void Button_Click_Auth(object sender, RoutedEventArgs e)
        {
            string login = textBoxLogin.Text.Trim();
            string password = passwordBoxPassword.Password.Trim();
            bool CheckLog = false, CheckPas = false;

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

            if (CheckLog && CheckPas)
            {
                textBoxLogin.ToolTip = null;
                textBoxLogin.Background = Brushes.Transparent;
                passwordBoxPassword.ToolTip = null;
                passwordBoxPassword.Background = Brushes.Transparent;

                User authuser = null;

                using (ApplicationContext db = new ApplicationContext())
                {
                    authuser = db.Users.Where(b => b.Login == login && b.Password == password).FirstOrDefault();
                }

                if (authuser != null) { 
                    //MessageBox.Show("Correct!"); 
                    UserPageWindow userPageWindow = new UserPageWindow();
                    userPageWindow.titleUserPage.Text += ", " + authuser.Login + "!"; 
                    userPageWindow.Show();
                    this.Hide();
                }
                else MessageBox.Show("Null!");

            }
        }

        private void Button_WindowReg_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Hide();
        }
    }
    
}

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
    /// Логика взаимодействия для UserPageWindow.xaml
    /// </summary>
    public partial class UserPageWindow : Window
    {
        public UserPageWindow()
        {
            InitializeComponent();

            ApplicationContext db = new ApplicationContext();
            List<User> users = db.Users.ToList(); 

            listOfUsers.ItemsSource = users;
        }

        private void ContMenuDelete(object sender, RoutedEventArgs e)
        {
            //var contextMenu = (ContextMenu)sender;
            //var textBox = (TextBox)contextMenu.SourseControl;
            //var tag = textBox.Text;

            //MessageBoxResult result = MessageBox.Show(
            //    "Are you sure?",
            //    "Confirmation",
            //    MessageBoxButton.YesNo,
            //    MessageBoxImage.Question
            //    );
            //if (result == MessageBoxResult.Yes)
            //{
            //    using (ApplicationContext db = new ApplicationContext())
            //    {
            //        var orderInDb = db.Users.First(x => x.id == int.Parse(tag));
            //        db.Users.Remove(orderInDb);
            //        db.SaveChanges();
            //    }
            //}
            //else MessageBox.Show("No!");
        }

        private void ContMenuChange(object sender, RoutedEventArgs e)
        {

        }



    }
}

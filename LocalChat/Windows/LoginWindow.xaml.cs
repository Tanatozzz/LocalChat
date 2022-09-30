using LocalChat.Classes;
using LocalChat.Windows;
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

namespace LocalChat
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        private bool CurrentOnlineStatus;
        public LoginWindow()
        {
            InitializeComponent();
        }
        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }

        private void ButtonMinimaze_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void ButtonMaximazed_Click(object sender, RoutedEventArgs e)
        {
            if (this.WindowState != WindowState.Maximized)
            {
                this.WindowState = WindowState.Maximized;
                this.ResizeMode = ResizeMode.NoResize;
            }
            else
            {
                this.WindowState = WindowState.Normal;
            }
        }

        private void ButtonClose_Click(object sender, RoutedEventArgs e)
        {
            //CurrentOnlineStatus = false;
            Class1.Context.SaveChanges();
            Application.Current.Shutdown();
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var authUser = Classes.Class1.Context.User.ToList()
                .Where(i => i.Nickname.Equals(txtLog.Text)).FirstOrDefault();
            //CurrentOnlineStatus = authUser.OnlineStatus;
            if (authUser != null)
            {
                CurrentOnlineStatus = true;
                Class1.Context.SaveChanges();
                MainWindow chatWindow = new MainWindow(authUser);
                this.Close();
                
                chatWindow.Show();

            }
            else
            {
                MessageBox.Show("Пользовател не найден");
            }
        }
    }
}

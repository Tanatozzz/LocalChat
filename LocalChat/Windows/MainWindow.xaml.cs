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

namespace LocalChat.Windows
{
    /// <summary>
    /// Логика взаимодействия для MainChat.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            
            InitializeComponent();
            List<EF.User> users = new List<EF.User>();
            users = Classes.Class1.Context.User.ToList();
            lvUsers.ItemsSource = users;
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
            Application.Current.Shutdown();
        }

        private void lvUsers_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void lvUsers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var smth = (lvUsers.SelectedItem as EF.User);

            var userD = smth.ID;
            List<EF.User> UserSelected = new List<EF.User>();
            List<EF.ChatUser> ChatUserSelected = new List<EF.ChatUser>();
            List<EF.Chat> ChatSelected = new List<EF.Chat>();
            List<EF.Message> MessageSselected = new List<EF.Message>();
            var chatuser1 = ChatUserSelected.Where(i =>
            i.IDUser == userD).ToList();
            lvChat.ItemsSource = chatuser1;
            //var chat13 = MessageSselected.Where(i => i.IDChat == (chat1)).ToList();
            //var allMessages = MessageSselected.Where(i => i.IDChat == (chat1)).ToList();
        }
    }
}

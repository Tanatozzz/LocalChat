using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;


namespace LocalChat.Windows
{
    /// <summary>
    /// Логика взаимодействия для MainChat.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private int currentUserID;
        public MainWindow(EF.User authUser)
        {
            
            InitializeComponent();
            currentUserID = authUser.ID;
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

        }
    }
}

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
using System.ComponentModel;
using System.Collections.ObjectModel;

namespace ASILab6
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        MainViewModel context = new MainViewModel();
        
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = context;
        }

        void Window_Closing(object sender, CancelEventArgs e)
        {
            if (context.isDataChanged)
            {
                string msg = "Данные не сохранены. Выйти без сохранения?";
                MessageBoxResult result =
                  MessageBox.Show(
                    msg,
                    "Воу-Воу",
                    MessageBoxButton.YesNo,
                    MessageBoxImage.Warning);
                if (result == MessageBoxResult.No)
                {
                    e.Cancel = true;
                }
            }
        }
        
        private void AddGroup_Click(object sender, RoutedEventArgs e)
        {
            int _year = Convert.ToInt32(groupYear.Text);
            (DataContext as MainViewModel).AddGroup(groupName.Text, _year);
            groupName.Text = "";
            groupYear.Text = "";
        }

        private void AddStudent_Click(object sender, RoutedEventArgs e)
        {
            DialogStudent studWindow = new DialogStudent();
            studWindow.DataContext = context;
            studWindow.ShowDialog();
        }

        private void AddProject_Click(object sender, RoutedEventArgs e)
        {
            if (context.SelectedStudentIndex != -1)
            {
                DialogProject projWindow = new DialogProject();
                projWindow.DataContext = context;
                projWindow.ShowDialog();
            }
            else
            {
                MessageBox.Show("Не выбран студент. Немедленно выбрать!!!", "Полегче",MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
        }

        private void Quit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            (DataContext as MainViewModel).Save();
        }
    }
}

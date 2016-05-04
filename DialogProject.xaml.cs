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
using System.Windows.Navigation;

namespace ASILab6
{
    /// <summary>
    /// Логика взаимодействия для DialogProject.xaml
    /// </summary>
    public partial class DialogProject : Window
    {
        public DialogProject()
        {
            InitializeComponent();
        }        

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            short _term = Convert.ToInt16(projectTerm.Text);
            (DataContext as MainViewModel).AddProject(projectName.Text, _term, projectContent.Text);
            this.Close();
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}

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

namespace Typer.Controls
{
    /// <summary>
    /// Логика взаимодействия для About.xaml
    /// </summary>
    public partial class AboutView : UserControl, ICloseControl
    {
        public AboutView()
        {
            InitializeComponent();
        }

        public event GoBack GoBackEvent;

        private void GoToMenuButton_Click(object sender, RoutedEventArgs e)
        {
            GoBackEvent?.Invoke();
        }
    }
}

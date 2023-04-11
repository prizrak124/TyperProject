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
    /// Логика взаимодействия для DifficultSelect.xaml
    /// </summary>
    public partial class DifficultListView : UserControl, ICloseControl
    {
        public delegate void DifficultSelectDelegate(DifficultEnum difficult);
        
        public event DifficultSelectDelegate DifficultSelectEvent;
        public event GoBack GoBackEvent;

        public DifficultListView()
        {
            InitializeComponent();
        }
        private void ButtonNormalGame_Click(object sender, RoutedEventArgs e)
        {
            if (DifficultSelectEvent != null)
                DifficultSelectEvent.Invoke(DifficultEnum.Normal);
        }

        private void ButtonHardGame_Click(object sender, RoutedEventArgs e)
        {
            if (DifficultSelectEvent != null)
                DifficultSelectEvent.Invoke(DifficultEnum.Hard);
        }
        private void ButtonBack_Click(object sender, RoutedEventArgs e)
        {
            if (GoBackEvent != null)
                GoBackEvent.Invoke();
        }

        private void ButtonEasyGame_Click(object sender, RoutedEventArgs e)
        {
            if (DifficultSelectEvent != null)
                DifficultSelectEvent.Invoke(DifficultEnum.Easy);
        }
    }
}

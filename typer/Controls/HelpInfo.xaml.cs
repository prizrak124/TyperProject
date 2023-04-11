using System;
using System.Collections.Generic;
using System.Diagnostics;
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
    /// Логика взаимодействия для HelpInfo.xaml
    /// </summary>
    public partial class HelpInfo : UserControl, ICloseControl
    {
        public HelpInfo()
        {
            InitializeComponent();
            this.GameTextPathTb.Text = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, Settings.Instance.DataGamePath);
            this.GameTextPathTb1.Text = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, Settings.Instance.AudiosPath);
        }

        public event GoBack GoBackEvent;

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            GoBackEvent?.Invoke();
        }

        private void OpenGameTextPath1_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Process.Start(GameTextPathTb1.Text);
            }
            catch(Exception ex)
            {
                MessageBox.Show("Ошибка:"+ex);
            }
        }

        private void OpenGameTextPath_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Process.Start(GameTextPathTb.Text);
            }
            catch(Exception ex)
            {
                MessageBox.Show("Ошибка:" + ex);
            }
        }
    }
}

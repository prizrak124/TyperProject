using System;
using System.Collections.Generic;
using System.IO;
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
    /// Логика взаимодействия для LevelSelect.xaml
    /// </summary>
    public partial class LevelListView : UserControl, ICloseControl
    {
        public delegate void OpenLevel(FileInfo file);
        public event OpenLevel OpenLevelEvent;
        public event GoBack GoBackEvent;

        public LevelListView()
        {
            InitializeComponent();
        }

        public void Load(DirectoryInfo dir)
        {
            ListViewLevel.Items.Clear();
            foreach (var file in dir.GetFiles("*.txt"))
                ListViewLevel.Items.Add(file);
        }
       

        private void ButtonBack_Click(object sender, RoutedEventArgs e)
        {
            if (GoBackEvent != null)
                GoBackEvent.Invoke();
        }

        private void ButtonLevel_Click(object sender, RoutedEventArgs e)
        {
            FileInfo fileInfo = (sender as Button).DataContext as FileInfo;
            if (OpenLevelEvent != null)
                OpenLevelEvent.Invoke(fileInfo);
        }
    }
}

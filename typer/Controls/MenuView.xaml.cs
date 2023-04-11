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
    /// Логика взаимодействия для MainMenu.xaml
    /// </summary>
    public partial class MenuView : UserControl
    {
        public delegate void SelectMenuItem(MenuItemEnum itemEnum);
        public event SelectMenuItem SelectedMenuItem;
      
        public MenuView()
        {
            InitializeComponent();
            Settings.Instance.Load();
            AudioPlayer.SetAudio(Settings.Instance.StandartAudio);
            AudioPlayer.Play();
        }

        private void ButtonExit_Click(object sender, RoutedEventArgs e)
        {
           App.Current.Shutdown();
        }

        private void ButtonGame_Click(object sender, RoutedEventArgs e)
        {
            if (SelectedMenuItem != null)
                SelectedMenuItem.Invoke(MenuItemEnum.Play);
        }

        private void ButtonSettings_Click(object sender, RoutedEventArgs e)
        {
            if (SelectedMenuItem != null)
                SelectedMenuItem.Invoke(MenuItemEnum.Settings);
        }

        private void ButtonInfo_Click(object sender, RoutedEventArgs e)
        {
            SelectedMenuItem.Invoke(MenuItemEnum.Info);
        }

        private void ButtonHelp_Click(object sender, RoutedEventArgs e)
        {
            SelectedMenuItem.Invoke(MenuItemEnum.Help);
        }
    }
}

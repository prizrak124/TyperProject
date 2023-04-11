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

namespace Typer
{
    /// <summary>
    /// Логика взаимодействия для MainMenu.xaml
    /// </summary>
    public partial class Menu : UserControl
    {
        public delegate void SelectMenuItem(MenuItemEnum itemEnum);
        public event SelectMenuItem SelectedMenuItem;
        public Menu()
        {
            InitializeComponent();
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
    }
}

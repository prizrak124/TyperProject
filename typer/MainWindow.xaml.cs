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

using Typer.Controls;

namespace Typer
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private GameView _GameView;
        private MenuView _MenuView;
        private LevelListView _LevelListView;
        private DifficultListView _DifficultListView;
        private SettingsView _SettingsView;
        private AboutView _AboutView;
        private HelpInfo _HelpView;

        private MenuItemEnum CurrentMenuItemOpenned = MenuItemEnum.Exit;
        public MainWindow()
        {

            
            InitializeComponent();

            CreateDirs();

            _HelpView = new HelpInfo();
            
            _AboutView = new AboutView();
            _GameView = new GameView();
            _MenuView = new MenuView();


            _LevelListView = new LevelListView();
            _DifficultListView = new DifficultListView();

            _SettingsView = new SettingsView();

            _HelpView.GoBackEvent += HelpView_GoBackEvent;

            _AboutView.GoBackEvent += AboutView_GoBackEvent;
            _SettingsView.GoBackEvent += SettingsView_GoBackEvent;


            _MenuView.SelectedMenuItem += Menu_SelectedMenuItem;

            _DifficultListView.DifficultSelectEvent += DifficultListView_DifficultSelectEvent;
            _LevelListView.OpenLevelEvent += SelectLevel_OpenLevelEvent;

            _DifficultListView.GoBackEvent += DifficultListView_GoBackEvent;
            _LevelListView.GoBackEvent += LevelListView_GoBackEvent;

            _GameView.ExitGameEvent += GameView_ExitGameEvent;
            _GameView.OpenSettingsEvent += GameView_OpenSettingsEvent;
            _GameView.OpenHelpEvent += GameView_OpenHelpEvent;

            SetContent(_MenuView);
            

        }

        private void GameView_OpenHelpEvent()
        { 
            SetContent(_HelpView);
        }

        private void GameView_OpenSettingsEvent()
        {
            SetContent(_SettingsView);
            _SettingsView.Load();
        }


      
        private void DifficultListView_DifficultSelectEvent(DifficultEnum difficult)
        {
            switch (difficult)
            {
                case DifficultEnum.Easy:
                    {
                        _LevelListView.Load(new System.IO.DirectoryInfo(Settings.Instance.EasyGamePath));

                        break;
                    }
                case DifficultEnum.Normal:
                    {
                        _LevelListView.Load(new System.IO.DirectoryInfo(Settings.Instance.NormanlGamePath));

                        break;
                    }

                case DifficultEnum.Hard:
                    {
                        _LevelListView.Load(new System.IO.DirectoryInfo(Settings.Instance.HardGamePath));

                        break;
                    }

            }
            SetContent(_LevelListView);
        }

        private void GameView_ExitGameEvent() =>
            SetContent(_MenuView);
        

        //выход из меню выбора уровня
        private void LevelListView_GoBackEvent() =>
            SetContent(_DifficultListView);
        
        //Dыход из меню выбора сложности
        private void DifficultListView_GoBackEvent() =>
            SetContent(_MenuView);

        private void SettingsView_GoBackEvent()
        {
            if (_GameView.GameState == Enums.GameStateEnum.Finished) SetContent(_MenuView);
            else SetContent(_GameView);
        }

        private void AboutView_GoBackEvent()
        {
            SetContent(_MenuView);
        }
        private void HelpView_GoBackEvent()
        {
            if (_GameView.GameState != Enums.GameStateEnum.Finished)
            {
                SetContent(_GameView);
               
            }
            else SetContent(_MenuView);
        }
        //Выбор уровня
        private void SelectLevel_OpenLevelEvent(FileInfo file)
        {
            try
            {
                _GameView.Load(file.FullName);
                
                SetContent(_GameView);
            }
            catch(Exception EX)
            {
                MessageBox.Show($"Ошибка открытия игры:{EX.Message}");
            }
        }
      
        //выбор сложности
      
        //выбор элемента в главном меню
        private void Menu_SelectedMenuItem(MenuItemEnum itemEnum)
        {
            switch (itemEnum)
            {
                case MenuItemEnum.Play:
                    {
                        SetContent(_DifficultListView);
                        break;
                    }
                case MenuItemEnum.Settings:
                    {
                        SetContent(_SettingsView);
                        _SettingsView.Load();
                        break;
                    }
                case MenuItemEnum.Info:
                    {
                        SetContent(_AboutView);
                        break;
                    }
                case MenuItemEnum.Help:
                    {
                        SetContent(_HelpView);
                        break;
                    }
                
            }
            CurrentMenuItemOpenned = itemEnum;

        }

        private void CreateDirs()
        {
            var dir = new DirectoryInfo(Settings.Instance.DataGamePath);
            if (!dir.Exists) dir.Create();

            if (!(dir = new DirectoryInfo(Settings.Instance.EasyGamePath)).Exists)
                dir.Create();

            if (!(dir = new DirectoryInfo(Settings.Instance.NormanlGamePath)).Exists)
                dir.Create();

            if (!(dir = new DirectoryInfo(Settings.Instance.HardGamePath)).Exists)
                dir.Create();

            if (!(dir = new DirectoryInfo(Settings.Instance.AudiosPath)).Exists)
                dir.Create();
        }
        private void SetContent(UserControl control) =>
            ContentFrame.Content = control.Content;

        private void Window_LostFocus(object sender, RoutedEventArgs e)
        {
            
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.Escape)
            {
                switch (CurrentMenuItemOpenned)
                {
                    case MenuItemEnum.Play:
                    {
                            if (_GameView.GameState == Enums.GameStateEnum.Played)
                                _GameView.PauseGame();
                            break;
                    }
                }
            }
        }
    }
}

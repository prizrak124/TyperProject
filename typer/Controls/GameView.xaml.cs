using System;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Animation;
using System.Windows.Threading;

using Typer.Enums;

using WpfAnimatedGif;

namespace Typer.Controls
{
    /// <summary>
    /// Логика взаимодействия для Game.xaml
    /// </summary>
    public partial class GameView : UserControl
    {
        public delegate void GameEvent();

        public event GameEvent ExitGameEvent;
        public event GameEvent OpenSettingsEvent;
        public event GameEvent OpenHelpEvent;

        private DispatcherTimer _GameTimer;
        private StreamReader _Reader;

        private string _Cline;
        private TimeSpan _GameTime;
        private TimeSpan _TopGameTime;
        private string _FilePath;

        private const string TimeFormat = @"mm\:ss\:ff";
        private const string SavedTimeLine = "TopTypeTime;";
        public GameStateEnum GameState { get; private set; } =  GameStateEnum.Finished;

        public GameView()
        {
            InitializeComponent();

            TextBoxInputLine.PreviewTextInput += TextBoxInputLine_PreviewTextInput;
            TextBoxInputLine.PreviewKeyDown += TextBoxInputLine_KeyDown;

            _GameTimer = new DispatcherTimer(new TimeSpan(0, 0, 0, 0, 10), DispatcherPriority.Background, delegate
            {
                _GameTime = _GameTime.Add(TimeSpan.FromMilliseconds(10));
                
                TextBlockTime.Text = $"Время: {TimeToString(_GameTime)}"; 
               
            }, Dispatcher);
            StopTimer();

            ImageBehavior.SetRepeatBehavior(EaterImg, RepeatBehavior.Forever);

        }

        public void Load(string filePath)
        {

            WinPanel.Visibility = Visibility.Collapsed;
            ButtonPauseResume.Content = "Играть";

            ClearWinInfoData();
            ClearGameInfoData();
            FreeReader();

            _FilePath = filePath;
            _Reader = new StreamReader(_FilePath);
            _GameTime = new TimeSpan(0);
            
            ReadNextLine();

            if (_TopGameTime != null)   
                 TextBlockTopTime.Text = $"Лучшее время:\n {TimeToString(_TopGameTime)}";
        } 

        public void PauseGame()
        {
           
            AudioPlayer.Pause();
            ButtonPauseResume.Content = "Продолжить";
            StopTimer();

            GameState = GameStateEnum.Paused;
        }
       
        public void ResumeGame()
        {
            TextBoxInputLine.Focus();
            GameState = GameStateEnum.Played;
            if (AudioPlayer.AudioPlayerState == AudioPlayerStateEnum.Paused )
                AudioPlayer.Play(); 
            ButtonPauseResume.Content = "Пауза";
            StartTimer();

            
        }
        //Завершение игры
        public void GameFinished()
        {
            StopTimer();
            SaveRecordData();
            WinPanel.Visibility = Visibility.Visible;
            TextBlockWinAllText.Text = TextBlockAllText.Text;
            TextBlockWinTime.Text = TextBlockTime.Text;
            ClearGameInfoData();
        }
        //Сохранение текст с новым результатом времени
        public void SaveRecordData()
        {
          
                FreeReader();
                _Reader = new StreamReader(_FilePath);
                StreamWriter writer = new StreamWriter(_FilePath + "tmp");

                bool isTimeWrited = false;
                while (_Reader.EndOfStream == false)
                {
                    if (isTimeWrited == false)
                    {
                        isTimeWrited = true;

                        if (_GameTime.TotalMilliseconds > _TopGameTime.TotalMilliseconds)
                            writer.WriteLine(SavedTimeLine + TimeToString(_GameTime));
                    }
                    writer.WriteLine(_Reader.ReadLine());
                }

                FreeReader();
                writer.Dispose();

                File.Delete(_FilePath);
                File.Move(_FilePath + "tmp", _FilePath);
            
        }

        //Завершает игру очищая ресурсы
        public void EndGame()
        {
            GameState = GameStateEnum.Finished;

            StopTimer();
            ClearGameInfoData();
            ClearWinInfoData();
            FreeReader();
          
            if (AudioPlayer.AudioPlayerState == AudioPlayerStateEnum.Paused) 
                AudioPlayer.Play();

        }

        public void StartTimer() => _GameTimer.Start();
        
        public void StopTimer() =>  _GameTimer.Stop();

        //Очистка панели выйгрыша
        private void ClearWinInfoData()
        {
            TextBlockWinAllText.Text = string.Empty;
            TextBlockWinTime.Text = string.Empty;
        }
        //Очистка игровой панели
        private void ClearGameInfoData()
        {
            TextBlockAllText.Text = string.Empty;
            TextBlockCurrentLine.Text = string.Empty;
            TextBlockTime.Text = string.Empty;
            TextBlockTopTime.Text = string.Empty;

            _GameTime = new TimeSpan(0);
            _Cline = string.Empty;
            
           
        }
        //Очищает неуправляемые ресурсы
        private void FreeReader()
        {
            if (_Reader != null)
            {
                _Reader.Close();
                _Reader.Dispose();
            }
        }
        
        private string TimeToString(TimeSpan timeSpan) => timeSpan.ToString(TimeFormat);
        private TimeSpan StringToTime(string timeString) =>
           TimeSpan.ParseExact(timeString, TimeFormat, CultureInfo.InvariantCulture);
        private void ReadNextLine()
        {

            if (_Reader != null && _Reader.BaseStream.Length > 0)
            {
                do
                {
                    if (!_Cline.Contains(SavedTimeLine))
                        TextBlockAllText.Text += _Cline + "\n";
                    
                    if (_Reader.EndOfStream)
                    {
                        GameFinished();
                        break;
                    }
                    else
                    {
                        _Cline = _Reader.ReadLine().Trim();

                        if (_Cline.Contains(SavedTimeLine))
                        {
                            _TopGameTime = StringToTime(_Cline.Split(';')[1]);
                            ReadNextLine();
                        }

                        else 
                        {
                            TextBlockCurrentLine.Text = _Cline; 
                        }
                    }
                }
                while (_Cline.Length == 0 || _Cline[0] == '\r');

            }
            else
            {
                throw new Exception("Ошибка чтения файла");
            }
        }

        private void TextBoxInputLine_KeyDown(object sender, KeyEventArgs e)
        {
            if (GameState == GameStateEnum.Paused || GameState == GameStateEnum.Finished)
                ResumeGame();
            
            if (e.Key == Key.Back)
                e.Handled = true;
            
            else if (e.Key == Key.Space)
            {
                if (TextBlockCurrentLine.Text[0] == ' ')
                    TextBlockCurrentLine.Text = TextBlockCurrentLine.Text.Remove(0, 1);

                else e.Handled = true;
            }
        }
        
        private void TextBoxInputLine_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            try
            {
                if (e.Text.Length == 0)
                {
                    e.Handled = true;
                    return;
                }

                if (TextBlockCurrentLine.Text.Length == 1)
                {
                    ReadNextLine();
                    e.Handled = true;
                    TextBoxInputLine.Text = String.Empty;
                }

                else if (e.Text[0] != TextHelper.GetSymbol(TextBlockCurrentLine.Text[0]))
                {
                    e.Handled = true;
                }
                else
                {
                    TextBlockCurrentLine.Text = TextBlockCurrentLine.Text.Remove(0, 1);
                    e.Handled = false;
                }
            }
            catch(Exception)
            {

            }
        }

        private void ButtonPauseResume_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            if(GameState == GameStateEnum.Paused || GameState == GameStateEnum.Finished) 
                 ResumeGame();
            else PauseGame();
        }

        private void ButtonExit_Click(object sender, RoutedEventArgs e)
        {

            EndGame();
            if (ExitGameEvent != null)
                ExitGameEvent.Invoke();
        }

        private void ButtonSettings_Click(object sender, RoutedEventArgs e)
        {
            StopTimer();
            ButtonPauseResume.Content = "Продолжить";
            GameState = GameStateEnum.Paused;
            if (OpenSettingsEvent != null)
                OpenSettingsEvent.Invoke();
        }
        private void ButtonHelp_Click(object sender, RoutedEventArgs e)
        {
            StopTimer();
            ButtonPauseResume.Content = "Продолжить";
            GameState = GameStateEnum.Paused;
            if (OpenHelpEvent!= null)
                OpenHelpEvent.Invoke();
        }

        private void ButtonResumeGame_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Load(_FilePath);
            }
            catch(Exception ex)
            {
                MessageBox.Show($"Ошибка перезапуска игры:\n{ex.Message}");
            }
        }

        private void Image_AnimationCompleted(object sender, RoutedEventArgs e)
        {
            
        }

       
    }
}

using System;
using System.Diagnostics;
using System.IO;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Threading;

using static System.Net.Mime.MediaTypeNames;

namespace Typer
{
    /// <summary>
    /// Логика взаимодействия для Game.xaml
    /// </summary>
    public partial class Game : UserControl
    {
        private DispatcherTimer _GameTimer;
        private StreamReader _Reader;
        private string _Cline;
        private TimeSpan _GameTime;
        
        public bool IsPaused { get; set; }
        
       
        public Game()
        {
            InitializeComponent();
            TextBoxInputLine.PreviewTextInput += TextBoxInputLine_PreviewTextInput;
            TextBoxInputLine.PreviewKeyDown += TextBoxInputLine_KeyDown;

            _GameTimer = new DispatcherTimer(new TimeSpan(0, 0, 0, 0, 10), DispatcherPriority.Background, delegate
            {
                _GameTime = _GameTime.Add(TimeSpan.FromMilliseconds(10));
                try
                {
                    TextBlockTime.Text = $"Время: {_GameTime.Minutes}:{_GameTime.Seconds}:{_GameTime.Milliseconds / 10}";
                }
                catch (Exception EX) { }
            }, Dispatcher);
            PauseGame();

        }
        public void Load(string filePath)
        {
            _Reader = new StreamReader(filePath);
        }

        public void GameFinished()
        {
            TextBoxInputLine.IsEnabled = false;
            EndGame();
        }

        public void StartGame()
        {
            _GameTime = new TimeSpan(0);
            ReadNextLine();
        }
        public void PauseGame()
        {
            IsPaused = true;
            ButtonPauseResume.Content = "Продолжить";
            _GameTimer.Stop();
        }

        public void ResumeGame()
        {
            IsPaused = false;
            ButtonPauseResume.Content = "Пауза";
            _GameTimer.Start();
        }

        public void EndGame()
        {
            _GameTimer.Stop();
            _Reader.Close();
            _Reader.Dispose();
        }
        private void TextBoxInputLine_KeyDown(object sender, KeyEventArgs e)
        {
            if (IsPaused)
            {
                ResumeGame();
            }
            if (e.Key == Key.Back)
            {
                e.Handled = true;
            }
            else if (e.Key == Key.Space)
            {
                if (TextBlockCurrentLine.Text[0] == ' ')
                    TextBlockCurrentLine.Text = TextBlockCurrentLine.Text.Remove(0, 1);

                else e.Handled = true;
            }
        }
        
        private void TextBoxInputLine_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (e.Text.Length == 0)
            {
                e.Handled = true;
                return;
            }
            if (TextBlockCurrentLine.Text.Length==1)
            {
                ReadNextLine();
                e.Handled = true;
                TextBoxInputLine.Text = String.Empty;
            }      
            else  if (e.Text[0] != TextHelper.GetSymbol(TextBlockCurrentLine.Text[0]))
            {
                e.Handled = true;
            }
            else
            {
                TextBlockCurrentLine.Text = TextBlockCurrentLine.Text.Remove(0, 1);
                e.Handled = false;
            }
        }

        private void ReadNextLine()
        {
           
            if (_Reader != null && _Reader.BaseStream.Length > 0)
            {
                do
                {
                    TextBlockAllText.Text += _Cline+"\n";
                    if (_Reader.EndOfStream)
                    {
                        EndGame();
                        MessageBox.Show($"Ввод окончен\n Время ввода: " +
                            $"{ _GameTime.Minutes} Мин " +
                            $"{ _GameTime.Seconds} Сек " +
                            $"{ _GameTime.Milliseconds} Мс");
                        break;
                    }
                    else
                    {
                        _Cline = _Reader.ReadLine().Trim();
                        TextBlockCurrentLine.Text = _Cline;
                    }
                }
                while (_Cline.Length == 0 || _Cline[0] == '\r');

            }
            else
            {
                throw new Exception("Ошибка чтения файла");
            }
        }
      
        private void ButtonPauseResume_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            if(IsPaused)
                ResumeGame();
            else PauseGame();

        }
    }
}

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
    /// Логика взаимодействия для SettingsView.xaml
    /// </summary>
    public partial class SettingsView : UserControl, ICloseControl
    {
        public SettingsView()
        {
            InitializeComponent();
            SliderVolume.Value = Settings.Instance.Volume;
        }
        
        public event GoBack GoBackEvent;

        public void Load()
        {  
            ListViewAudios.Items.Clear();
            
            foreach(var file in new DirectoryInfo(Settings.Instance.AudiosPath).GetFiles("*.mp3"))
                ListViewAudios.Items.Add(file);
        }

       
        private void ButtonAudioDisable_Click(object sender, RoutedEventArgs e) => AudioPlayer.Stop();
        

        private void ButtonBack_Click(object sender, RoutedEventArgs e)
        {
            if (GoBackEvent != null)
                GoBackEvent.Invoke();
        }


        private void ButtonAudioSelect_Click(object sender, RoutedEventArgs e)
        {

            FileInfo file = (sender as Button).DataContext as FileInfo;
            if (file != null)
            {
                AudioPlayer.SetAudio(file);
                AudioPlayer.Play();
                AudioPlayer.SetVolume(Settings.Instance.Volume);
            }
        }

        private void SliderVolume_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            Settings.Instance.Volume = e.NewValue;
            LabelVolume.Content = $"Громкость: {(int)(e.NewValue*100)}%";   
        }
        
        
    }
}

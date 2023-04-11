using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
namespace Typer
{
    public  class Settings
    {
        private static Settings _Settings;

        private  double _Volume = 1;
        
        public delegate void VolumeChanged (double volume);
        public  event VolumeChanged VolumeChangedEvent;

        public static Settings Instance
        {
            get => _Settings is null ? _Settings = new Settings() : _Settings;
            private set => _Settings = value; 
           
        }
        public  double Volume 
        { 
            get => _Volume; 
            set 
            { 
                _Volume = value;
                if (VolumeChangedEvent != null)
                    VolumeChangedEvent?.Invoke(_Volume);
            } 
        }

        public  string DataGamePath { get; set; } 
        public  string EasyGamePath { get; set; } 
        public  string NormanlGamePath { get; set; } 
        public  string HardGamePath { get; set; } 
        public  string AudiosPath { get; set; } 
        public  string StandartAudio { get; set; }

        private Settings()
        {
            DefaultSettings();
        }

        public void Save()
        {
            XmlSerializer ser = new XmlSerializer(typeof(Settings));
            TextWriter writer = new StreamWriter("Settings.cfg");
            ser.Serialize(writer, Instance);
        }
        public void Load()
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(Settings));
            TextReader reader = new StreamReader("Settings.cfg");
            Instance = (Settings)xmlSerializer.Deserialize(reader);
        }
        public void DefaultSettings()
        {
            DataGamePath = "Data";
            EasyGamePath = DataGamePath + "\\Easy";
            NormanlGamePath = DataGamePath + "\\Normal";
            HardGamePath = DataGamePath + "\\Hard";
            AudiosPath = DataGamePath + "\\Audios";
            StandartAudio = AppDomain.CurrentDomain.BaseDirectory + "\\" + AudiosPath + "\\Standart.mp3";
        }  
    }
}

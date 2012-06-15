 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Xml;
using System.Xml.Linq;

namespace Monitor2
{
    public class UIStyle : INotifyPropertyChanged 
    {
        private string _genStyleBaseColor;
        private string _genStyleColor1;
        private string _genStyleColor2;
        private string _genStyleColor3;
        private string _genStyleColor4;

        private string _loadBarStyleVeryLow;
        private string _loadBarStyleLow;
        private string _loadBarStyleMed;
        private string _loadBarStyleHigh;
        private string _loadBarStyleVeryHigh;

        public string GenStyleBaseColor
        {
            get { return _genStyleBaseColor; }
            set
            {
                _genStyleBaseColor = value;
                OnPropertyChanged("GenStyleBaseColor");
            }
        }

        public string GenStyleColor1
        {
            get { return _genStyleColor1; }
            set
            {
                _genStyleColor1 = value;
                OnPropertyChanged("GenStyleColor1");
            }
        }

        public string GenStyleColor2
        {
            get { return _genStyleColor2; }
            set
            {
                _genStyleColor2 = value;
                OnPropertyChanged("GenStyleColor2");
            }
        }

        public string GenStyleColor3
        {
            get { return _genStyleColor3; }
            set
            {
                _genStyleColor3 = value;
                OnPropertyChanged("GenStyleColor3");
            }
        }

        public string GenStyleColor4
        {
            get { return _genStyleColor4; }
            set
            {
                _genStyleColor4 = value;
                OnPropertyChanged("GenStyleColor4");
            }
        }

        public string LoadBarStyleVeryLow
        {
            get { return _loadBarStyleVeryLow; }
            set
            {
                _loadBarStyleVeryLow = value;
                OnPropertyChanged("LoadBarStyleVeryLow");
            }
        }

        public string LoadBarStyleLow
        {
            get { return _loadBarStyleLow; }
            set
            {
                _loadBarStyleLow = value;
                OnPropertyChanged("LoadBarStyleLow");
            }
        }

        public string LoadBarStyleMed
        {
            get { return _loadBarStyleMed; }
            set
            {
                _loadBarStyleMed = value;
                OnPropertyChanged("LoadBarStyleMed");
            }
        }

        public string LoadBarStyleHigh
        {
            get { return _loadBarStyleHigh; }
            set
            {
                _loadBarStyleHigh = value;
                OnPropertyChanged("LoadBarStyleHigh");
            }
        }

        public string LoadBarStyleVeryHigh
        {
            get { return _loadBarStyleVeryHigh; }
            set
            {
                _loadBarStyleVeryHigh = value;
                OnPropertyChanged("LoadBarStyleVeryHigh");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));

        }

        public static UIStyle Style;

        public UIStyle()
        {
            _genStyleBaseColor = "#ffffff";
            _genStyleColor1 = "#000000";
            _genStyleColor2 = "#ffffff";
            _genStyleColor3 = "#000000";
            _genStyleColor4 = "#ffffff";
            _loadBarStyleVeryLow = "#33ff00";
            _loadBarStyleLow = "#33ff00";
            _loadBarStyleMed = "#ffdd00";
            _loadBarStyleHigh = "#ff0000";
            _loadBarStyleVeryHigh = "#ff0000";

            Style = this;
        }
    }
}

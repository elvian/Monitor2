using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Monitor2
{
    public class SystemInfo : INotifyPropertyChanged
    {
        private int _cpuLoad;
        private int _memLoadPerc;
        private int _memTot;
        private int _memFree;
        private int _memLoad;

        public int CpuLoad
        {
            get { return _cpuLoad; }
            set
            {
                _cpuLoad = value;
                OnPropertyChanged("CpuLoad");
            }
        }

        public int MemLoadPerc
        {
            get { return ((int)Math.Round((double)MemLoad * 100 / MemTot, 0)); }
            set
            {
                _memLoadPerc = value;
                OnPropertyChanged("MemLoadPerc");
            }
        }

        public int MemTot
        {
            get { return _memTot; }
            set
            {
                _memTot = value;
                OnPropertyChanged("MemTot");
                OnPropertyChanged("MemLoadPerc");
            }
        }

        public int MemFree
        {
            get { return _memFree; }
            set
            {
                _memFree = value;
                OnPropertyChanged("MemFree");
                OnPropertyChanged("MemLoadPerc");
            }
        }

        public int MemLoad
        {
            get { return MemTot - MemFree; }
            set
            {
                _memLoad = value;
                OnPropertyChanged("MemLoad");
                OnPropertyChanged("MemLoadPerc");
            }
        }

        public SystemInfo()
        {
            CpuLoad = 0;
            MemFree = 1;
            MemTot = 2;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));

        }
    }
}
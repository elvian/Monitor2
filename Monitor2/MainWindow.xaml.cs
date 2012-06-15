using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Configuration;

namespace Monitor2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public SystemInfo SystemInfo { get; private set; }
        public UIStyle UIStyle { get; set; }

        private RessourcePooler _pooler;
        private Thread _poolerThread;

        public bool IsPoolerStarted { get; private set; }

        public int GetCpuLoad
        {
            get { return SystemInfo.CpuLoad; }
        }

        public MainWindow()
        {
            if (!StartPooler())
            {
                IsPoolerStarted = false;
            }

            ConfigurationLoader configLoader = new ConfigurationLoader();

            UIStyle = configLoader.LoadUIConfiguration(ConfigurationManager.AppSettings["Style"]);

            InitializeComponent();
        }

        bool StartPooler()
        {
            try
            {
                if (_pooler == null)
                    _pooler = new RessourcePooler();

                if (SystemInfo == null)
                    SystemInfo = new SystemInfo();

                if (_poolerThread == null)
                    _poolerThread = new Thread(new ParameterizedThreadStart(_pooler.PoolerMain));

                _poolerThread.Start(SystemInfo);

                while (!_poolerThread.IsAlive) ;

                IsPoolerStarted = true;

                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return false;
            }
        }

        bool StopPooler()
        {
            if (_poolerThread == null)
                return false;

            _poolerThread.Abort();
            _poolerThread.Join();

            IsPoolerStarted = false;
            return true;
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            StopPooler();
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            StopPooler();
        }

    }
}

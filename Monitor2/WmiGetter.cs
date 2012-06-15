using System;
using System.Management;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Monitor2
{
    public class WmiGetter
    {
        private ManagementObjectSearcher _cpuSearcher;
        private ManagementObjectSearcher _memSearcher;

        public WmiGetter()
        {
            _cpuSearcher = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_Processor");
            _memSearcher = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_OperatingSystem");
        }

        public int GetCpuLoad()
        {
            int cpuTot = 0, cpuNb = 0;

            foreach (ManagementObject queryObj in _cpuSearcher.Get())
            {
                if (queryObj["LoadPercentage"] != null && queryObj["LoadPercentage"] != "")
                {
                    int cpuLoad;
                    if (int.TryParse(queryObj["LoadPercentage"].ToString(), out cpuLoad))
                    {
                        cpuTot += cpuLoad;
                        cpuNb++;
                    }
                }
            }

            if (cpuNb > 0)
                return (int)Math.Round((double)cpuTot / cpuNb, 0);
            else
                return 0;
        }

        public int GetTotMem()
        {
            ManagementObjectCollection.ManagementObjectEnumerator manEnum = _memSearcher.Get().GetEnumerator();
            manEnum.MoveNext();

            int memTot;
            int.TryParse(manEnum.Current["TotalVisibleMemorySize"].ToString(), out memTot);

            return ((int)Math.Round((double)memTot / 1024, 0));
        }

        public int GetAvailableMem()
        {
            ManagementObjectCollection.ManagementObjectEnumerator manEnum = _memSearcher.Get().GetEnumerator();
            manEnum.MoveNext();

            int freeMem;
            int.TryParse(manEnum.Current["FreePhysicalMemory"].ToString(), out freeMem);

            return ((int)Math.Round((double)freeMem / 1024, 0));
        }

    }
}
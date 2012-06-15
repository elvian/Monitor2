using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace Monitor2
{
    class RessourcePooler
    {
        private SystemInfo _systemInfo;
        private WmiGetter _wmiGetter;

        public void PoolerMain(object systemInfo)
        {
            _systemInfo = (SystemInfo)systemInfo;
            _wmiGetter = new WmiGetter();

            _systemInfo.MemTot = _wmiGetter.GetTotMem();

            while (true)
            {
                _systemInfo.CpuLoad = _wmiGetter.GetCpuLoad();
                _systemInfo.MemFree = _wmiGetter.GetAvailableMem();

                Thread.Sleep(500);
            }
        }

    }
}

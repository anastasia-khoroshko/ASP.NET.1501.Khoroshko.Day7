using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Task1
{
    public class TimeManager
    {
        public delegate void TimeOverEventHandler(object sender, TimeIsOverEventArgs e);
        public event TimeOverEventHandler TimeOver;
        protected virtual void OnTimeOver(TimeIsOverEventArgs e)
        {
            TimeOverEventHandler temp = TimeOver;
            if (temp != null) temp(this, e);
        }

        public void SimulateClock(int time)
        {
            TimeIsOverEventArgs e = new TimeIsOverEventArgs(time);
            Thread.Sleep(time);
            OnTimeOver(e);
        }

    }

    
}

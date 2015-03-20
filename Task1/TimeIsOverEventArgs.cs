using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    public class TimeIsOverEventArgs :EventArgs
    {
        private readonly string msgTime;
        public TimeIsOverEventArgs(int time)
        {
            msgTime = String.Format("{0} minutes is over!", time);
        }

        public string MsgTime { get { return msgTime; } }
    }
}

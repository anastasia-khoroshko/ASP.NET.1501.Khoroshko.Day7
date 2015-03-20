using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    public sealed class TimerOvenBread
    {
        public TimerOvenBread() { }
        public TimerOvenBread(TimeManager tm)
        {
            tm.TimeOver += OvenBreadMsg;
        }
        public void Register(TimeManager tm)
        {
            tm.TimeOver += OvenBreadMsg;
        }
        private void OvenBreadMsg(object sender, TimeIsOverEventArgs e)
        {
            Console.WriteLine(string.Format("{0}Bread is cooked.",e.MsgTime));
        }

        public void Unregister(TimeManager tm)
        {
            tm.TimeOver -= OvenBreadMsg;
        }
    }
}

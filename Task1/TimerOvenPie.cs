using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    public sealed class TimerOvenPie
    {
        public TimerOvenPie() { }
        public TimerOvenPie(TimeManager tm)
        {
            tm.TimeOver += OvenPieMsg;
        }
        public void Register(TimeManager tm)
        {
            tm.TimeOver += OvenPieMsg;
        }
        private void OvenPieMsg(object sender, TimeIsOverEventArgs e)
        {
            Console.WriteLine(string.Format("{0}Pie is cooked.", e.MsgTime));
        }
        public void Unregister(TimeManager tm)
        {
            tm.TimeOver -= OvenPieMsg;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    public sealed class TimerOvenChicken
    {
        public TimerOvenChicken() { }
        public TimerOvenChicken(TimeManager tm)
        {
            tm.TimeOver += OvenChickenMsg;
        }
        public void Register(TimeManager tm)
        {
            tm.TimeOver += OvenChickenMsg;
        }
        private void OvenChickenMsg(object sender, TimeIsOverEventArgs e)
        {
            Console.WriteLine(string.Format("{0} Chicken is cooked.", e.MsgTime));
        }
        public void Unregister(TimeManager tm)
        {
            tm.TimeOver -= OvenChickenMsg;
        }
    }
}

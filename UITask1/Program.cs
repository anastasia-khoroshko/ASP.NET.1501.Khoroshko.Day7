using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task1;

namespace UITask1
{
    class Program
    {
        static void Main(string[] args)
        {
            int time=0,time1=0;
           
            do
            {
                Console.WriteLine("Enter timer:");
                try
                {
                    time = Convert.ToInt32(Console.ReadLine());
                }
                catch (FormatException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            } while (time == 0);
            
            var manager =new TimeManager();
            var chickenTimer = new TimerOvenChicken(manager);
            var pieTimer = new TimerOvenPie(manager);
            var breadTimer = new TimerOvenBread();
            breadTimer.Register(manager);
            manager.SimulateClock(time);           
            pieTimer.Unregister(manager);
            do
            {
                Console.WriteLine("Enter timer:");
                try
                {
                    time1 = Convert.ToInt32(Console.ReadLine());
                }
                catch (FormatException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            } while (time1 == 0);
            manager.SimulateClock(time1);
            Console.ReadLine();
        }
    }
}

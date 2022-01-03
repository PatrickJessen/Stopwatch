using Stopwatch.Logic;
using Stopwatch.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace Stopwatch.Commands
{
    public class StopwatchCommand : CommandBase
    {
        private MyTimer timer;
        private Thread t;

        public StopwatchCommand(MyTimer timer)
        {
            this.timer = timer;
        }

        // Starts the timer if the timer is not running, and stops the timer if it is running.
        public override void Execute(object parameter)
        {
            if (timer.StopWatch.StartBtn == "Start")
            {
                t = new Thread(timer.Start);
                timer.StopWatch.StartBtn = "Stop";
                t.Start();
            }
            else
            {
                timer.Stop();
                t.Join();
                timer.StopWatch.StartBtn = "Start";
                timer.StopWatch.TimeLeft = "Time left: " + timer.CalculateTimeLeft() + " seconds";
            }
        }
    }
}

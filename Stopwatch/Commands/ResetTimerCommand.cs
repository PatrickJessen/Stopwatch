using Stopwatch.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stopwatch.Commands
{
    class ResetTimerCommand : CommandBase
    {
        private MyTimer timer;

        public ResetTimerCommand(MyTimer timer)
        {
            this.timer = timer;
        }
        // Resets the timer when the Reset button is clicked.
        public override void Execute(object parameter)
        {
            timer.CurrentCount = 0;
            timer.StopWatch.Timer = "0";
        }
    }
}

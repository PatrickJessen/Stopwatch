using Stopwatch.Commands;
using Stopwatch.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Stopwatch.ViewModels
{
    public class StopWatchViewModel : ViewModelBase
    {
        private string startBtn;
        public string StartBtn
        {
            get
            {
                return startBtn;
            }
            set
            {
                startBtn = value;
                OnPropertyChanged(nameof(startBtn));
            }
        }

        private string timer;
        public string Timer
        {
            get
            {
                return timer;
            }
            set
            {
                timer = value;
                OnPropertyChanged(nameof(timer));
            }
        }

        private string setTimer;
        public string SetTimer
        {
            get
            {
                return setTimer;
            }
            set
            {
                setTimer = value;
                OnPropertyChanged(nameof(setTimer));
            }
        }

        private string timeLeft;
        public string TimeLeft
        {
            get
            {
                return timeLeft;
            }
            set
            {
                timeLeft = value;
                OnPropertyChanged(nameof(timeLeft));
            }
        }
        public ICommand StopWatchCommand { get; }
        public ICommand ResetCommand { get; }

        public StopWatchViewModel()
        {
            StartBtn = "Start";
            Timer = 0.ToString();
            TimeLeft = "Time left: ";
            MyTimer timer = new MyTimer(this);
            StopWatchCommand = new StopwatchCommand(timer);
            ResetCommand = new ResetTimerCommand(timer);
        }

    }
}

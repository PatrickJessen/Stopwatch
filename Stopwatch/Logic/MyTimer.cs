using Stopwatch.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Stopwatch.Logic
{
    public class MyTimer
    {
        // Current count that updates each second.
        public int CurrentCount { get; set; }
        // Max count the CurrentCount goes up to.
        public int MaxCount { get; set; }
        // To Check if the timer has started or not.
        public bool IsStarted { get; set; }
        public StopWatchViewModel StopWatch { get; }

        private string Sound = "Honk.wav";
        SoundPlayer player;

        public MyTimer(StopWatchViewModel stopWatch)
        {
            this.StopWatch = stopWatch;
            player = new SoundPlayer("Assets/" + Sound);
        }

        private void Init()
        {
            IsStarted = true;
            SetMaxCount();
            StopWatch.Timer = CurrentCount.ToString();
        }

        // Starts the timer.
        public void Start()
        {
            Init();
            while (IsStarted && CurrentCount != MaxCount)
            {
                CurrentCount++;
                StopWatch.Timer = CurrentCount.ToString();
                Thread.Sleep(1000);
            }
            StopWatch.StartBtn = "Start";
            PlayHonkSound();
        }
        
        // Stops the timer.
        public void Stop()
        {
            IsStarted = false;
        }

        // Calculates the time left.
        public int CalculateTimeLeft()
        {
            return MaxCount - CurrentCount;
        }

        // To check if the user has put numbers into the textbox and not strings. (shouldnt be done in here)
        private void SetMaxCount()
        {
            int x;
            if (int.TryParse(StopWatch.SetTimer, out x))
                MaxCount = int.Parse(StopWatch.SetTimer);
        }

        // Plays the honk sound
        private void PlayHonkSound()
        {
            if (CurrentCount == MaxCount)
                player.Play();
        }
    }
}

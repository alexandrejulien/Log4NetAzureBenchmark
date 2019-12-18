using System;

namespace Peppermint.Log4Net.Azure.Benchmark.Core
{
    /// <summary>
    /// A simple timer class.
    /// </summary>
    public class Timer
    {
        /// <summary>
        /// Start timer.
        /// </summary>
        public void Start() => _startTime = DateTime.Now;

        /// <summary>
        /// Stop timer.
        /// </summary>
        public void Stop() => _endTime = DateTime.Now;
        
        /// <summary>
        /// Timer render in milliseconds.
        /// </summary>
        /// <returns>The message with time elapsed.</returns>
        public override string ToString() => String.Format(
            TimerMessageCanvas, _message, CalculateTiming().TotalMilliseconds);
        
        /// <summary>
        /// Start time.
        /// </summary>
        private DateTime _startTime;

        /// <summary>
        /// End time.
        /// </summary>
        private DateTime _endTime;

        /// <summary>
        /// Output message.
        /// </summary>
        private string _message;
        
        /// <summary>
        /// Canvas for output message.
        /// </summary>
        private const string TimerMessageCanvas = "Timer {0} : {1} ms";

        /// <summary>
        /// Default constructor.
        /// </summary>
        /// <param name="message">Message entry.</param>
        public Timer(string message) => this._message = message;


        /// <summary>
        /// Time interval calculation.
        /// </summary>
        /// <returns>The elapsed time.</returns>
        private TimeSpan CalculateTiming() => _endTime - _startTime;
        
    }
}
using System;
using System.Linq;
using System.Text;

namespace Peppermint.Log4Net.Azure.Benchmark.Core
{
    /// <summary>
    /// Uses cases samples of logging.
    /// Cases for exceptions, massive log entries.
    /// </summary>
    public class LogSamples
    {
        /// <summary>
        /// Results string builder.
        /// </summary>
        private StringBuilder _results = new StringBuilder();
        
        /// <summary>
        /// Launch mass exception logs.
        /// </summary>
        /// <exception cref="Exception">Sample exception.</exception>
        public void MassivesExceptions(Int32 loops)
        {
            var timer = new Timer("Test massives exceptions");
            
            timer.Start();
            for (var i=0; i <= loops; i++)
            {
                try
                {
                    throw new Exception(
                        string.Format("This is a error sample, error number {0}", i));
                }
                catch (Exception ex)
                {
                    Logger.Current.Error(ex.Message);
                }
            }
            timer.Stop();

            _results.Append(timer.ToString());
        }

        /// <summary>
        /// Getter for results formated.
        /// </summary>
        /// <returns>The results for output.</returns>
        public string GetResults() => _results.ToString();

    }
}
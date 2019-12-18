using System;
using System.Collections.Generic;
using Peppermint.Log4Net.Azure.Benchmark.Core;

namespace Peppermint.Log4Net.Azure.Benchmark
{
    /// <summary>
    /// Main program.
    /// </summary>
    class Program
    {
        /// <summary>
        /// Program launcher.
        /// </summary>
        /// <param name="args">Arguments.</param>
        static void Main(string[] args)
        {
            Logger.SetLog4NetConfiguration();
            
            print(("Benchmark for Logging on Azure"));
            print("This test will benchmark Log4Net with filesystem, Azure blob, Azure table");

            LaunchSeries();

            ExitMessage();
            PressAnyKey();
        }
        
        /// <summary>
        /// Loops for testing series.
        /// </summary>
        private static void LaunchSeries()
        {
            for (var i = 0; i < LoopsSuites.Count; i++)
            {
                var samples = new LogSamples();
                samples.MassivesExceptions(LoopsSuites[i]);
                print(samples.GetResults());
            }
        }
        
        #region "Private methods"
        /// <summary>
        /// Raccouci.
        /// </summary>
        /// <param name="message">text.</param>
        private static void print(string message) => Console.WriteLine(message);

        /// <summary>
        /// Exit end message.
        /// </summary>
        private static void ExitMessage() => print("Press any key to exit ...");

        /// <summary>
        /// ReadKey.
        /// </summary>
        private static void PressAnyKey() => Console.ReadKey();

        /// <summary>
        /// Suites de tests pour les boucles.
        /// </summary>
        private static List<Int32> LoopsSuites => new List<Int32>()
        {
            1, 100, 1000, 10000, 100000
        };
        #endregion
    }
}
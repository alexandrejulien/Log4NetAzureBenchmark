using System;
using NUnit.Framework;
using Peppermint.Log4Net.Azure.Benchmark.Core;

namespace Tests
{
    /// <summary>
    /// Units tests on samples.
    /// </summary>
    public class SamplesTests
    {
        private LogSamples _samples;

        /// <summary>
        /// Setup logger instance.
        /// </summary>
        [SetUp]
        public void Setup()
        {
            Logger.SetLog4NetConfiguration();
            _samples = new LogSamples();
        } 
        
        /// <summary>
        /// A simple log test.
        /// </summary>
        [Test]
        public void Log()
        {
            Logger.SetLog4NetConfiguration();
            try
            {
                _samples.MassivesExceptions(10);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
            Assert.Pass("Massive exceptions tests success");
            Assert.Pass(_samples.GetResults());
        }
    }
}
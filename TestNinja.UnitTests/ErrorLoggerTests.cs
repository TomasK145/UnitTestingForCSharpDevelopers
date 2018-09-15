using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestNinja.Fundamentals;

namespace TestNinja.UnitTests
{
    [TestFixture]
    public class ErrorLoggerTests
    {
        [Test]
        public void Log_WhenCalled_SetLastErrorProperty()
        {
            var logger = new ErrorLogger();

            logger.Log("a"); //metoda nevracia ziadnu hodnotu ale nastavuje property v danom objekte
            //preto otestujeme nastavenie tejto property

            Assert.That(logger.LastError, Is.EqualTo("a"));
        }
    }
}

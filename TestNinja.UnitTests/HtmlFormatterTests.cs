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
    class HtmlFormatterTests
    {
        [Test]
        public void FormatAsBold_WhenCalled_ShouldEncloseTheStringWithStrongElement()
        {
            var formatter = new HtmlFormatter();

            var result = formatter.FormatAsBold("abc");

            //Specific 
            Assert.That(result, Is.EqualTo("<string>abc</strong>").IgnoreCase); //vhodne ak chceme overit presny vystup z metody (pozor na zmeny vystupu testovanej metody)
            //je mozne pridat metodu "IgnoreCase" pre ignorovanie malych/velkych pismen

            //more generic
            Assert.That(result, Does.StartWith("<strong>"));
            Assert.That(result, Does.EndWith("</strong>"));
            Assert.That(result, Does.Contain("abc"));

        }
    }
}

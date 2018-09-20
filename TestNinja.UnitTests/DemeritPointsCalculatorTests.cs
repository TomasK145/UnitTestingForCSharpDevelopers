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
    public class DemeritPointsCalculatorTests
    {
        [Test]
        public void CalculateDemeritPoints_SpeedIsLessThanZero_ThrowExceptionArgumentOutOfRange()
        {
            var demeritPointsCalculator = new DemeritPointsCalculator();

            Assert.That(() => demeritPointsCalculator.CalculateDemeritPoints(-1), Throws.Exception.TypeOf<ArgumentOutOfRangeException>());
        }

        [Test]
        public void CalculateDemeritPoints_SpeedIsZeroReturnZero()
        {
            var demeritPointsCalculator = new DemeritPointsCalculator();

            var result = demeritPointsCalculator.CalculateDemeritPoints(0);

            Assert.That(result, Is.EqualTo(0));
        }

        [Test]
        public void CalculateDemeritPoints_SpeedIsLessThanSpeedLimit_ReturnZero()
        {
            var demeritPointsCalculator = new DemeritPointsCalculator();

            var result = demeritPointsCalculator.CalculateDemeritPoints(1);

            Assert.That(result, Is.EqualTo(0));
        }

        [Test]
        public void CalculateDemeritPoints_SpeedIsEqualToSpeedLimit_ReturnZero()
        {
            var demeritPointsCalculator = new DemeritPointsCalculator();

            var result = demeritPointsCalculator.CalculateDemeritPoints(65);

            Assert.That(result, Is.EqualTo(0));
        }

        [Test]
        [TestCase(0,0)]
        [TestCase(64,0)]
        [TestCase(65,0)]
        [TestCase(66, 0)]
        [TestCase(70, 1)]
        [TestCase(300, 47)]
        public void CalculateDemeritPoints_WhenCalled_ReturnDemeritPoints(int speed, int expectedResult)
        {
            var demeritPointsCalculator = new DemeritPointsCalculator();

            var result = demeritPointsCalculator.CalculateDemeritPoints(speed);

            Assert.That(result, Is.EqualTo(expectedResult));
        }

        [Test]
        [TestCase(-1)]
        [TestCase(301)]
        public void CalculateDemeritPoints_SpeedIsOutOfRange_ThrowsException(int speed)
        {
            var demeritPointsCalculator = new DemeritPointsCalculator();

            Assert.That(() => demeritPointsCalculator.CalculateDemeritPoints(speed), Throws.Exception.TypeOf<ArgumentOutOfRangeException>());
        }

        [Test]
        public void CalculateDemeritPoints_SpeedIsHigherThanSpeedLimit_ReturnDemeritPointsSpeedDifOverFive()
        {
            var demeritPointsCalculator = new DemeritPointsCalculator();

            var result = demeritPointsCalculator.CalculateDemeritPoints(70);

            Assert.That(result, Is.EqualTo(1));
        }

        [Test]
        public void CalculateDemeritPoints_SpeedIsOutRange_ThrowExceptionArgumentOutOfRange()
        {
            var demeritPointsCalculator = new DemeritPointsCalculator();

            Assert.That(() => demeritPointsCalculator.CalculateDemeritPoints(301), Throws.Exception.TypeOf<ArgumentOutOfRangeException>());
        }
    }
}

using NUnit.Framework;
using TestNinja.Fundamentals;

namespace TestNinja.UnitTests.Fundamentals
{
    [TestFixture]
    internal class FizzBuzzTests
    {
        [Test]
        [TestCase(1, "1")]
        [TestCase(3, "Fizz")]
        [TestCase(-3, "Fizz")]
        [TestCase(5, "Buzz")]
        [TestCase(15, "FizzBuzz")]
        [TestCase(0, "FizzBuzz")]
        [TestCase(null, "FizzBuzz")]
        public void GetOutput_WhenCalled_ReturnsCorrectFizzBuzzString(int number, string expectedResult)
        {
            var result = FizzBuzz.GetOutput(number);

            Assert.That(result, Is.EqualTo(expectedResult));
        }
    }
}

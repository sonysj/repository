using NUnit.Framework;
using EllipseStruct;
using System;

namespace EllipseStruct.UnitTests
{
    [TestFixture]
    public class EllipseTests
    {
        [Test]
        public void ConstructorTest()
        {
            var ellipse = new Ellipse(6.2, 3.21);
            Assert.That(ellipse.A, Is.EqualTo(6.2));
            Assert.That(ellipse.B, Is.EqualTo(3.21));
        }

        [TestCase(0)]
        [TestCase(-1.5)]
        public void A_SetNegativeOrZeroValue_ArgumentException(double val)
        {
            var ellipse = new Ellipse();
            Assert.That(() => ellipse.A = val, Throws.ArgumentException);
        }

        [TestCase(0)]
        [TestCase(-2.99)]
        public void B_SetNegativeOrZeroValue_ArgumentException(double val)
        {
            var ellipse = new Ellipse();
            Assert.That(() => ellipse.B = val, Throws.ArgumentException);
        }

        [TestCase(5.0, 3.0, 0.8)]                    
        [TestCase(3.0, 5.0, 0.8)]                    
        [TestCase(6.2, 3.21, 0.8555368421297912)]    
        [TestCase(3.21, 6.2, 0.8555368421297912)]    
        [TestCase(5.0, 5.0, 0.0)]                    
        public void E_Test(double a, double b, double expected)
        {
            var ellipse = new Ellipse(a, b);
            Assert.That(ellipse.E, Is.EqualTo(expected).Within(1e-13));
        }

        [TestCase(6.2, 3.21, 62.523976991744064)]   
        [TestCase(5.0, 5.0, 78.53981633974483)]    
        public void Area_Test(double a, double b, double expected)
        {
            var ellipse = new Ellipse(a, b);
            Assert.That(ellipse.Area, Is.EqualTo(expected).Within(1e-13));
        }

        [TestCase(6.2, 3.21, "Эллипс с полуосями a = 6.2 и b = 3.21")]
        [TestCase(5.0, 5.0, "Эллипс с полуосями a = 5 и b = 5")]
        public void ToString_Test(double a, double b, string expected)
        {
            var ellipse = new Ellipse(a, b);
            Assert.That(ellipse.ToString(), Is.EqualTo(expected));
        }

        [TestCase(6.2, 3.21, 6.2, 3.21, true)]
        [TestCase(6.2, 3.21, 6.2000000000001, 3.2099999999999, true)]
        [TestCase(6.2, 3.21, 3.21, 6.2, false)]
        public void Equals_TwoEllipses_ExpectedResult(
            double a1, double b1, double a2, double b2, bool expected)
        {
            var ellipse1 = new Ellipse(a1, b1);
            var ellipse2 = new Ellipse(a2, b2);
            Assert.That(ellipse1.Equals(ellipse2), Is.EqualTo(expected));
        }

        [Test]
        public void Equals_WrongArgument_ArgumentException()
        {
            var ellipse = new Ellipse();
            var obj = new object();
            Assert.That(() => ellipse.Equals(obj), Throws.ArgumentException);
        }

        [Test]
        public void GetHashCode_Test()
        {
            var x = new Ellipse(6.2, 3.21);
            var y = new Ellipse(6.2, 3.21);
            var z = new Ellipse(3.21, 6.2);
            Assert.That(x.GetHashCode(), Is.EqualTo(y.GetHashCode()));
            Assert.That(x.GetHashCode(), Is.Not.EqualTo(z.GetHashCode()));
        }

        [Test]
        public void Comparison_Test()
        {
            var x = new Ellipse(6.2, 3.21);
            var y = new Ellipse(6.2, 3.21);
            var z = new Ellipse(3.21, 6.2);

            Assert.That(x == y, Is.True);
            Assert.That(x != y, Is.False);
            Assert.That(x == z, Is.False);
            Assert.That(x != z, Is.True);
        }

        [TestCase(2.0, 6.2, 3.21, 12.4, 6.42)]
        [TestCase(0.5, 6.2, 3.21, 3.1, 1.605)]
        public void Multiplication_Test(
            double k, double a, double b, double expectedA, double expectedB)
        {
            var ellipse = new Ellipse(a, b);
            var result = new Ellipse(expectedA, expectedB);

            Assert.That(k * ellipse, Is.EqualTo(result));
            Assert.That(ellipse * k, Is.EqualTo(result));
        }

        [TestCase(0)]
        [TestCase(-1.5)]
        public void Multiplication_NegativeOrZeroCoefficient_ArgumentException(double k)
        {
            var ellipse = new Ellipse(6.2, 3.21);
            Assert.That(() => k * ellipse, Throws.ArgumentException);
            Assert.That(() => ellipse * k, Throws.ArgumentException);
        }
    }
}
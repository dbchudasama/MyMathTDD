using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyMath;

namespace MathTests
{
    [TestClass]
    public class MathUnitTests
    {
        private MathClass _mathClass;

        [TestInitialize]
        public void Setup()
        {
            //ARRANGE
            // Create an instance to test:
            _mathClass = new MathClass();
        }

        [TestMethod]
        public void TestCanInitialiseMathClass()
        {
            Assert.IsInstanceOfType(_mathClass, typeof(MathClass));
        }

        [TestMethod]
        public void TestSquareRootTakesDoubles()
        {
            _mathClass.SquareRoot(4.0d);
        }

        [TestMethod]
        public void TestSquareRootReturnsADouble()
        {
            var actual = _mathClass.SquareRoot(4);
            Assert.IsInstanceOfType(actual, typeof(double));
        }

        //Test case for a static input
        [TestMethod]
        public void BasicSquareRootTest()
        {
            // Define a test input and output value:
            double expectedResult = 2.0;
            double input = expectedResult * expectedResult;

            //ACT
            // Run the method under test:
            double actualResult = _mathClass.SquareRoot(input);

            //ASSERT
            // Verify the result:
            Assert.AreEqual(expectedResult, actualResult, delta: expectedResult / 100);
        }

        //Test case for range of values
        [TestMethod]
        public void SquareRootValueRange()
        {
            //ARRANGE
            // Create an instance to test.
            MathClass mathClass = new MathClass();

            //ACT
            // Try a range of values.
            for (double expected = 1e-8; expected < 1e+8; expected *= 3.2)
            {
                //ARRANGE within method
                SquareRootOneValue(mathClass, expected);
            }
        }

        //Test method for inputting each individual value from a range 
        private void SquareRootOneValue(MathClass mathClass, double expectedResult)
        {
            //ARRANGE
            double input = expectedResult * expectedResult;

            //ACT
            double actualResult = mathClass.SquareRoot(input);

            //ASSERT
            Assert.AreEqual(expectedResult, actualResult, delta: expectedResult / 1000);
        }

        //Test case for negative values
        [TestMethod]
        public void SquareRootTestNegativeInput()
        {
            //ARRANGE
            MathClass mathClass = new MathClass();

            //ACT
            try
            {
                mathClass.SquareRoot(-10);
            }
            catch (System.ArgumentOutOfRangeException)
            {
                return;
            }

            //ASSERT
            //Assert.Fail();

            Assert.ThrowsException<ArgumentOutOfRangeException>(() => mathClass.SquareRoot(-10));
        }

        //Test case for calculating c^2
        [TestMethod]
        public void PythagorasTheoremTest()
        {
            //ARRANGE
            //Create an instance to test
            MathClass mathClass = new MathClass();

            //Define test input and output values
            double a = 3.0;
            double b = 4.0;
            double c = 5.0;

            double expectedResult = c*c;

            //ACT
            double actualResult = mathClass.PythagorasTheorem(a, b);

            //ASSERT
            //Verify the Result
            Assert.AreEqual(expectedResult, actualResult);
        }

        //Test case for one of the sides being of length 0cm 
        [TestMethod]
        public void PythagorasTheoremSideLengthZeroTest()
        {
            //ARRANGE
            //Create an instance to test
            MathClass mathClass = new MathClass();

            //Define test input and output values
            double a = 0.0;
            double b = 4.0;

            try
            {
                //ACT
                mathClass.PythagorasTheorem(a, b);
            }
            catch (System.ArgumentOutOfRangeException)
            {
                return;
            }
            
            //ASSERT
            //Verify the Result
            Assert.Fail();
        }

        //Test case for one of the sides being negative value
        [TestMethod]
        public void PythagorasTheoremSideLengthNegativeTest()
        {
            //ARRANGE
            //Create an instance to test
            MathClass mathClass = new MathClass();

            //Define test input and output values
            double a = -3.0;
            double b = -4.0;
            double c = 5.0;

            double expectedResult = c*c;

            //ACT
            double actualResult = mathClass.PythagorasTheorem(a, b);
            
            //ASSERT
            //Verify the Result
            Assert.AreEqual(expectedResult, actualResult);
        }

        //Test case for one of the sides being negative value
        [TestMethod]
        public void PythagorasTheoremCalculateSideTest()
        {
            //ARRANGE
            //Create an instance to test
            MathClass mathClass = new MathClass();

            //Define test input and output values
            double a = 12.0;
            double b = 11.0;
            double expectedResult = mathClass.SquareRoot(a * a + b * b);

            //ACT
            double actualResult = mathClass.PythagorasTheoremCalculateSide(a, b);
            
            //ASSERT
            //Verify the Result
            Assert.AreEqual(expectedResult, actualResult);
        }

        //Test case for one of the sides being of length 0cm 
        [TestMethod]
        public void PythagorasTheoremCalculateSideLengthZero()
        {
            //ARRANGE
            //Create an instance to test
            MathClass mathClass = new MathClass();

            //Define test input and output values
            double a = 0.0;
            double b = 6.0;

            try
            {
                //ACT
                mathClass.PythagorasTheoremCalculateSide(a, b);
            }
            catch (System.ArgumentOutOfRangeException)
            {
                return;
            }
            
            //ASSERT
            //Verify the Result
            Assert.Fail();
        }

        
        //Test case for one of the sides being negative value
        [TestMethod]
        public void PythagorasTheoremCalculateSideNegativeValue()
        {
            //ARRANGE
            //Create an instance to test
            MathClass mathClass = new MathClass();

            //Define test input and output values
            double a = -2.0;
            double b = -4.0;
            double expectedResult = mathClass.SquareRoot(a * a + b * b);

            //ACT
            double actualResult = mathClass.PythagorasTheoremCalculateSide(a, b);
            
            //ASSERT
            //Verify the Result
            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}

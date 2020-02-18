using System;

namespace MyMath
{
    
    public class MathClass
    {
        //Method for calculating the Square Root of a number
        public double SquareRoot(double input)
        {
            //Exception logic for negative value input
            if (input <= 0.0)
            {
                throw new ArgumentOutOfRangeException();
            }

            double result = input;
            double previousResult = -input;
            while (Math.Abs(previousResult - result) > result / 1000)
            {
                previousResult = result;
                result = (result + input / result) / 2;
                //was: result = result - (result * result - input) / (2*result);
            }
            return result;
        }

        //Method for calculating one side of a triangle using Pythagoras' Theorem
        public double PythagorasTheorem(double a, double b)
        {
            switch (a)
            {
             case 0:
                 throw new ArgumentOutOfRangeException();
            }

            switch (b)
            {
                case 0:
                    throw new ArgumentOutOfRangeException();
            }

            return a * a + b * b;
        }

        //Method to calculate length of one side using Pythagoras' theorem
        public double PythagorasTheoremCalculateSide(double a, double b)
        {
            var summedValue = a * a + b * b;

            switch (a)
            {
                case 0:
                    throw new ArgumentOutOfRangeException();

            }

            switch (b)
            {
                case 0:
                    throw new ArgumentOutOfRangeException();
            }

            return SquareRoot(summedValue);
        }
    }
}

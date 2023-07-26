using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPNCalculator
{
    internal class Subtraction : MathOperation
    {
        public Subtraction() { }
        public double evaluate(double firstNumber, double secondNumber)
        {
            return firstNumber - secondNumber;
        }
    }
}

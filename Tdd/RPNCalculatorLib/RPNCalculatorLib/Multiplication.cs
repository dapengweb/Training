using RPNCalculator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPNCalculator
{
    internal class Multiplication : MathOperation
    {
        public Multiplication() { }

        public double evaluate(double firstNumber, double secondNumber)
        {
            return firstNumber * secondNumber;
        }
    }
}

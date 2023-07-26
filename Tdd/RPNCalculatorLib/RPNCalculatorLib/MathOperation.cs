using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPNCalculator
{
    internal interface MathOperation
    {
        double evaluate(double firstNumber, double secondNumber);
    }
}

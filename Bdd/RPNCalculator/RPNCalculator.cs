using System.Reflection.Metadata.Ecma335;

namespace RPNCalculator
{
    public class RPNCalculator
    {
        private Stack<double> numberStack = new Stack<double>();
        private double firstInput = 0;
        private double secondInput = 0;
        private double result = 0;

        public double evaluate(string rpnMathExpression)
        {
            //return 350.0;
            try
            {
                string[] rpnTokens = rpnMathExpression.Split(' ');
                foreach (string rpnToken in rpnTokens)
                {
                    if (rpnToken.Equals("+"))
                    {
                        secondInput = numberStack.Pop();
                        firstInput = numberStack.Pop();
                        result = firstInput + secondInput;
                        numberStack.Push(result);
                    }
                    else if (rpnToken.Equals("-"))
                    {
                        secondInput = numberStack.Pop();
                        firstInput = numberStack.Pop();
                        result = firstInput - secondInput;
                        numberStack.Push(result);
                    }
                    else if (rpnToken.Equals("*"))
                    {
                        secondInput = numberStack.Pop();
                        firstInput = numberStack.Pop();
                        result = firstInput * secondInput;
                        numberStack.Push(result);
                    }
                    else if (rpnToken.Equals("/"))
                    {
                        secondInput = numberStack.Pop();
                        firstInput = numberStack.Pop();
                        result = firstInput / secondInput;
                        numberStack.Push(result);
                    }
                    else
                    {
                        numberStack.Push(double.Parse(rpnToken));
                    }
                }
            }
            catch (Exception e)
            {
                throw new Exception("Invalid RPN Expression");}

            return numberStack.Pop();
        }


    }
}
namespace RPNCalculator
{
    public class RPNCalculator
    {
        private double firstNumber = 0.0;
        private double secondNumber = 0.0;
        private double result = 0.0;

        private Stack<double> numberStack = new Stack<double>();

        private bool isMathOperation( String token )
        {
            String mathOperations = "+-*/";
            return mathOperations.Contains(token);
        }

        public double evaluate(string v)
        {
            String[] rpnTokens = v.Split(" ");
            MathOperation mathOperation = null;

            foreach(String rpnToken in rpnTokens)
            {
                if ( isMathOperation(rpnToken))
                {
                    secondNumber = numberStack.Pop();
                    firstNumber = numberStack.Pop();

                    mathOperation = MathObjectFactory.getMathObject(rpnToken);
                    result = mathOperation.evaluate( firstNumber, secondNumber );
                    numberStack.Push(result);
                }
                else
                    numberStack.Push(Double.Parse(rpnToken));
            }

            return numberStack.Pop();
        }
    }
}

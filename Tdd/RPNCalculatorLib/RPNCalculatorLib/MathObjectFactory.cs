using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace RPNCalculator
{
    internal class MathObjectFactory
    {
        private static Dictionary<String, String> mathOpereratorMap = new Dictionary<String, String>();

        static MathObjectFactory() {
            mathOpereratorMap.Add("+", "RPNCalculator.Addition" );
            mathOpereratorMap.Add("-", "RPNCalculator.Subtraction");
            mathOpereratorMap.Add("*", "RPNCalculator.Multiplication");
            mathOpereratorMap.Add("/", "RPNCalculator.Division");        
        }

        public static MathOperation getMathObject ( String mathOperator )
        {
                MathOperation mathOperation = null;
                string className;
                mathOpereratorMap.TryGetValue(mathOperator, out className);

                Type typeOfObject = Type.GetType(className);
                mathOperation = (MathOperation) Activator.CreateInstance(typeOfObject);
            
                return mathOperation;
        }

    } //MathObjectFactory 
} //Namespace
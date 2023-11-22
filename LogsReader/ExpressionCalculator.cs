using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogsReader
{
    public static class ExpressionCalculator
    {

        public static double Calculate(string expression, string separator)
        {
            string[] tokens = expression.Split(separator);

            if (tokens.Length % 2 == 0)
            {
                throw new InvalidOperationException("Invalid expression format");
            }

            double result = double.Parse(tokens[0]);

            for (int i = 1; i < tokens.Length; i += 2)
            {
                string op = tokens[i];
                double value = double.Parse(tokens[i + 1]);

                switch (op)
                {
                    case "+":
                        result += value;
                        break;
                    case "-":
                        result -= value;
                        break;
                    case "*":
                        result *= value;
                        break;
                    case "/":
                        result /= value;
                        break;
                    default:
                        throw new InvalidOperationException("Invalid operator: " + op);
                }
            }

            return result;
        }
    }
}

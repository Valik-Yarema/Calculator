using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BAL.Managers;

namespace BAL.Services
{
    public class ComputingModule
    {
        private Stack<double> number = new Stack<double>();
        private Stack<Performance> action = new Stack<Performance>();

        public double CountOperation(string input)
        {
            AddSpaceToOperation(ref input);

            string[] numbers = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToArray();

            double output = ActionLogic(numbers);

            number.Clear();
            action.Clear();
            return output;
        }
        private void AddSpaceToOperation(ref string input)
        {
            StringBuilder builder = new StringBuilder(input);

            builder.Replace("+", " + ")
                   .Replace("-", " - ")
                   .Replace(" -  - ", " - -")//if delete this row=> 4--1=3 
                   .Replace(" +  - ", " + -")
                   .Replace("*", " * ")
                   .Replace("/", " / ")
                   .Replace("%", " % ")
                   .Replace("sqrt", " sqrt ")
                   .Replace("n sqrt", " nsqrt ")
                   .Replace("^", " pow ")
                   .Replace("(", " ( ")
                   .Replace(")", " ) ")
                   .Replace(".", ",")
                ;

            input = builder.ToString();
        }


        private double ActionLogic(string[] input)
        {

            for (int i = 0; i < input.Length; i++)
            {
                if (IsDouble(input[i]))
                {
                    if (action.Count == 0 && number.Count == 0)
                    {
                        number.Push(Convert.ToDouble(input[i]));

                    }
                    else
                    {
                        if (action.Peek().Priority % 3 == 0)
                        {
                            number.Push(ActionMath(action.Pop().Operation, Convert.ToDouble(input[i])));
                        }
                        else
                        {
                            number.Push(Convert.ToDouble(input[i]));
                        }

                    }
                }
                else
                {
                    if (action.Count == 0)
                    {
                        action.Push(new Performance(input[i]));
                    }
                    else
                    {
                        if (isBackBracket(input[i]))
                        {
                            while (!isStartBracket(action.Peek().Operation))
                            {

                                if (number.Count == 1 || action.Peek().Priority % 3 == 0)
                                {
                                    double a = number.Pop();
                                    number.Push(ActionMath(action.Pop().Operation, a));
                                }
                                else
                                {
                                    double b = number.Pop();
                                    double a = number.Pop();

                                    number.Push(ActionMath(action.Pop().Operation, a, b));
                                }
                            };
                            action.Pop();
                        }
                        else
                        {
                            Performance performance = new Performance(input[i]);

                            if (action.Peek().Priority >= performance.Priority && !isStartBracket(action.Peek().Operation))
                            {
                                if (number.Count == 1 || action.Peek().Priority % 3 == 0)
                                {
                                    double a = number.Pop();
                                    number.Push(ActionMath(action.Pop().Operation, a));
                                }
                                else
                                {
                                    double b = number.Pop();
                                    double a = number.Pop();
                                    number.Push(ActionMath(action.Pop().Operation, a, b));
                                }

                                action.Push(new Performance(input[i]));
                            }
                            else
                            {
                                action.Push(performance);
                            }
                        }

                    }
                }

                if (i != input.Length - 1) continue;
                {
                    if (number.Count > 1 && action.Count >= 1)
                    {
                        do
                        {
                            double b = number.Pop();
                            double a = number.Pop();
                            number.Push(ActionMath(action.Pop().Operation, a, b));

                        } while (action.Count != 0);
                    }
                    if (number.Count == 1 && action.Count == 1)
                    {
                        double a = number.Pop();
                        number.Push(ActionMath(action.Pop().Operation, a));
                    }
                }
            }

            return number.Pop();
        }

        public double ActionMath(string act, double a, double b = 0)
        {

            switch (act)
            {
                case "+": return a + b;
                case "-": return a - b;
                case "*": return a * b;
                case "/": return a / b;
                case "%": return a % b;
                case "sqrt": return Math.Sqrt(a);
                case "pow": return Math.Pow(a,b);
                case "nsqrt":return Math.Pow(b,( 1 / a));
                case "(": return a;
                default: throw new Exception(message: " There is no such operation {  " + act + "   }");
            }

        }

        private bool isBackBracket(string s)
        {
            return s == ")";
        }
        bool isStartBracket(string s)
        {
            return s == "(";
        }
        public bool IsDouble(string s)
        {
            try
            {
                Convert.ToDouble(s);
                return true;
            }
            catch
            {
                return false;
            }
            return false;
        }
    }
}

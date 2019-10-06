using System;
using System.Collections.Generic;
using System.Text;

namespace BAL.Managers
{
    public class Performance
    {
        public string Operation;
        public int Priority;

        //single operation priority%3==0 sqrt(number)...
        public Performance(string operation)
        {
            switch (operation)
            {
                case "+": Operation = operation; Priority = 1; break;
                case "-": Operation = operation; Priority = 1; break;
                case "*": Operation = operation; Priority = 2; break;
                case "/": Operation = operation; Priority = 2; break;
                case "%": Operation = operation; Priority = 2; break;
                case "pow": Operation = operation; Priority = 2; break;
                case "nsqrt": Operation = operation; Priority = 4; break;
                case "sqrt": Operation = operation; Priority = 9; break;
                case "(": Operation = operation; Priority = 10; break;
                case ")": Operation = operation; Priority = 10; break;

                default: Operation = operation; Priority = 0; break;
            }
        }
    }
}

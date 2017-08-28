using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    class Operations
    {   
        public enum Operation {Add, Subtract, Multiply, Divide};
        public static double Add(double num1, double num2) {
            return num1 + num2;
        }

        public static double Subtract(double num1, double num2)
        {
            return num1 - num2;
        }

        public static double Divide(double num1, double num2)
        {   
            if (num1 == 0 || num2 == 0) {
                return 0; //to avoid division by zero exception
            }
            return num1 / num2;
        }

        public static double Multiply(double num1, double num2)
        {
            return num1 * num2;
        }

        public static double PerformOperation(double num1, double num2 , Operation operation) {
            switch (operation) {
                case Operation.Add:
                    return Add(num1, num2);
                case Operation.Subtract:
                    return Subtract(num1, num2);
                case Operation.Multiply:
                    return Multiply(num1, num2);
                case Operation.Divide:
                    return Divide(num1, num2);
                default:
                    return 0;
            }
               
        }

    }
}

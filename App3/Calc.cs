﻿using System;
namespace App3
{
    public static class Calc
    {
        static double Memory = 0.0;
        static bool isA = false;
        public static double ValueA { get { return A; } }
        public static bool ValueIsA { get { return isA; } }
        static double A = 0.0;
        static bool isOperation = false;
        static int operation;
        public enum Operation { Add = 1, Sub = 2, Multi = 3, Div = 4 };
        static double lastB;
        static bool isLastB = false;

        public static void reset()
        {
            isA = false;
            isLastB = false;
            isOperation = false;
            A = 0.0;
        }

        public static void MemoryClear()
        {
            Memory = 0.0;
        }

        public static void MemoryAddTo(double num)
        {
            Memory += num;
        }

        public static void MemorySubTo(double num)
        {
            Memory -= num;
        }

        public static double MemoryRecall()
        {
            return Memory;
        }

        public static void ExecAddition(double num)
        {
            A = num;
            isA = true;
            operation = (int)Operation.Add;
            isLastB = false;
            isOperation = true;
        }

        public static void ExecSubstraction(double num)
        {
            A = num;
            isA = true;
            operation = (int)Operation.Sub;
            isLastB = false;
            isOperation = true;
        }

        public static void ExecMultiplication(double num)
        {
            A = num;
            isA = true;
            operation = (int)Operation.Multi;
            isLastB = false;
            isOperation = true;
        }

        public static void ExecDivision(double num)
        {
            A = num;
            isA = true;
            operation = (int)Operation.Div;
            isLastB = false;
            isOperation = true;
        }

        public static bool getResult(double B, out double result, out string comment)
        {
            if (isA && isOperation)
            {
                if (isLastB)
                {
                    B = lastB;
                }
                switch (operation)
                {
                    case (int)Operation.Add:
                        result = A + B;
                        comment = "OK : A=" + A.ToString() + " ; B=" + B.ToString() + " op: +";
                        if (!isLastB)
                        {
                            lastB = B;
                            isLastB = true;
                        }
                        A = result;
                        return true;
                    case (int)Operation.Sub:
                        result = A - B;
                        comment = "OK : A=" + A.ToString() + " ; B=" + B.ToString() + " op: -";
                        A = result;
                        if (!isLastB)
                        {
                            lastB = B;
                            isLastB = true;
                        }
                        return true;
                    case (int)Operation.Multi:
                        result = A * B;
                        comment = "OK : A=" + A.ToString() + " ; B=" + B.ToString() + " op: *";
                        A = result;
                        if (!isLastB)
                        {
                            lastB = B;
                            isLastB = true;
                        }
                        return true;
                    case (int)Operation.Div:
                        result = A / B;
                        comment = "OK : A=" + A.ToString() + " ; B=" + B.ToString() + " op: /";
                        A = result;
                        if (!isLastB)
                        {
                            lastB = B;
                            isLastB = true;
                        }
                        return true;
                    default:
                        result = B;
                        comment = "Another operation";
                        return true;
                }
            }
            else
            {
                result = B;
                comment = "Debug: A=" + A.ToString() + " ; B=" + B.ToString() + " ; " + "OP=" + operation.ToString();
                return false;
            }
        }

        public static double ExecSquareRoot(double A)
        {
            return Math.Sqrt(A);
        }

        public static double ExecEscalation(double A)
        {
            return A * A;
        }

        public static double Sinus(double A)
        {
            return Math.Sin(ToRadians(A));
        }

        public static double Cosinus(double A)
        {
            return Math.Cos(ToRadians(A));
        }

        public static double Tangens(double A)
        {
            return Math.Tan(ToRadians(A));
        }

        public static double Invert(double A)
        {
            return 1.0 / A;
        }

        static double ToRadians(double a)
        {
            return (Math.PI / 180.0) * a;
        }

        public static bool validateDisplay(string displayText)
        {
            try
            {
                double d = double.Parse(displayText);
                if (double.IsNaN(d))
                {
                    return false;
                }
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
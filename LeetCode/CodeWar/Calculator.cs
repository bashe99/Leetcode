using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.CodeWar
{
    public static class Calculator
    {
        public static double Evaluate(string expression)
        {
            System.Data.DataTable table = new System.Data.DataTable();
            return Math.Round(Convert.ToDouble(table.Compute(expression, String.Empty)), 6);
        }
    }
}

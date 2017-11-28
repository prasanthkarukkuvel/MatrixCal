using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MatrixBase
{
    public class MatrixCal
    {
        private Array Matrix { get; set; }

        public int Rows { get
            {
                return Matrix != null ? Matrix.GetLength(0) : 0;
            }
        }

        public int Columns
        {
            get
            {
                return Matrix != null ? Matrix.GetLength(1) : 0;
            }
        }

        public MatrixCal(int RowAndColumn)
        {
            Matrix = Array.CreateInstance(typeof(int), RowAndColumn, RowAndColumn);
        }

        public MatrixCal(int Row, int Column)
        {
            Matrix = Array.CreateInstance(typeof(int), Row, Column);
        }

        public static int[] SplitToInt(params string[] IntStrings)
        {
            return IntStrings
                .SelectMany(value => Regex.Split(value, @"\s{1,}"))
                .Where(value => !(String.IsNullOrWhiteSpace(value) || string.IsNullOrEmpty(value)))
                .Select(value => int.Parse(value.Trim()))
                .ToArray();
        }
    }
}

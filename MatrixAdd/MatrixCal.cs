using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MatrixBase
{
    public class MatrixCal
    {
        public int[,] Matrix { get; set; }

        public int Rows
        {
            get
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

        public MatrixCal(int RowAndColumn, int[] initValues = null)
        {
            Matrix = new int[RowAndColumn, RowAndColumn];

            CreateMatrix(initValues);
        }

        public MatrixCal(int Row, int Column, int[] initValues = null)
        {
            Matrix = new int[Row, Column];

            CreateMatrix(initValues);
        }

        public static int[] SplitToInt(params string[] IntStrings)
        {
            return IntStrings
                .SelectMany(value => Regex.Split(value, @"\s{1,}"))
                .Where(value => !(String.IsNullOrWhiteSpace(value) || string.IsNullOrEmpty(value)))
                .Select(value => int.Parse(value.Trim()))
                .ToArray();
        }

        public (int[], int[]) SelectDiagonal()
        {
            return (new int[0], new int[0]);
        }

        private void CreateMatrix(int[] Input)
        {
            if (Input != null)
            {
                var Selection = Enumerable.Range(0, Rows)
                    .Select(Range => Input.Skip(Range * Rows).Take(Columns))
                    .SelectMany((Items, Row) => Items.Select((Item, Column) => (Item, Row, Column)));                                        

                foreach (var (Item, Row, Column) in Selection)
                {
                    Matrix[Row, Column] = Item;
                }
            }
        }
    }
}

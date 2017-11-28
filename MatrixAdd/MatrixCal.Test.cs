using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MatrixBase;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics;

namespace MatrixBase.Test
{
    class MockUp
    {
        public static int[] Input = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
        public static int[,] Expected = new int[,] { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } };
        public static int[] ExpectedDiagonalX = new int[] { 1, 5, 9 };
        public static int[] ExpectedDiagonalY = new int[] { 3, 5, 7 };
}

    [TestClass]
    public class MatrixCal__SplitToInt
    {
        [TestMethod]
        public void ShouldReturn_IntArrayForString()
        {
            CollectionAssert.AreEqual(MatrixCal.SplitToInt(""), new int[0]);
            CollectionAssert.AreEqual(MatrixCal.SplitToInt("1 20 35"), new int[] { 1, 20, 35 });
        }
    }

    [TestClass]
    public class MatrixCal__MatrixCal
    {       

        [TestMethod]
        public void ShouldCreate_MatrixArray_ForSameRowAndColumn()
        {
            var MatrixCal = new MatrixCal(3);

            Assert.AreEqual(MatrixCal.Rows, 3);
            Assert.AreEqual(MatrixCal.Columns, 3);
        }

        [TestMethod]
        public void ShouldCreate_MatrixArray_ForSameRowAndColumn_WithInitialValue()
        {
            var MatrixCal = new MatrixCal(3, MockUp.Input);

            Assert.AreEqual(MatrixCal.Rows, 3);
            Assert.AreEqual(MatrixCal.Columns, 3);
            CollectionAssert.AreEqual(MatrixCal.Matrix, MockUp.Expected);
        }

        [TestMethod]
        public void ShouldCreate_MatrixArray_ForDifferentRowAndColumn()
        {
            var MatrixCal = new MatrixCal(3, 4);

            Assert.AreEqual(MatrixCal.Rows, 3);
            Assert.AreEqual(MatrixCal.Columns, 4);
        }


        [TestMethod]
        public void ShouldCreate_MatrixArray_ForDifferentRowAndColumn_WithInitialValue()
        {
            var MatrixCal = new MatrixCal(3, 3, MockUp.Input);

            Assert.AreEqual(MatrixCal.Rows, 3);
            Assert.AreEqual(MatrixCal.Columns, 3);
            CollectionAssert.AreEqual(MatrixCal.Matrix, MockUp.Expected);
        }

    }

    [TestClass]
    public class MatrixCal__SelectDiagonal
    {
        [TestMethod]
        public void ShouldReturn_DiagonalValues_AsTupleArray()
        {
            var MatrixCal = new MatrixCal(3, 3, MockUp.Input);
            var (X, Y) = MatrixCal.SelectDiagonal();
            
            CollectionAssert.AreEqual(X, MockUp.ExpectedDiagonalX);
            CollectionAssert.AreEqual(Y, MockUp.ExpectedDiagonalY);
        }
    }
}

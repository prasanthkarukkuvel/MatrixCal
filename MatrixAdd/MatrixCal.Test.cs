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
}

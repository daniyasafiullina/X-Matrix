using static Matrix.XMatrix;
using Matrix;
using System.Drawing;

namespace TestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        [ExpectedException(typeof(InvalidMatrixSize))]
        public void InvalidMatrixSize_Zero()
        {
            XMatrix matrix = new XMatrix(0);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidMatrixSize))]
        public void InvalidMatrixSize_Negative()
        {
            XMatrix matrix = new XMatrix(-1);
        }

        [TestMethod]
        public void ValidMatrix()
        {
            XMatrix matrix1 = new XMatrix(3);
            XMatrix matrix2 = new XMatrix(4);
        }
        
        [TestMethod]
        [ExpectedException(typeof (MatrixIndexOutOfRangeException))]
        public void InvalidIndex()
        {
            XMatrix matrix = new XMatrix(5);
            matrix.Get(6, 6);
        }

        [TestMethod]
        public void ValidIndex()
        {
            XMatrix matrix = new XMatrix(5);
            Assert.AreEqual(matrix.Get(3, 3), 1);
        }


        [TestMethod]
        public void SelfAssignment()
        {
            XMatrix a = new XMatrix(3);
            a = a;

            Assert.IsTrue(a.Equals(new XMatrix(3))); 
        }

        [TestMethod]
        [ExpectedException (typeof (InvalidMatrixSize))]
        public void SumInvalidSizes()
        {
            XMatrix a = new XMatrix(3);
            XMatrix b = new XMatrix(4);
            XMatrix c = a + b;
            
        }

        [TestMethod]
        public void SumValidSizes()
        {
            int size = 5;
            XMatrix a = new XMatrix(size);
            XMatrix b = new XMatrix(size);
            XMatrix c = a + b;

            Assert.IsNotNull(c); 
            Assert.AreEqual(size, c.Size);
        }
        
        [TestMethod]
        public void CommutativityOfSum()
        {
            XMatrix a = new XMatrix(3);
            XMatrix b = new XMatrix(3);
            Assert.IsTrue((a + b).Equals(b + a));
        }

        [TestMethod]
        public void AssociativityOfSum()
        {
            XMatrix a = new XMatrix(4);
            XMatrix b = new XMatrix(4);
            XMatrix c = new XMatrix(4);

            XMatrix l = (a + b) + c;
            XMatrix r = a + (b + c);

            Assert.IsTrue(l.Equals(r));
        }


        [TestMethod]
        [ExpectedException(typeof(InvalidMatrixSize))]
        public void MultInvalidSizes()
        {
            XMatrix a = new XMatrix(3);
            XMatrix b = new XMatrix(4);
            XMatrix c = a * b;
        }

        [TestMethod]
        public void MultValidSizes()
        {
            int size = 4;
            XMatrix a = new XMatrix(size);
            XMatrix b = new XMatrix(size);
            XMatrix c = a * b;

            Assert.IsNotNull(c);
            Assert.AreEqual(size, c.Size);
        }

        [TestMethod]
        public void CommutativityOfMult()
        {
            XMatrix a = new XMatrix(5);
            XMatrix b = new XMatrix(5);

            Assert.IsTrue((a * b).Equals(b * a));
        }

        [TestMethod]
        public void AssociativityOfMult()
        {
            XMatrix a = new XMatrix(5);
            XMatrix b = new XMatrix(5);
            XMatrix c = new XMatrix(5);

            XMatrix l = (a * b) * c;
            XMatrix r = a * (b * c);

            Assert.IsTrue(l.Equals(r));
        }

    }
}
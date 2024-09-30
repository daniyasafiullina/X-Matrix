using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matrix
{
    public class XMatrix
    {
        #region Exceptions
        public class MatrixIndexOutOfRangeException : Exception { }
        public class InvalidMatrixSize : Exception { }
        public class ReferenceToNullPartException : Exception { }
        #endregion

        #region Attribute
        private List<int> diagonals = new List<int>();
        public int size;
        #endregion

        #region Constructor
        public XMatrix(int size)
        {
            if (size <= 0)
            {
                throw new InvalidMatrixSize();
            }
            this.size = size;
            diagonals = new List<int>(calcSize(size));

            for (int i = 0; i < calcSize(size); i++)
            {
                diagonals.Add(1);
            }

        }
        #endregion

        #region Properties
        private static int calcSize(int size)
        {
            return (2 * size) - (size % 2);
        }

        public int Size
        {
            get { return size; }
        }


        private int indeces(int i, int j)
        {
            if (i < 0 || i > size)
            {
                throw new MatrixIndexOutOfRangeException();
            }
            if (j < 0 || j > size)
            {
                throw new MatrixIndexOutOfRangeException();
            }

            if (isInX(i, j))
            {
                if (i == j) return i;
                int index = i + size;
                if ((size % 2 == 1) && (i > size / 2)) return index - 1;
                else return index;
            }
            return -1; // if invalid   
        }
        
        public int this[int i, int j]
        {
            get
            {
                int index = indeces(i, j);
                if (index < 0 && index > calcSize(size)) throw new MatrixIndexOutOfRangeException();
                if (isInX(i, j)) return diagonals[index];
                else return 0;
                    
            }
            set
            {
                int index = indeces(i, j);
                if (index < 0 && index > calcSize(size)) throw new MatrixIndexOutOfRangeException();
                if (isInX(i, j)) diagonals[index] = value;
                else throw new ReferenceToNullPartException();

            }
        }
    

        private bool isInX(int i, int j)
        {
            return (i == j) || (i + j == size - 1);
        }
        #endregion

        #region Getters and Setters
        public void Set(int i, int j, int e)
        {
            if (isInX(i, j))
            {
                this.diagonals[indeces(i, j)] = e;
            }
            else
            {
                return;
            }
        }

        public int Get(int i, int j)
        {

            int index = indeces(i, j);
            if (index >= 0) return diagonals[index];
            return 0;

        }
        

        public override bool Equals(object? obj)
        {
            if (obj == null) return false;
            XMatrix matrix = obj as XMatrix;
            if (size != matrix.Size) return false;

            for (int i = 0; i < calcSize(size); i++)
            {
                if (diagonals[i] != matrix.diagonals[i])
                    return false;
            }
            return true;

        }

        public override string ToString()
        {
            string output = "";
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    output += "\t" + Get(i, j).ToString();
                }
                output += "\n";
            }
            return output;
        }
        #endregion

        #region Operators

        public static XMatrix operator +(XMatrix a, XMatrix b)
        {
            if (a.size == b.size)
            {
                XMatrix sum = new XMatrix(a.size);
                for (int i = 0; i < calcSize(a.size); i++)
                {
                    sum.diagonals[i] = a.diagonals[i] + b.diagonals[i];
                }
                return sum;
            }
            throw new InvalidMatrixSize();
            

        }

        public static XMatrix operator *(XMatrix a, XMatrix b)
        {
            if (a.size == b.size)
            {
                XMatrix result = new XMatrix(a.size);
                for (int i = 0; i < a.size; i++)
                {
                    for (int j = 0; j < a.size; j++)
                    {
                        int value = 0;
                        for (int k = 0; k < a.size; k++)
                        {
                            value += a.Get(i, k) * b.Get(k, j);
                        }
                        result.Set(i, j, value);
                    }
                }
                return result;
            }
            throw new InvalidMatrixSize();
        }
        #endregion

    }
}



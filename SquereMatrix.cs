using System;

namespace AMath
{
    public class SquareMatrix
    {
        public double[,] Cells
        {
            get;
            set;
        }

        public int Size
        {
            get;
            set;
        }

        /// <summary>
        /// Создание матрицы 1х1
        /// </summary>
        public SquareMatrix()
        {
            Size = 1;
            Cells = new double[Size, Size];
        }

        /// <summary>
        /// Создание квадратной матрицы порядка Size
        /// </summary>
        /// <param name="Size">Размер матрицы</param>
        public SquareMatrix(int Size)
        {
            this.Size = Size;
            Cells = new double[Size, Size];
        }

        public SquareMatrix(SquareMatrix oldMatrix)
        {
            Cells = new double[oldMatrix.Size, oldMatrix.Size];
            for(int i = 0; i < oldMatrix.Size; i++)
            {
                for (int j = 0; j < oldMatrix.Size; j++)
                {
                    Cells[i, j] = oldMatrix.Cells[i, j];
                }
            }
            Size = oldMatrix.Size;
        }

        static public SquareMatrix IdentityMatrix(int Size)
        {
            SquareMatrix iMatrix = new SquareMatrix(Size);
            for (int i = 0; i < iMatrix.Size; i++)
            {
                iMatrix.Cells[i, i] = 1;
            }
            return iMatrix;
        }

        public double[] GetRow(int rowNumer)
        {
            double[] rowVector = new double[Size];
            for(int i = 0; i < Size; i++)
            {
                rowVector[i] = Cells[i, rowNumer];
            }
            return rowVector;
        }

        public double[] GetColumn(int columnNumer)
        {
            double[] columnVector = new double[Size];
            for (int i = 0; i < Size; i++)
            {
                columnVector[i] = Cells[columnNumer, i];
            }
            return columnVector;
        }

        private double VectorSum(double[] vector)
        {
            double sum = 0;
            for(int i = 0; i < vector.Length; i++)
            {
                sum += vector[i];
            }
            return sum;
        }

        public void Transpose()
        {
            SquareMatrix transposedMatrix = new SquareMatrix(this);
            for(int i = 0; i < Size; i++)
            {
                for(int j = 0; j < Size; j++)
                {
                    Cells[i, j] = transposedMatrix.Cells[j, i];
                }
            }
        }

        public static SquareMatrix operator +(SquareMatrix m1, SquareMatrix m2)
        {
            if(m1.Size == m2.Size)
            {
                SquareMatrix resultMatrix = m1;
                for(int i = 0; i < m1.Size; i++)
                {
                    for(int j = 0; j < m1.Size; j++)
                    {
                        resultMatrix.Cells[i, j] += m2.Cells[i, j];
                    }
                }
                return resultMatrix;
            }
            else
            {
                return m1;
            }
        }

        public static SquareMatrix operator *(SquareMatrix m1, SquareMatrix m2)
        {
            if (m1.Size == m2.Size)
            {
                SquareMatrix resultMatrix = new SquareMatrix(m1.Size);
                for (int i = 0; i < m1.Size; i++)
                {
                    for (int j = 0; j < m1.Size; j++)
                    {
                        for(int k = 0; k < m1.Size; k++)
                        {
                            resultMatrix.Cells[i, j] += m1.Cells[i, k] * m2.Cells[k, j];
                        }
                    }
                }
                return resultMatrix;
            }
            else
            {
                return m1;
            }
        }

        public static SquareMatrix operator *(SquareMatrix m1, double l)
        {
            SquareMatrix resultMatrix = new SquareMatrix(m1.Size);
            for (int i = 0; i < m1.Size; i++)
            {
                for (int j = 0; j < m1.Size; j++)
                {
                    resultMatrix.Cells[i, j] = m1.Cells[i, j] * l;
                }
            }
            return resultMatrix;
        }

        public static double[] operator *(SquareMatrix m1, double[] vector)
        {
            if (m1.Size == vector.Length)
            {
                double[] resultVector = new double[m1.Size];
                for (int i = 0; i < m1.Size; i++)
                {
                    for(int k = 0; k < m1.Size; k++)
                    {
                        resultVector[i] += m1.Cells[i, k] * vector[k];
                    }
                }
                return resultVector;
            }
            else
            {
                return vector;
            }
        }

        public static double[] operator *(double[] vector, SquareMatrix m1)
        {
            if (m1.Size == vector.Length)
            {
                double[] resultVector = new double[m1.Size];
                for (int i = 0; i < m1.Size; i++)
                {
                    for (int k = 0; k < m1.Size; k++)
                    {
                        resultVector[i] += vector[k] * m1.Cells[k, i];
                    }
                }
                return resultVector;
            }
            else
            {
                throw new ArgumentException();
            }
        }

        public override string ToString()
        {
            string result = "";
            for(int i = 0; i < Size; i++)
            {
                for(int j = 0; j < Size; j++)
                {
                    result += Cells[i, j] + " ";
                }
                result += "\n";
            }
            return result;
        }
    }
}

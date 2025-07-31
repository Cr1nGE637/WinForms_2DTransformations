namespace WinForms_2DTransformations;

public class MatrixOperations
{
    public static T[,] MultiplyMatrices<T>(T[,] matrixA, T[,] matrixB) 
        where T : struct, IConvertible
    {
        int rowsA = matrixA.GetLength(0);
        int colsA = matrixA.GetLength(1);
        int rowsB = matrixB.GetLength(0);
        int colsB = matrixB.GetLength(1);

        if (colsA != rowsB)
        {
            throw new ArgumentException("The number of columns of the first matrix " +
                                        "must match the number of rows of the second matrix.");
        }

        T[,] result = new T[rowsA, colsB];
        
        for (int i = 0; i < rowsA; i++)
        {
            for (int j = 0; j < colsB; j++)
            {
                result[i, j] = default(T);

                for (int k = 0; k < colsA; k++)
                {
                    result[i, j] = Add(result[i, j], Multiply(matrixA[i, k], matrixB[k, j]));
                }
            }
        }

        return result;
    }
    
    private static T Multiply<T>(T a, T b) where T : IConvertible
    {
        return (T)Convert.ChangeType(Convert.ToDouble(a) * Convert.ToDouble(b), typeof(T));
    }
    
    private static T Add<T>(T a, T b) where T : IConvertible
    {
        return (T)Convert.ChangeType(Convert.ToDouble(a) + Convert.ToDouble(b), typeof(T));
    }

    public static T[,] CopyMatrix<T>(T[,] matrixA)
    {
        int rowsA = matrixA.GetLength(0);
        int colsA = matrixA.GetLength(1);
        T[,] result = new T[rowsA, colsA];

        for (int i = 0; i < rowsA; i++)
        {
            for (int j = 0; j < colsA; j++)
            {
                result[i, j] = matrixA[i, j];
            }
        }

        return result;
    }

    public static void ResetToIdentityMatrix(double[,] matrixA) 
    {
        int rowsA = matrixA.GetLength(0);
        int colsA = matrixA.GetLength(1);

        if (rowsA != colsA)
        {
            throw new ArgumentException("The number of columns of the first matrix " +
                                        "must match the number of rows of the second matrix.");
        }
         
        for (int i = 0; i < rowsA; i++)
        {
            for (int j = 0; j < colsA; j++)
            {
                if (i == j)
                    matrixA[i, j] = 1;
                else
                    matrixA[i, j] = 0;
            }
        }
    }
}
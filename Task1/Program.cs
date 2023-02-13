// Задача 54: Задайте двумерный массив. Напишите программу, 
// которая упорядочит по убыванию элементы каждой строки двумерного массива.
// Например, задан массив:
// 1 4 7 2
// 5 9 2 3
// 8 4 2 4
// В итоге получается вот такой массив:
// 7 4 2 1
// 9 5 3 2
// 8 4 4 2


int[,] matrix = Generate2DArray(5, 5);
Print2DArray(matrix);
System.Console.WriteLine("-------------------------------------");
Print2DArray(SortMatrix(matrix));

int[,] SortMatrix(int[,] matrix)
{
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        SortRow(matrix, i);
    }

    return matrix;
}

void SortRow(int[,] matrix, int row)
{
    int rowSize = matrix.GetLength(1);
    for (int k = 0; k < rowSize; k++)
    {
        int currentMax = matrix[row, k];
        int currentMaxPos = k;
        for (int j = k + 1; j < rowSize; j++)
        {
            if (matrix[row, j] > currentMax)
            {
                currentMax = matrix[row, j];
                currentMaxPos = j;
            }
        }

        if (currentMaxPos != k)
        {
            int temp = matrix[row, k];
            matrix[row, k] = currentMax;
            matrix[row, currentMaxPos] = temp;
        }
    }
}

int[,] Generate2DArray(int m, int n)
{
    int[,] result = new int[m, n];

    for (int i = 0; i < result.GetLength(0); i++)
    {
        for (int j = 0; j < result.GetLength(1); j++)
        {
            result[i, j] = new Random().Next(1, 100);
        }
    }

    return result;
}

void Print2DArray(int[,] arr)
{
    for (int i = 0; i < arr.GetLength(0); i++)
    {
        for (int j = 0; j < arr.GetLength(1); j++)
        {
            Console.Write($"{arr[i, j]} ");
        }
        Console.WriteLine();
    }
}
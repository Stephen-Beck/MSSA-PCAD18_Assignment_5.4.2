/*
Write a C# Sharp program to find the sum of the right diagonals of a matrix.
(Right diagonal is from top-right corner to bottom-left corner)
    Test Data :
        Input the size of the square matrix: 2
        Input elements in the first matrix:
            element - [0],[0] : 1
            element - [0],[1] : 2
            element - [1],[0] : 3
            element - [1],[1] : 4
        Expected Output:
            The matrix is:
                1 2
                3 4
            Addition of the right diagonal elements is: 5
*/

using System.Numerics;
using System.Text;

namespace Assignment_5._4._2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int matrixSize = 0;
            // Get matrix size
            while (true)
            {
                Console.Write("Input the size of the square matrix: ");
                if (int.TryParse(Console.ReadLine().Trim(), out matrixSize) && matrixSize > 0) break;
                else Console.Write("Invalid value. ");
            }
            int[,] matrix = new int[matrixSize, matrixSize];

            // Get user input and populate the matrix
            Console.WriteLine("Input elements in the matrix:");
            for (int row = 0; row < matrixSize; row++)
            {
                for (int col = 0; col < matrixSize; col++)
                {
                    SetUserInput(row, col, ref matrix);
                }
            }

            // Display Matrix
            PrintMatrix(ref matrix);

            Console.WriteLine("The sum of the right diagonal elements is: " + AddElements(ref matrix, "right"));
            Console.WriteLine(" The sum of the left diagonal elements is: " + AddElements(ref matrix, "left"));
        }

        static void SetUserInput(int row, int col, ref int[,] matrix)
        {
            int value = 0;
            while (true)
            {
                Console.Write($"\tElement [{row},{col}]: ");
                if (int.TryParse(Console.ReadLine().Trim(), out value)) break;
                else Console.Write("Invalid value. ");
            }
            matrix[row, col] = value;
        }

        static int AddElements(ref int[,] matrix, string direction)
        {
            int row = 0;
            int sum = 0;

            switch (direction.ToLower())
            {
                //right diagonal
                case "right":
                    for (int col = matrix.GetLength(1) - 1; col >= 0; col--)
                    {
                        sum += matrix[row, col];
                        row++;
                    }
                    break;

                //left diagonal
                case "left":
                    for (int col = 0; col < matrix.GetLength(1); col++)
                    {
                        sum += matrix[row, col];
                        row++;
                    }
                    break;
            }
            return sum;
        }

        static void PrintMatrix(ref int[,] matrix)
        {
            StringBuilder display = new();
            int maxNumber = 0;
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] > maxNumber)
                        maxNumber = matrix[row, col];
                }
            }

            int numberLength = maxNumber.ToString().Length;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    display.Append(matrix[row, col].ToString().PadLeft(numberLength)+"   ");
                }
                display.AppendLine();
            }
            Console.WriteLine("\nArray:\n"+display);
        }
    }
}

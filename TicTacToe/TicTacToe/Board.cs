using System.Collections.Generic;

namespace TicTacToe
{
    public class Board
    {
        private List<List<object>> matrix = new List<List<object>>();
        private int rowCount, columnCount, requiredToWin;

        /// <summary>
        /// Initializes and creates a square game board for row and column. In addition the requirement to win is set to the same value.
        /// </summary>
        /// <param name="BoardSize"></param>
        public Board(int BoardSize)
        {
            rowCount = BoardSize;
            columnCount = BoardSize;
            requiredToWin = BoardSize;

            InitializeBoard();
        }

        /// <summary>
        /// Initializes and creates a based on the values given for row, column and requirement of tokens in a row/column/diagonal to win.
        /// </summary>
        /// <param name="Row"></param>
        /// <param name="Column"></param>
        /// <param name="requiredToWin"></param>
        public Board(int Row, int Column, int requiredToWin)
        {
            rowCount = Row;
            columnCount = Column;
            this.requiredToWin = requiredToWin;

            InitializeBoard();
        }

        /// <summary>
        /// Sets the desired token based on the row and column given
        /// </summary>
        /// <param name="Row"></param>
        /// <param name="Column"></param>
        /// <param name="Token"></param>
        public void SetTokenAtLocation(int Row, int Column, object Token)
        {
            if (matrix[Row][Column] == null)
            {
                matrix[Row][Column] = Token;
            }
        }

        /// <summary>
        /// Sets the desired token based on the index converted to the row and column position
        /// </summary>
        /// <param name="Index"></param>
        /// <param name="Token"></param>
        public void SetTokenAtLocation(int Index, object Token)
        {
            // Matrix index sample:
            // 0 1 2
            // 3 4 5
            // 6 7 8

            int row = Index / columnCount;
            int col = Index - (row * columnCount);
            matrix[row][col] = Token;
        }

        /// <summary>
        /// Creates matrix by adding null elements to each position
        /// </summary>
        private void InitializeBoard()
        {
            for (int row = 0; row < rowCount; row++)
            {
                List<object> list = new List<object>();
                for (int col = 0; col < columnCount; col++)
                {
                    list.Add(null);
                }
                matrix.Add(list);
            }
        }

        /// <summary>
        /// Sets all elements to null
        /// </summary>
        public void ResetBoard()
        {
            for(int row = 0; row < matrix.Count; row++)
            {
                for(int col = 0; col < matrix[row].Count; col++)
                {
                    matrix[row][col] = null;
                }
            }
        }

        /// <summary>
        /// Returns true is all elements in the matrix are filled
        /// </summary>
        /// <returns></returns>
        public bool IsAllElementsFilled()
        {
            for (int row = 0; row < matrix.Count; row++)
            {
                for (int col = 0; col < matrix[row].Count; col++)
                {
                    if(matrix[row][col] == null)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        /// <summary>
        /// Checks all rows, columns, primary and secondary diagonals
        /// </summary>
        /// <returns></returns>
        public bool DetectWinCondition()
        {
            return RowWinCondition() || ColumnWinCondition() || PrimaryDiagonalWinCondition() || SecondaryDiagonalWinCondition();
        }

        /// <summary>
        /// Returns true whenever a matching set is found
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        private bool TestForWinCondition(List<object> list)
        {
            if (list.Count >= requiredToWin) // if list count is less than the requirement, win condition can never be met
            {
                int count = 0;
                for (int i = 0; i < list.Count; i++)
                {
                    if (list[i] == null)
                    {
                        count = 0; // empty element found, reset count
                    }
                    else if (i + 1 < list.Count)
                    {
                        if (list[i].Equals(list[i + 1]))
                        {
                            if (count == 0)
                            {
                                count = 2; // if count is zero and the first pair is found
                            }
                            else
                            {
                                count++;
                            }
                        }
                        else
                        {
                            count = 0; // change in pattern, reset count
                        }
                    }
                    if (count == requiredToWin)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        /// <summary>
        /// Detects win conditions for the rows of a matrix
        /// </summary>
        /// <returns></returns>
        private bool RowWinCondition()
        {
            List<object> list = new List<object>();
            int row = 0;

            while (row < rowCount)
            {
                list.Clear(); // if list count is less than the requirement, win condition can never be met

                for (int col = 0; col < columnCount; col++)
                {
                    list.Add(matrix[row][col]); // populate list with row data
                }

                // detect if win condition is met
                if (TestForWinCondition(list))
                {
                    return true;
                }
                else
                {
                    row++; // move onto the next row
                }
            }
            return false;
        }

        /// <summary>
        /// Detects win conditions for the columns of a matrix
        /// </summary>
        /// <returns></returns>
        private bool ColumnWinCondition()
        {
            List<object> list = new List<object>();
            int col = 0;

            while (col < columnCount)
            {
                list.Clear(); // if list count is less than the requirement, win condition can never be met
                
                for (int row = 0; row < rowCount; row++)
                {
                    list.Add(matrix[row][col]); // populate list with column data
                }

                // detect if win condition is met
                if (TestForWinCondition(list))
                {
                    return true;
                }
                else
                {
                    col++; // move onto the next column
                }
            }
            return false;
        }

        /// <summary>
        /// Detects win conditions for '\' diagonals of a matrix
        /// </summary>
        /// <returns></returns>
        private bool PrimaryDiagonalWinCondition()
        {
            List<object> list = new List<object>();
            int rowStart = 0;
            int colStart = columnCount - 1;

            /* Scans diagonally down towards the right from the starting position which is the first element in every row. 
             * See pattern below 'x' marks what is scanned:
             * x _ _ _ _
             * x x _ _ _
             * x x x _ _
             * x x x x _
             * x x x x x
            */
            while (rowStart < rowCount)
            {
                list.Clear(); // empty list to avoid an unrealistic win condition

                int col = colStart;
                for (int row = rowStart; row >= 0; row--)
                {
                    // add current element only if list is empty
                    if (list.Count == 0)
                    {
                        list.Add(matrix[row][col]);
                    }

                    // add the next element that is diagonal to current element
                    if (row - 1 >= 0 && col - 1 >= 0)
                    {
                        list.Add(matrix[row - 1][col - 1]);
                        col--; // adjust col to maintain diagonal relationship
                    }
                    else
                    {
                        rowStart++; // adjust row starting position for next loop
                        break; // escape for loop
                    }
                }

                if (TestForWinCondition(list))
                {
                    return true;
                }
            }

            /* Scans diagonally down towards the right from the starting position which is every element in the first row skipping the first element's diagonal as it is already scanned.
             * See pattern below 'x' marks what is scanned:
             * _ x x x x
             * _ _ x x x
             * _ _ _ x x
             * _ _ _ _ x
             * _ _ _ _ _
            */
            rowStart = rowCount - 1;
            colStart = columnCount - 2;
            while (colStart >= 0)
            {
                list.Clear(); // empty list to avoid an unrealistic win condition

                int row = rowStart;
                for (int col = colStart; col >= 0; col--)
                {
                    // add current element only if list is empty
                    if (list.Count == 0)
                    {
                        list.Add(matrix[row][col]);
                    }

                    // add the next element that is diagonal to current element
                    if (row - 1 >= 0 && col - 1 >= 0)
                    {
                        list.Add(matrix[row - 1][col - 1]);
                        row--; // adjust row to maintain diagonal relationship
                    }
                    else
                    {
                        colStart--; // adjust col starting position for next loop
                        break; // escape for loop
                    }
                }

                if (TestForWinCondition(list))
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Detects win conditions for '/' diagonals of a matrix
        /// </summary>
        /// <returns></returns>
        private bool SecondaryDiagonalWinCondition()
        {
            List<object> list = new List<object>();
            int rowStart = 0;
            int colStart = 0;

            /* Scans diagonally up towards the right from the starting position which is the first element in every row. 
             * See pattern below 'x' marks what is scanned:
             * x x x x x
             * x x x x _
             * x x x _ _
             * x x _ _ _
             * x _ _ _ _
            */
            while (rowStart < rowCount)
            {
                list.Clear(); // empty list to avoid an unrealistic win condition

                int col = colStart;
                for (int row = rowStart; row >= 0; row--)
                {
                    // add current element only if list is empty
                    if (list.Count == 0)
                    {
                        list.Add(matrix[row][col]);
                    }

                    // add the next element that is diagonal to current element
                    if (row - 1 >= 0 && col + 1 < columnCount)
                    {
                        list.Add(matrix[row - 1][col + 1]);
                        col++; // adjust col to maintain diagonal relationship
                    }
                    else
                    {
                        rowStart++; // adjust row starting position for next loop
                        break; // escape for loop
                    }
                }

                if (TestForWinCondition(list))
                {
                    return true;
                }
            }

            /* Scans diagonally up towards the right from the starting position which is every element in the bottom row skipping the first element's diagonal as it is already scanned.
             * See pattern below 'x' marks what is scanned:
             * _ _ _ _ _
             * _ _ _ _ x
             * _ _ _ x x
             * _ _ x x x
             * _ x x x x
            */
            rowStart = rowCount - 1;
            colStart = 1;
            while (colStart < columnCount)
            {
                list.Clear(); // empty list to avoid an unrealistic win condition

                int row = rowStart;
                for (int col = colStart; col < columnCount; col++)
                {
                    // add current element only if list is empty
                    if (list.Count == 0)
                    {
                        list.Add(matrix[row][col]);
                    }

                    // add the next element that is diagonal to current element
                    if (row - 1 >= 0 && col + 1 < columnCount)
                    {
                        list.Add(matrix[row - 1][col + 1]);
                        row--; // adjust row to maintain diagonal relationship
                    }
                    else
                    {
                        colStart++; // adjust col starting position for next loop
                        break; // escape for loop
                    }
                }

                if (TestForWinCondition(list))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
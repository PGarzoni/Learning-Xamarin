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
        /// <param name="RequirementToWin"></param>
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
        /// <param name="RequirementToWin"></param>
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
        /// <param name="Mark"></param>
        public void SetTokenAtLocation(int Row, int Column, object token)
        {
            if (matrix[Row][Column] == null)
            {
                matrix[Row][Column] = token;
            }
        }

        /// <summary>
        /// Sets the desired token based on the index converted to the row and column position
        /// </summary>
        /// <param name="Row"></param>
        /// <param name="Column"></param>
        /// <param name="Mark"></param>
        public void SetTokenAtLocation(int Index, object token)
        {
            bool escape = false;
            int count = 0;
            for (int row = 0; row < rowCount; row++)
            {
                for (int col = 0; col < columnCount; col++)
                {
                    if (count == Index)
                    {
                        if (matrix[row][col] == null)
                        {
                            matrix[row][col] = token;
                            escape = true;
                            break;
                        }
                    }
                    else
                    {
                        count++;
                    }
                }
                if (escape)
                {
                    break;
                }
            }

        }

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

        public bool IsAllElementsFilled()
        {
            bool flag = false;
            for (int row = 0; row < matrix.Count; row++)
            {
                for (int col = 0; col < matrix[row].Count; col++)
                {
                    if(matrix[row][col] != null)
                    {
                        flag = true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            return flag;
        }

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
                list.Clear();
                //populate list with row data
                for (int col = 0; col < columnCount; col++)
                {
                    list.Add(matrix[row][col]);
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
                list.Clear();
                // populate list with column data
                for (int row = 0; row < rowCount; row++)
                {
                    list.Add(matrix[row][col]);
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

            while (rowStart < rowCount)
            {
                list.Clear();

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
                        break; // escape loop
                    }
                }

                if (TestForWinCondition(list))
                {
                    return true;
                }
            }

            rowStart = rowCount - 1;
            colStart = columnCount - 2;
            while (colStart >= 0)
            {
                list.Clear();

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
                        break; // escape loop
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

            while (rowStart < rowCount)
            {
                list.Clear();

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
                        break; // escape loop
                    }
                }

                if (TestForWinCondition(list))
                {
                    return true;
                }
            }

            rowStart = rowCount - 1;
            colStart = 1;
            while (colStart < columnCount)
            {
                list.Clear();

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
                        break; // escape loop
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
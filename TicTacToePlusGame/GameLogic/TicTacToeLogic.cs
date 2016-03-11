using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToePlusGame.GameLogic
{
    public class TicTacToeLogic
    {
        public TicTacToeLogic()
        {
            insideField = new int[3, 3][,];
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    insideField[i, j] = new int[3, 3];
                }
            }
            outsideField = new int[3, 3];
        }

        int[,][,] insideField;
        int[,] outsideField;

        private bool CanMakeMove(int x1, int y1, int x2, int y2)
        {            
            return outsideField[x1,y1] == 0 && insideField[x1, y1][x2, y2] == 0;
        }

        public void MakeMove(int x1, int y1, int x2, int y2, int team)
        {
            if (team == 1 || team == 2)
            {
                if (CanMakeMove(x1, y1, x2, y2))
                {
                    MakeMoveInside(x1, y1, x2, y2, team);
                } else
                {
                    throw new Exception("Can't move");
                }
            } else
            {
                throw new Exception("Onknown team");
            }
        }

        private void MakeMoveInside(int x1, int y1, int x2, int y2, int team)
        {
            insideField[x1, y1][x2, y2] = team;
            if (IsWoninField(team, insideField[x1, y1]))
            {
                outsideField[x1, y1] = team;
            } else if (IsFullinField(insideField[x1, y1]))
            {
                outsideField[x1, y1] = 10;
            }

        }

        public int getOutsideCell(int x1, int y1)
        {
            if (x1 >= 3 && x1 < 0 && y1 >= 3 && y1 < 0) throw new IndexOutOfRangeException("Wrong args");
            return outsideField[x1, y1];
            
        }

        public int getInsideCell(int x1, int y1, int x2, int y2)
        {
            if (x1 >= 3 && x1 < 0 && y1 >= 3 && y1 < 0) throw new IndexOutOfRangeException("Wrong args");
            if (x2 >= 3 && x2 < 0 && y2 >= 3 && y2 < 0) throw new IndexOutOfRangeException("Wrong args");
            return insideField[x1, y1][x2, y2];
        }

        private bool IsWoninField(int team, int[,] field)
        {
            int x = 0;
            for (int y = 0; y < 3; y++)
            {
                int n = Math.Min(field.GetLength(0), x + 3);
                int m = Math.Min(field.GetLength(1), y + 3);
                if (m - y == 3)
                {
                    for (int i = y; i < m; i++)
                    {
                        if (field[x, i] != team)
                            break;
                        if (i - y == 2)
                        {
                            return true;
                        }
                    }
                }

                if (n - x == 3)
                {
                    for (int i = x; i < n; i++)
                    {
                        if (field[i, y] != team)
                            break;
                        if (i - x == 2)
                            return true;

                    }
                }
                if (n - x == 3 && m - y == 3)
                {
                    for (int i = 0; i < 3; i++)
                    {
                        if (field[x + i, y + i] != team)
                            break;
                        if (i == 2)
                            return true;

                    }
                }
                if (n - x == 3 && y - 3 >= 0)
                {
                    for (int i = 0; i < 3; i++)
                    {
                        if (field[x + i, y - i] != team)
                            break;
                        if (i == 2)
                            return true;
                    }
                }
            }
            return false;
        }

        private bool IsFullinField(int[,] field)
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (field[i, j] == 0) return false;
                }
            }
            return true;
        }

        public bool IsWon(int team)
        {
            return IsWoninField(team, outsideField);
        } 

        public bool IsFull()
        {
            return IsFullinField(outsideField);
        }

        public bool IsDraw()
        {
            return !IsWon(1) && !IsWon(2) && IsFull();
        }

    }
}

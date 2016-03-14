using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Shapes;

namespace TicTacToePlusGame.Graphics
{
    public class GameRectangleInside : GameRectangle
    {
        public GameRectangleInside(Rectangle rectangle, int x1, int y1, int x2, int y2) : base(rectangle, x1, y1)
        {
            X2 = x2;
            Y2 = y2;
        }

        public int X2 { get; set; }
        public int Y2 { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Shapes;

namespace TicTacToePlusGame.Graphics
{
    public class GameRectangle
    {
        public Rectangle Border { get; set; }

        public IControl Item { get;  set; }        

        public GameRectangle(Rectangle rectangle, int x1, int y1)
        {
            Border = rectangle;
            Item = null;
            X1 = x1;
            Y1 = y1;
        }

        public int X1 { get; set; }
        public int Y1 { get; set; }
    }
}

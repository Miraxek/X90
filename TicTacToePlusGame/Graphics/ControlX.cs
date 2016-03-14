using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Shapes;

namespace TicTacToePlusGame.Graphics
{
    public class ControlX : IControl
    {
        Line line1;
        Line line2;

        double x;
        double y;
        double size;
        public ControlX(double x, double y, double size)
        {
            this.x = x;
            this.y = y;
            this.size = size;

            line1 = new Line()
            {
                StrokeThickness = 2,
                Stroke = System.Windows.Media.Brushes.DeepSkyBlue,
                X1 = x,
                Y1 = y,
                X2 = x + size,
                Y2 = y + size
            };

            line2 = new Line()
            {
                StrokeThickness = 2,
                Stroke = System.Windows.Media.Brushes.DeepSkyBlue,
                X1 = x,
                Y1 = y + size,
                X2 = x + size,
                Y2 = y
            };
        }

        public void AddTo(UIElementCollection collection)
        {
            collection.Add(line1);
            collection.Add(line2);
        }

        public void RemoveFrom(UIElementCollection collection)
        {
            collection.Remove(line1);
            collection.Remove(line2);
        }

        public void ChangePosition(double x, double y)
        {
            line1.X1 = x;
            line1.Y1 = y;
            line1.X2 = x + size;
            line1.Y2 = y + size; 
            line2.X1 = x;
            line2.Y1 = y + size;
            line2.X2 = x + size;
            line2.Y2 = y;
        }
    }
}

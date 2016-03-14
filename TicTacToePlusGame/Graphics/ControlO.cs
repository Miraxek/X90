using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Shapes;

namespace TicTacToePlusGame.Graphics
{
    public class ControlO : IControl
    {
        Ellipse circle;
        double x;
        double y;
        double size;
        public ControlO(double x, double y, double size)
        {
            this.x = x;
            this.y = y;
            this.size = size;

            circle = new Ellipse()
            {
                StrokeThickness = 2,
                Stroke = System.Windows.Media.Brushes.LightPink,
                Margin = new System.Windows.Thickness(x, y, 0, 0),
                Width = size,
                Height = size
            };

        }

        public void AddTo(UIElementCollection collection)
        {
            collection.Add(circle);
        }

        public void RemoveFrom(UIElementCollection collection)
        {
            collection.Remove(circle);
        }

        public void ChangePosition(double x, double y)
        {
            circle.Margin = new System.Windows.Thickness(x, y, 0, 0);
        }
    }
}

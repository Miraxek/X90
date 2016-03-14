using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Shapes;

namespace TicTacToePlusGame.Graphics
{
    public class ControlNAN : IControl
    {
        Rectangle rectangle;
        double x;
        double y;
        double size;
        public ControlNAN(double x, double y, double size)
        {
            this.x = x;
            this.y = y;
            this.size = size;

            rectangle = new Rectangle()
            {
                Fill = System.Windows.Media.Brushes.LightGray,
                Margin = new System.Windows.Thickness(x, y, 0, 0),
                Width = size,
                Height = size
            };

        }

        public void AddTo(UIElementCollection collection)
        {
            collection.Add(rectangle);
        }

        public void RemoveFrom(UIElementCollection collection)
        {
            collection.Remove(rectangle);
        }

        public void ChangePosition(double x, double y)
        {
            rectangle.Margin = new System.Windows.Thickness(x, y, 0, 0);
        }
    }
}

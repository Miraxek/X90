using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace TicTacToePlusGame.Graphics
{
    public interface IControl
    {
        void AddTo(UIElementCollection collection);
        void RemoveFrom(UIElementCollection collection);
    }
}

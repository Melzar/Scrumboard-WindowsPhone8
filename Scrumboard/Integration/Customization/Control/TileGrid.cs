using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace System.Windows.Controls
{
    public partial class TileGrid : Grid
    {
        public TileGrid()
        {
            Background = new SolidColorBrush(Color.FromArgb(255, 52, 180, 151));
            Height = 100;
          //  HorizontalAlignment = HorizontalAlignment.Stretch;
        }
    }
}

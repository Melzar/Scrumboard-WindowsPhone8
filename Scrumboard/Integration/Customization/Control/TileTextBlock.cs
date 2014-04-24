using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace System.Windows.Controls
{
    public class TileTextBlock
    {
        public static TextBlock InitializeDefaultTextBlock(string text)
        {
            TextBlock customized = new TextBlock();
            customized.FontSize = 36;
            customized.FontFamily = new Media.FontFamily("Buxton Sketch");
            Thickness margin = new Thickness();
            margin.Top = 10;
            margin.Left = 10;
            margin.Right = 10;
            margin.Bottom = 10;
            customized.Margin = margin;
            customized.Text = text;
            return customized;
        }

        public static TextBlock InitializeCustomizedFontSizeTextBlock( int fontsize, string text)
        {
            TextBlock customized = InitializeDefaultTextBlock(text);
            customized.FontSize = fontsize;
            return customized;
        }

    }
}

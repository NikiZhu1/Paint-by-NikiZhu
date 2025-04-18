using PluginInterface;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PluginLibrary
{
    public class Negative : IPlugin
    {
        public string Name
        {
            get { return "Негатив изображения"; }
        }

        public string Author
        {
            get { return "Me"; }
        }

        public void Transform(Bitmap bitmap)
        {
            for (int i = 0; i < bitmap.Width; ++i)
            {
                for (int j = 0; j < bitmap.Height; ++j)
                {
                    Color originalColor = bitmap.GetPixel(i, j);

                    Color negativeColor = Color.FromArgb(
                        255 - originalColor.R,
                        255 - originalColor.G,
                        255 - originalColor.B);
                    bitmap.SetPixel(i, j, negativeColor);
                }
            }
        }
    }
}

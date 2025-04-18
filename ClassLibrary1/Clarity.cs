using PluginInterface;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace PluginLibrary
{
    public class Сlarity : IPlugin
    {
        public string Name
        {
            get { return "Увеличение чёткости"; }
        }

        public string Author
        {
            get { return "Me"; }
        }

        public void Transform(Bitmap bitmap)
        {
            // Ядро фильтра резкости (3x3)
            float[,] kernel = {
                { 0, -1,  0 },
                { -1,  5, -1 },
                { 0, -1,  0 }
            };

            // Применяем фильтр
            ApplyKernel(bitmap, kernel);
        }

        private void ApplyKernel(Bitmap bitmap, float[,] kernel)
        {
            Bitmap original = (Bitmap)bitmap.Clone();
            int width = bitmap.Width;
            int height = bitmap.Height;
            int kernelSize = kernel.GetLength(0);
            int radius = kernelSize / 2;

            for (int x = radius; x < width - radius; x++)
            {
                for (int y = radius; y < height - radius; y++)
                {
                    float r = 0, g = 0, b = 0;

                    // Применяем ядро к каждому пикселю
                    for (int i = -radius; i <= radius; i++)
                    {
                        for (int j = -radius; j <= radius; j++)
                        {
                            Color pixel = original.GetPixel(x + i, y + j);
                            float weight = kernel[i + radius, j + radius];

                            r += pixel.R * weight;
                            g += pixel.G * weight;
                            b += pixel.B * weight;
                        }
                    }

                    // Ограничиваем значения в диапазоне 0-255
                    r = Math.Max(0, Math.Min(255, r));
                    g = Math.Max(0, Math.Min(255, g));
                    b = Math.Max(0, Math.Min(255, b));

                    bitmap.SetPixel(x, y, Color.FromArgb((int)r, (int)g, (int)b));
                }
            }
        }
    }
}

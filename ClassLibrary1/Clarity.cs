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

        public void Transform(Bitmap bitmap, CancellationToken token, IProgress<int> progress)
        {
            float[,] kernel = {
                { 0, -1,  0 },
                { -1,  5, -1 },
                { 0, -1,  0 }
            };

            ApplyKernel(bitmap, kernel, token, progress);
        }

        private unsafe void ApplyKernel(Bitmap bitmap, float[,] kernel, CancellationToken token, IProgress<int> progress)
        {
            int width = bitmap.Width;
            int height = bitmap.Height;
            int kernelSize = kernel.GetLength(0);
            int radius = kernelSize / 2;

            // Копируем исходное изображение
            Bitmap source = (Bitmap)bitmap.Clone();

            BitmapData sourceData = source.LockBits(
                new Rectangle(0, 0, width, height),
                ImageLockMode.ReadOnly,
                PixelFormat.Format24bppRgb);

            BitmapData targetData = bitmap.LockBits(
                new Rectangle(0, 0, width, height),
                ImageLockMode.WriteOnly,
                PixelFormat.Format24bppRgb);

            int stride = sourceData.Stride;

            byte* srcPtr = (byte*)sourceData.Scan0;
            byte* dstPtr = (byte*)targetData.Scan0;

            int completedLines = 0;

            Parallel.For(radius, height - radius, y =>
            {
                token.ThrowIfCancellationRequested();
                //Task.Delay(1, token).Wait(token);

                for (int x = radius; x < width - radius; x++)
                {
                    float r = 0, g = 0, b = 0;

                    for (int ky = -radius; ky <= radius; ky++)
                    {
                        for (int kx = -radius; kx <= radius; kx++)
                        {
                            int pixelX = x + kx;
                            int pixelY = y + ky;

                            byte* p = srcPtr + pixelY * stride + pixelX * 3;

                            float weight = kernel[ky + radius, kx + radius];
                            b += p[0] * weight;
                            g += p[1] * weight;
                            r += p[2] * weight;
                        }
                    }

                    // Ограничиваем значения
                    r = Math.Max(0, Math.Min(255, r));
                    g = Math.Max(0, Math.Min(255, g));
                    b = Math.Max(0, Math.Min(255, b));

                    byte* dstPixel = dstPtr + y * stride + x * 3;
                    dstPixel[0] = (byte)b;
                    dstPixel[1] = (byte)g;
                    dstPixel[2] = (byte)r;
                }

                int done = Interlocked.Increment(ref completedLines);
                progress?.Report(done * 100 / (height - radius * 2));
            });

            bitmap.UnlockBits(targetData);
            source.UnlockBits(sourceData);
            source.Dispose();
        }
    }
}

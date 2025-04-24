using PluginInterface;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
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

        public void Transform(Bitmap bitmap, CancellationToken token, IProgress<int> progress)
        {
            int width = bitmap.Width;
            int height = bitmap.Height;

            BitmapData data = bitmap.LockBits(
                new Rectangle(0, 0, width, height),
                ImageLockMode.ReadWrite,
                PixelFormat.Format24bppRgb); // или другой, если ты используешь другой формат

            int stride = data.Stride;

            unsafe
            {
                byte* ptr = (byte*)data.Scan0;
                int completedLines = 0;

                Parallel.For(0, height, y =>
                {
                    token.ThrowIfCancellationRequested();

                    Task.Delay(1, token).Wait(token);

                    byte* row = ptr + (y * stride);
                    for (int x = 0; x < width; x++)
                    {
                        byte* pixel = row + x * 3;

                        pixel[0] = (byte)(255 - pixel[0]); // B
                        pixel[1] = (byte)(255 - pixel[1]); // G
                        pixel[2] = (byte)(255 - pixel[2]); // R
                    }

                    int done = Interlocked.Increment(ref completedLines);
                    progress?.Report(done * 100 / height);
                });
            }

            bitmap.UnlockBits(data);
        }

        public void oldTransform(Bitmap bitmap, CancellationToken? token)
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

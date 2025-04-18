using PluginInterface;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PluginLibrary
{
    public class Frame : IPlugin
    {
        public string Name
        {
            get { return "Художественная рамка"; }
        }

        public string Author
        {
            get { return "Me"; }
        }

        public void Transform(Bitmap bitmap)
        {
            int frameWidth = 20;
            Color borderColor = GeneratePleasantRandomColor();

            using (Graphics g = Graphics.FromImage(bitmap))
            {
                // Сохраняем область изображения, которую нужно оставить без рамки
                Rectangle innerRect = new Rectangle(
                    frameWidth,
                    frameWidth,
                    bitmap.Width - frameWidth * 2,
                    bitmap.Height - frameWidth * 2);

                // Создаем текстурированную кисть для рамки
                using (TextureBrush brush = CreateTextureBrush(borderColor, 200))
                using (Pen framePen = new Pen(brush, frameWidth))
                {
                    // Рисуем рамку по краям изображения
                    g.DrawRectangle(framePen,
                        frameWidth / 2,
                        frameWidth / 2,
                        bitmap.Width - frameWidth,
                        bitmap.Height - frameWidth);
                }

                // Добавляем декоративные уголки
                AddCornerDecorations(g, bitmap.Width, bitmap.Height, frameWidth, borderColor);
            }
        }

        private TextureBrush CreateTextureBrush(Color baseColor, int size)
        {
            Bitmap texture = new Bitmap(size, size);
            using (Graphics g = Graphics.FromImage(texture))
            {
                g.Clear(baseColor);

                Random rnd = new Random();
                Pen pen = new Pen(DarkenColor(baseColor, 0.2f), 1);

                for (int i = 0; i < 10; i++)
                {
                    Point p1 = new Point(rnd.Next(size), rnd.Next(size));
                    Point p2 = new Point(rnd.Next(size), rnd.Next(size));
                    g.DrawLine(pen, p1, p2);
                }
            }
            return new TextureBrush(texture);
        }

        private void AddCornerDecorations(Graphics g, int width, int height, int frameWidth, Color color)
        {
            int triangleSize = frameWidth * 2;
            Pen trianglePen = new Pen(DarkenColor(color, 0.2f), 2);
            Brush triangleBrush = new SolidBrush(DarkenColor(color, 0.1f));

            // Левый верхний угол
            Point[] topLeftTriangle = {
            new Point(0, 0),
            new Point(triangleSize, 0),
            new Point(0, triangleSize)
        };

            // Правый верхний угол
            Point[] topRightTriangle = {
            new Point(width - 1, 0),
            new Point(width - 1, triangleSize),
            new Point(width - triangleSize - 1, 0)
        };

            // Левый нижний угол
            Point[] bottomLeftTriangle = {
            new Point(0, height - 1),
            new Point(0, height - triangleSize - 1),
            new Point(triangleSize, height - 1)
        };

            // Правый нижний угол
            Point[] bottomRightTriangle = {
            new Point(width - 1, height - 1),
            new Point(width - triangleSize - 1, height - 1),
            new Point(width - 1, height - triangleSize - 1)
        };

            // Рисуем все 4 треугольника
            g.FillPolygon(triangleBrush, topLeftTriangle);
            g.FillPolygon(triangleBrush, topRightTriangle);
            g.FillPolygon(triangleBrush, bottomLeftTriangle);
            g.FillPolygon(triangleBrush, bottomRightTriangle);

            g.DrawPolygon(trianglePen, topLeftTriangle);
            g.DrawPolygon(trianglePen, topRightTriangle);
            g.DrawPolygon(trianglePen, bottomLeftTriangle);
            g.DrawPolygon(trianglePen, bottomRightTriangle);
        }

        private Color DarkenColor(Color color, float factor)
        {
            return Color.FromArgb(
                (int)(color.R * (1 - factor)),
                (int)(color.G * (1 - factor)),
                (int)(color.B * (1 - factor)));
        }

        private Color GeneratePleasantRandomColor()
        {
            Random rand = new Random();

            // Генерируем цвет в HSV и конвертируем в RGB для получения приятных цветов
            float hue = rand.Next(360); // Все возможные оттенки
            float saturation = 0.7f + (float)rand.NextDouble() * 0.3f; // Яркая насыщенность
            float value = 0.5f + (float)rand.NextDouble() * 0.4f; // Средняя яркость

            return HsvToRgb(hue, saturation, value);
        }

        private Color HsvToRgb(float h, float s, float v)
        {
            int hi = (int)(h / 60) % 6;
            float f = h / 60 - (int)(h / 60);

            float p = v * (1 - s);
            float q = v * (1 - f * s);
            float t = v * (1 - (1 - f) * s);

            float r, g, b;

            switch (hi)
            {
                case 0: r = v; g = t; b = p; break;
                case 1: r = q; g = v; b = p; break;
                case 2: r = p; g = v; b = t; break;
                case 3: r = p; g = q; b = v; break;
                case 4: r = t; g = p; b = v; break;
                default: r = v; g = p; b = q; break;
            }

            return Color.FromArgb(
                (int)(r * 255),
                (int)(g * 255),
                (int)(b * 255));
        }
    }
}

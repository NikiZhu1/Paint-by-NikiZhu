using System.Drawing.Drawing2D;
using System.Drawing.Imaging;

namespace Paint_by_NikiZhu
{
    public partial class FormDocument : Form
    {
        int oldX, oldY;
        public Bitmap bitmap; // Главный холст
        public Bitmap previewBitmap; // Временный холст для предпросмотра
        public bool isModified = false; // Флаг изменений
        private float scale = 1.0f; //Масштаб битмапа
        private bool isDragging = false; //Перемещение текста

        public string FilePath { get; private set; } // Путь к текущему файлу

        public float BitmapScale //Масштаб битмапа
        {
            get { return scale; }
            set { scale = value; }
        }

        private static Cursor CreateCursor(Bitmap bmp, int xHotSpot, int yHotSpot)
        {
            IntPtr ptr = bmp.GetHicon();
            return new Cursor(ptr);
        }

        private readonly Cursor EraserCursor = CreateCursor(new Bitmap(Properties.Resources.eraser), 0, 0);
        private readonly Cursor FillerCursor = CreateCursor(new Bitmap(Properties.Resources.fill), 0, 0);

        public FormDocument(int width, int height)
        {
            InitializeComponent();

            this.AutoScrollMinSize = new Size(width, height); // Устанавливаем минимальный размер области прокрутки

            bitmap = new(width, height);
            var g = Graphics.FromImage(bitmap);
            g.Clear(Color.White); // Заливка белым цветом

            // Временный холст с прозрачным фоном
            previewBitmap = new Bitmap(width, height, PixelFormat.Format32bppArgb);
            ClearPreview();

            this.ClientSize = new Size(width, height);
            this.Text = "Новый рисунок";

            this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
        }

        public FormDocument() : this(1, 1) { }

        // Очистка временного холста
        private void ClearPreview()
        {
            if (previewBitmap == null) return;

            var g = Graphics.FromImage(previewBitmap);
            g.Clear(Color.Transparent);
        }

        public void LoadImage(string filePath)
        {
            try
            {
                bitmap?.Dispose();
                //Загружаем копию файла, чтобы избежать его блокировки при сохранении
                var stream = new MemoryStream(File.ReadAllBytes(filePath));
                bitmap = new Bitmap(stream);
                this.ClientSize = bitmap.Size; // Автонастройка размера
                this.Text = Path.GetFileName(filePath);

                // Временный холст с прозрачным фоном
                previewBitmap = new Bitmap(bitmap.Width, bitmap.Height, PixelFormat.Format32bppArgb);
                ClearPreview();

                Invalidate();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки: {ex.Message}", "Ошибка",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void Save()
        {
            if (string.IsNullOrEmpty(FilePath))
            {
                SaveAs(); // Если файл не сохранён ранее, вызываем Сохранить как
                return;
            }

            try
            {
                bitmap.Save(FilePath);
                this.Text = Path.GetFileName(FilePath);
                isModified = false; //документ теперь сохранён
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка сохранения: {ex.Message}", "Ошибка",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void SaveAs()
        {
            using (var saveDialog = new SaveFileDialog())
            {
                saveDialog.Filter = "JPEG (*.jpg)|*.jpg|BMP (*.bmp)|*.bmp";
                saveDialog.AddExtension = true;
                saveDialog.Title = "Сохранить изображение";
                saveDialog.FileName = this.Text;

                if (saveDialog.ShowDialog() == DialogResult.OK)
                {
                    FilePath = saveDialog.FileName;
                    Save();
                }
                else
                    // Если пользователь закрыл диалог
                    return;
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (isModified) // Если документ изменён
            {
                DialogResult result = MessageBox.Show(
                    $"Сохранить изменения в файле \"{this.Text}\" перед закрытием?",
                    "Сохранение",
                    MessageBoxButtons.YesNoCancel,
                    MessageBoxIcon.Question
                );

                switch (result)
                {
                    case DialogResult.Yes:
                        Save(); // Сохранить изменения
                        if (string.IsNullOrEmpty(FilePath))
                            e.Cancel = true; // Если файл не был сохранён, отменяем закрытие формы
                        break;

                    case DialogResult.No:
                        // Закрыть без сохранения
                        break;

                    case DialogResult.Cancel:
                        e.Cancel = true; // Отменить закрытие
                        break;

                }
            }

            base.OnFormClosing(e);
        }

        public void ResizeCanvas(int width, int height)
        {
            // Обновляем оба холста
            var newBitmap = new Bitmap(width, height);
            var g = Graphics.FromImage(newBitmap);
            g.Clear(Color.White);
            if (bitmap != null)
                g.DrawImage(bitmap, 0, 0);

            bitmap = newBitmap;

            // Пересоздаём previewBitmap
            previewBitmap = new Bitmap(width, height);
            ClearPreview();

            this.ClientSize = new Size(width, height);
            isModified = true;
            Invalidate();
        }

        public void Filler(Bitmap bitmap, int x, int y, Color fillColor)
        {
            //цвет начального пикселя
            Color targetColor = bitmap.GetPixel(x, y);

            //если начальный цвет = цвет заливки, ничего не делаем
            if (targetColor.ToArgb() == fillColor.ToArgb())
                return;

            //очередь
            Queue<Point> pixels = new Queue<Point>();
            pixels.Enqueue(new Point(x, y));

            int curX, curY;

            Cursor = Cursors.WaitCursor;
            while (pixels.Count > 0)
            {
                Point currentPixel = pixels.Dequeue();

                curX = currentPixel.X;
                curY = currentPixel.Y;

                // Проверяем, находится ли текущий пиксель в пределах изображения
                if (curX < 0 || curX >= bitmap.Width ||
                    curY < 0 || curY >= bitmap.Height)
                    continue;

                // Если цвет текущего пикселя совпадает с целевым цветом, заливаем его
                if (bitmap.GetPixel(curX, curY).ToArgb() == targetColor.ToArgb())
                {
                    bitmap.SetPixel(curX, curY, fillColor);

                    // Добавляем соседние пиксели в очередь
                    pixels.Enqueue(new Point(curX + 1, curY));
                    pixels.Enqueue(new Point(curX - 1, curY));
                    pixels.Enqueue(new Point(curX, curY + 1));
                    pixels.Enqueue(new Point(curX, curY - 1));
                }
            }
            Cursor = FillerCursor;
        }

        private void DrawCylinder(Graphics g, int x1, int y1, int x2, int y2, Color color, int lineWidth, bool isFilled)
        {
            int width = Math.Abs(x2 - x1);
            int height = Math.Abs(y2 - y1);
            int ellipseHeight = height / 5; // Высота эллипсов

            int x = Math.Min(x1, x2);
            int y = Math.Min(y1, y2);

            Pen pen = new Pen(color, lineWidth);
            SolidBrush brush = new SolidBrush(color);

            // Верхний эллипс
            if (isFilled)
                g.FillEllipse(brush, x, y, width, ellipseHeight);
            else
                g.DrawEllipse(pen, x, y, width, ellipseHeight);

            // Боковые стенки
            if (isFilled)
            {
                g.DrawLine(new Pen(brush), x, y + ellipseHeight / 2, x, y + height + 2);
                g.DrawLine(new Pen(brush), x + width, y + ellipseHeight / 2, x + width, y + height + 2);
            }
            else
            {
                g.DrawLine(pen, x, y + ellipseHeight / 2, x, y + height + 2);
                g.DrawLine(pen, x + width, y + ellipseHeight / 2, x + width, y + height + 2);
            }

            if (width > 0 && ellipseHeight > 0)
            {
                if (isFilled)
                {
                    g.FillEllipse(brush, x, y + height - ellipseHeight / 2, width, ellipseHeight);
                    g.FillRectangle(brush, x, y + ellipseHeight / 2, width, height - ellipseHeight / 2);
                }
                else
                {
                    // Нижняя дуга
                    Rectangle lowerEllipseRect = new Rectangle(x, y + height - ellipseHeight / 2, width, ellipseHeight);
                    g.DrawArc(pen, lowerEllipseRect, 0, 182);
                }
            }
        }

        private void DrawTextOnBitmap()
        {
            Graphics g = Graphics.FromImage(bitmap);

            g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
            g.DrawString(
                textBoxPaint.Text,
                MainForm.SelectedFont,
                new SolidBrush(MainForm.CurrentColor),
                textBoxPaint.Location);

            Invalidate();
        }

        private void FormDocument_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Point transformedPoint = TransformMouseCoordinates(new Point(e.X, e.Y));
                int newX = transformedPoint.X;
                int newY = transformedPoint.Y;

                switch (MainForm.Tool)
                {
                    case Tools.Brush:
                        {
                            oldX = newX;
                            oldY = newY;
                            break;
                        }
                    case Tools.Line:
                        {
                            oldX = newX;
                            oldY = newY;
                            ClearPreview();
                            break;
                        }
                    case Tools.Ellipse:
                        {
                            oldX = newX;
                            oldY = newY;
                            ClearPreview();
                            break;
                        }
                    case Tools.Eraser:
                        {
                            oldX = newX;
                            oldY = newY;
                            break;
                        }
                    case Tools.Filler:
                        {
                            Filler(bitmap, newX, newY, MainForm.CurrentColor);
                            Invalidate();
                            break;
                        }
                    case Tools.Cylinder:
                        {
                            oldX = newX;
                            oldY = newY;
                            ClearPreview();
                            break;
                        }
                    case Tools.Text:
                        {
                            textBoxPaint.SetBounds(newX, newY - 15, 100, 30);
                            textBoxPaint.Font = MainForm.SelectedFont;
                            textBoxPaint.ForeColor = MainForm.CurrentColor;
                            textBoxPaint.Visible = true;
                            textBoxPaint.Focus();
                            textBoxPaint.Text = "";
                            break;
                        }
                }
            }
        }

        private void FormDocument_MouseMove(object sender, MouseEventArgs e)
        {
            //Координаты в статусЛайн
            if (e.X < bitmap.Width && e.Y < bitmap.Height)
                ((MainForm)MdiParent)?.UpdateMouseCoordinates(e.X, e.Y);
            else
            {
                ((MainForm)MdiParent)?.UpdateMouseCoordinates(null, null);
            }

            if (e.Button == MouseButtons.Left)
            {
                Point transformedPoint = TransformMouseCoordinates(new Point(e.X, e.Y));
                int newX = transformedPoint.X;
                int newY = transformedPoint.Y;

                switch (MainForm.Tool)
                {
                    case Tools.Brush:
                        {
                            var g = Graphics.FromImage(bitmap);

                            int brushSize = MainForm.CurrentWidth;
                            SolidBrush brush = new SolidBrush(MainForm.CurrentColor);
                            Pen pen = new Pen(brush, brushSize);

                            // концы линий закруглённые
                            pen.StartCap = System.Drawing.Drawing2D.LineCap.Round;
                            pen.EndCap = System.Drawing.Drawing2D.LineCap.Round;
                            g.DrawLine(pen, oldX, oldY, newX, newY);
                            oldX = newX;
                            oldY = newY;

                            isModified = true;
                            break;
                        }
                    case Tools.Line:
                        {
                            ClearPreview();
                            var g = Graphics.FromImage(previewBitmap);
                            g.DrawLine(new
                                Pen(MainForm.CurrentColor, MainForm.CurrentWidth),
                                oldX, oldY, newX, newY);
                            break;
                        }
                    case Tools.Ellipse:
                        {
                            ClearPreview();
                            var g = Graphics.FromImage(previewBitmap);

                            if (!MainForm.IsFilledShape)
                                g.DrawEllipse(new
                                    Pen(MainForm.CurrentColor, MainForm.CurrentWidth),
                                    oldX, oldY, newX - oldX, newY - oldY);
                            else
                                g.FillEllipse(
                                new SolidBrush(MainForm.CurrentColor),
                                oldX, oldY, newX - oldX, newY - oldY);
                            break;
                        }
                    case Tools.Eraser:
                        {
                            var g = Graphics.FromImage(bitmap);

                            int eraserSize = MainForm.CurrentWidth; // Размер ластика
                            SolidBrush brush = new SolidBrush(Color.White);
                            Pen pen = new Pen(brush, eraserSize);

                            // концы линий закруглённые
                            pen.StartCap = System.Drawing.Drawing2D.LineCap.Round;
                            pen.EndCap = System.Drawing.Drawing2D.LineCap.Round;
                            g.DrawLine(pen, oldX, oldY, newX, newY);
                            oldX = newX;
                            oldY = newY;

                            isModified = true;
                            break;
                        }
                    case Tools.Cylinder:
                        {
                            ClearPreview();
                            var g = Graphics.FromImage(previewBitmap);

                            DrawCylinder(g, oldX, oldY, newX, newY, MainForm.CurrentColor, MainForm.CurrentWidth, MainForm.IsFilledShape);
                            break;
                        }
                }
            }

            Invalidate();
        }

        private void FormDocument_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Point transformedPoint = TransformMouseCoordinates(new Point(e.X, e.Y));
                int newX = transformedPoint.X;
                int newY = transformedPoint.Y;

                switch (MainForm.Tool)
                {
                    case Tools.Line:
                        {
                            var g = Graphics.FromImage(bitmap);
                            g.DrawLine(
                                new Pen(MainForm.CurrentColor, MainForm.CurrentWidth),
                                oldX, oldY, newX, newY);

                            isModified = true;
                            ClearPreview();
                            Invalidate();
                            break;
                        }
                    case Tools.Ellipse:
                        {
                            var g = Graphics.FromImage(bitmap);
                            if (!MainForm.IsFilledShape)
                                g.DrawEllipse(
                                    new Pen(MainForm.CurrentColor, MainForm.CurrentWidth),
                                    oldX, oldY, newX - oldX, newY - oldY);
                            else
                                g.FillEllipse(
                                    new SolidBrush(MainForm.CurrentColor),
                                    oldX, oldY, newX - oldX, newY - oldY);

                            isModified = true;

                            ClearPreview();
                            Invalidate();
                            break;
                        }
                    case Tools.Cylinder:
                        {
                            var g = Graphics.FromImage(bitmap);
                            DrawCylinder(g, oldX, oldY, newX, newY, MainForm.CurrentColor, MainForm.CurrentWidth, MainForm.IsFilledShape);

                            isModified = true;

                            ClearPreview();
                            Invalidate();
                            break;
                        }
                }
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            e.Graphics.ScaleTransform(BitmapScale, BitmapScale);

            e.Graphics.DrawImage(bitmap, 0, 0);
            if (MainForm.Tool == Tools.Line ||
                MainForm.Tool == Tools.Ellipse ||
                MainForm.Tool == Tools.Cylinder)
                e.Graphics.DrawImage(previewBitmap, 0, 0);
        }

        private void FormDocument_MouseEnter(object sender, EventArgs e)
        {
            if (MainForm.Tool == Tools.Brush ||
                MainForm.Tool == Tools.Line ||
                MainForm.Tool == Tools.Ellipse ||
                MainForm.Tool == Tools.Cylinder)

                Cursor = Cursors.Cross;

            else if (MainForm.Tool == Tools.Eraser)
                Cursor = EraserCursor;
            else if (MainForm.Tool == Tools.Filler)
                Cursor = FillerCursor;
            else if (MainForm.Tool == Tools.Text)
                Cursor = Cursors.IBeam;
            else
                Cursor = Cursors.Default;
        }

        #region Методы текста

        private void TextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                DrawTextOnBitmap();
                textBoxPaint.Visible = false;
                textBoxPaint.Text = "";
            }
        }

        private void textBoxPaint_TextChanged(object sender, EventArgs e)
        {
            using (Graphics g = textBoxPaint.CreateGraphics())
            {
                SizeF textSize = g.MeasureString(textBoxPaint.Text, textBoxPaint.Font);

                int newWidth = (int)textSize.Width + 10;
                int newHeight = textBoxPaint.Height;

                // Проверяем, выходит ли за границы формы
                int rightBoundary = textBoxPaint.Left + newWidth;
                int bottomBoundary = textBoxPaint.Top + newHeight;

                if (rightBoundary > this.ClientSize.Width || bottomBoundary > this.ClientSize.Height)
                {
                    this.ClientSize = new Size(
                        Math.Max(this.ClientSize.Width, rightBoundary + 10),
                        Math.Max(this.ClientSize.Height, bottomBoundary + 10)
                    );
                }

                // Обновляем ширину textBoxPaint
                textBoxPaint.Width = newWidth;
            }
        }

        private void textBoxPaint_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isDragging = true;
                oldX = e.X;
                oldY = e.Y;
            }
        }

        private void textBoxPaint_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDragging)
            {
                int dx = e.X - oldX;
                int dy = e.Y - oldY;

                int newX = textBoxPaint.Left + dx;
                int newY = textBoxPaint.Top + dy;

                // Ограничиваем перемещение в пределах формы
                if (newX >= 0 && newX + textBoxPaint.Width <= this.ClientSize.Width)
                {
                    textBoxPaint.Left = newX;
                }

                if (newY >= 0 && newY + textBoxPaint.Height <= this.ClientSize.Height)
                {
                    textBoxPaint.Top = newY;
                }
            }
            else
            {
                textBoxPaint.Cursor = Cursors.SizeAll;
            }
        }

        private void textBoxPaint_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                isDragging = false;
        }

        #endregion

        public void SetScale(float newScale)
        {
            if (newScale <= 0.1f || newScale > 2.0f) return;

            BitmapScale = newScale;

            AutoScrollMinSize = new Size(
                    (int)(bitmap.Width * BitmapScale),
                    (int)(bitmap.Height * BitmapScale));

            Invalidate();
            Update();

            ((MainForm)MdiParent)?.UpdateScaleIndicators(BitmapScale);
        }

        private Point TransformMouseCoordinates(Point mousePoint)
        {
            Matrix transformMatrix = new Matrix();
            transformMatrix.Scale(BitmapScale, BitmapScale);

            // Преобразуем координаты мыши
            Point[] points = { mousePoint };
            transformMatrix.Invert();
            transformMatrix.TransformPoints(points);
            return points[0];
        }

        private void FormDocument_Activated(object sender, EventArgs e)
        {
            ((MainForm)MdiParent)?.UpdateScaleIndicators(BitmapScale);
        }

        private void FormDocument_MouseLeave(object sender, EventArgs e)
        {
            ((MainForm)MdiParent)?.UpdateMouseCoordinates(null, null);
        }
    }
}

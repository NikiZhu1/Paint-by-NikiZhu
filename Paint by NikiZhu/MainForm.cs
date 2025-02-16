using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Paint_by_NikiZhu
{
    public partial class MainForm : Form
    {
        /// <summary>
        /// ������� ����
        /// </summary>
        public static Color CurrentColor { get; set; }

        /// <summary>
        /// ������� �������
        /// </summary>
        public static int CurrentWidth { get; set; }

        /// <summary>
        /// ������� ����������
        /// </summary>
        public static Tools Tool;

        /// <summary>
        /// �������� ������
        /// </summary>
        public static bool IsFilledShape
        {
            get
            {
                var mainForm = Application.OpenForms.OfType<MainForm>().FirstOrDefault();
                return mainForm?.checkBox_Fill.Checked ?? false;
            }
        }

        /// <summary>
        /// ����� ��� ���������� �����
        /// </summary>
        public static Font SelectedFont { get; private set; } = new Font("Arial", 12);

        public MainForm()
        {
            InitializeComponent();
            CurrentColor = Color.Black;
            CurrentWidth = 5;
            Tool = Tools.Brush;
            trackBar_Width.Value = CurrentWidth;
            label_CurrentWith.Text = $"{CurrentWidth} px";
            label_Scale.Text = "�������: " + Convert.ToInt32(100 * 1.0f).ToString() + "%";
            trackBar_Scale.Value = Convert.ToInt32(100 * 1.0f);
        }

        private void �����ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
            checkBox_Fill.Checked = true;
        }

        private void ����������ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var abt = new FormAbout();
            abt.ShowDialog();
        }

        private void �����ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var sizeForm = new CanvasSizeForm(500, 500))
            {
                if (sizeForm.ShowDialog() == DialogResult.OK)
                {
                    var doc = new FormDocument(sizeForm.CanvasWidth, sizeForm.CanvasHeight);
                    doc.MdiParent = this;
                    doc.Show();
                }
            }
        }

        private void ������������ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var activeDocument = this.ActiveMdiChild as FormDocument;
            if (activeDocument == null)
            {
                ������������ToolStripMenuItem.Enabled = false;
                return;
            }

            using (var resizeForm = new CanvasSizeForm(activeDocument.bitmap.Width, activeDocument.bitmap.Height))
            {
                if (resizeForm.ShowDialog() == DialogResult.OK)
                {
                    activeDocument.ResizeCanvas(resizeForm.CanvasWidth, resizeForm.CanvasHeight);
                }
            }
        }

        private void �������ToolStripMenuItem_DropDownOpening(object sender, EventArgs e)
        {
            ������������ToolStripMenuItem.Enabled = (this.ActiveMdiChild != null);
        }

        private void ����ToolStripMenuItem_DropDownOpening(object sender, EventArgs e)
        {
            ���������ToolStripMenuItem.Enabled = (this.ActiveMdiChild != null);
            ������������ToolStripMenuItem.Enabled = (this.ActiveMdiChild != null);
        }

        private void ���ToolStripMenuItem_DropDownOpening(object sender, EventArgs e)
        {
            �ToolStripMenuItem.Enabled = (this.ActiveMdiChild != null);
            �����ToolStripMenuItem.Enabled = (this.ActiveMdiChild != null);
            ������������ToolStripMenuItem.Enabled = (this.ActiveMdiChild != null);
            ����������ToolStripMenuItem.Enabled = (this.ActiveMdiChild != null);
            ������������������ToolStripMenuItem.Enabled = (this.ActiveMdiChild != null);
            ��ToolStripMenuItem.Enabled = (this.ActiveMdiChild != null);
            �������ToolStripMenuItem.Enabled = (this.ActiveMdiChild != null);
            ���������������ToolStripMenuItem.Enabled = (this.ActiveMdiChild != null);
        }

        private void MainForm_MdiChildActivate(object sender, EventArgs e)
        {
            ������������ToolStripMenuItem.Enabled = (this.ActiveMdiChild != null);
            ���������ToolStripMenuItem.Enabled = (this.ActiveMdiChild != null);
            ������������ToolStripMenuItem.Enabled = (this.ActiveMdiChild != null);
            trackBar_Scale.Enabled = (this.ActiveMdiChild != null);
            if (sender is FormDocument doc)
            {
                UpdateScaleIndicators(doc.BitmapScale);
            }

            if (ActiveMdiChild == null)
                label_Cordinates.Text = "X: � Y: �";

            if (ActiveMdiChild is FormDocument document && document.bitmap != null)
                UpdateBitmapSize(document.bitmap.Width, document.bitmap.Height);
            else
                UpdateBitmapSize(null, null);

        }

        private void �������ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openDialog = new OpenFileDialog();
            openDialog.Filter = "����� JPEG (*.jpeg, *.jpg)|*.jpeg;*.jpg|Windows Bitmap (*.bmp)|*.bmp";
            openDialog.Title = "������� �����������";

            if (openDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    //������ ����� �������� � ��������� �����������
                    var doc = new FormDocument();
                    doc.LoadImage(openDialog.FileName);
                    doc.MdiParent = this;
                    doc.Show();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"������ �������� �����: {ex.Message}", "������",
                                  MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void ���������ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var activeDocument = this.ActiveMdiChild as FormDocument;
            activeDocument.Save();

        }

        private void ������������ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var activeDocument = this.ActiveMdiChild as FormDocument;
            activeDocument.SaveAs();
        }

        private void toolButton_Click(object sender, EventArgs e)
        {
            Button[] buttons = [tool_Brush, tool_Eraser, tool_Filler, tool_Text, tool_Line, tool_Ellipse, tool_Cylinder];
            // ���������� ������� � ���� ������
            foreach (Button btn in buttons)
            {
                btn.FlatAppearance.BorderSize = 0;
            }

            Button clickedButton = sender as Button;
            if (clickedButton != null)
            {
                clickedButton.FlatAppearance.BorderSize = 2;

                // �������� ���������� Tool � ����������� �� ������� ������
                Tool = clickedButton.Name switch
                {
                    "tool_Brush" => Tools.Brush,
                    "tool_Eraser" => Tools.Eraser,
                    "tool_Filler" => Tools.Filler,
                    "tool_Text" => Tools.Text,
                    "tool_Line" => Tools.Line,
                    "tool_Ellipse" => Tools.Ellipse,
                    "tool_Cylinder" => Tools.Cylinder,
                    _ => Tool
                };
            }
        }

        private void button_Color_Click(object sender, EventArgs e)
        {
            Button clickedButton = sender as Button;
            if (clickedButton != null)
            {
                // �������� ������� ���� � ����������� �� ����� ������
                CurrentColor = clickedButton.BackColor;

                var activeDocument = this.ActiveMdiChild as FormDocument;
                if (activeDocument != null)
                    activeDocument.textBoxPaint.ForeColor = clickedButton.BackColor;
            }
        }

        private void button_NewColor_Click(object sender, EventArgs e)
        {
            var dialog = new ColorDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
                CurrentColor = dialog.Color;

            var activeDocument = this.ActiveMdiChild as FormDocument;
            if (activeDocument != null)
                activeDocument.textBoxPaint.ForeColor = dialog.Color;
        }

        private void trackBar_Width_Scroll(object sender, EventArgs e)
        {
            CurrentWidth = trackBar_Width.Value;
            label_CurrentWith.Text = $"{CurrentWidth} px";
        }

        private void �ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }


        private void �����ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void ������������ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void ����������ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void ������������������ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }

        public void UpdateScaleIndicators(float scale)
        {
            label_Scale.Text = $"�������: {scale * 100:F0}%";
            trackBar_Scale.Value = Convert.ToInt32(100 * scale);
        }

        private void scalePlus_Click(object sender, EventArgs e)
        {
            float currentScale;
            var activeDocument = this.ActiveMdiChild as FormDocument;
            if (activeDocument == null)
                return;
            else
                currentScale = activeDocument.BitmapScale;

            if (currentScale <= 2.0f)
            {
                currentScale += 0.1f;
                activeDocument.SetScale(currentScale);

                UpdateScaleIndicators(currentScale);
                activeDocument.Invalidate();
                activeDocument.Update();
            }
        }

        private void scaleMinus_Click(object sender, EventArgs e)
        {
            float currentScale;
            var activeDocument = this.ActiveMdiChild as FormDocument;
            if (activeDocument == null)
                return;
            else
                currentScale = activeDocument.BitmapScale;

            if (currentScale >= 0.1f)
            {
                currentScale -= 0.1f;
                activeDocument.SetScale(currentScale);

                UpdateScaleIndicators(currentScale);
                activeDocument.Invalidate();
                activeDocument.Update();
            }
        }

        private void scaleReset_Click(object sender, EventArgs e)
        {
            float currentScale;
            var activeDocument = this.ActiveMdiChild as FormDocument;
            if (activeDocument == null)
                return;
            else
                currentScale = activeDocument.BitmapScale;

            if (currentScale != 1.0f)
            {
                activeDocument.SetScale(1.0f);

                UpdateScaleIndicators(1.0f);
                activeDocument.Invalidate();
                activeDocument.Update();
            }
        }

        private void trackBar_Scale_Scroll(object sender, EventArgs e)
        {
            var activeDocument = this.ActiveMdiChild as FormDocument;
            if (activeDocument == null)
                return;

            int scaleValue = (trackBar_Scale.Value / 10) * 10;
            trackBar_Scale.Value = scaleValue;

            activeDocument.SetScale(scaleValue / 100.0f);

            // ��������� ����������� ��������
            label_Scale.Text = "�������: " + scaleValue.ToString() + "%";

            activeDocument.Invalidate();
            activeDocument.Update();
        }

        public void UpdateMouseCoordinates(int? x, int? y)
        {
            if (x.HasValue && y.HasValue)
                label_Cordinates.Text = $"X: {x} Y: {y}";
            else
                label_Cordinates.Text = "X: � Y: �";
        }

        public void UpdateBitmapSize(int? width, int? height)
        {
            if (width.HasValue && height.HasValue)
                label_Size.Text = $"{width} * {height}";
            else
                label_Size.Text = "� * �";
        }

        public void UpdateFontButtonState(bool isTextToolActive)
        {
            button_FontChoose.Enabled = isTextToolActive;
        }

        private void button_FontChoose_Click(object sender, EventArgs e)
        {
            FontDialog fontDialog = new FontDialog();

            // ������������� ������� ����� � ������
            fontDialog.Font = SelectedFont;

            if (fontDialog.ShowDialog() == DialogResult.OK)
            {
                SelectedFont = fontDialog.Font; // ��������� ��������� �����

                var activeDocument = this.ActiveMdiChild as FormDocument;
                if (activeDocument != null)
                {
                    activeDocument.textBoxPaint.Font = fontDialog.Font;

                    // ��������� ������ textBoxPaint �� ������ ������
                    Graphics g = activeDocument.textBoxPaint.CreateGraphics();
                    Size textSize = TextRenderer.MeasureText("Wg", fontDialog.Font);
                    activeDocument.textBoxPaint.Height = textSize.Height + 5;
                    activeDocument.textBoxPaint.Width = Math.Max(activeDocument.textBoxPaint.Width, textSize.Width + 10);

                }
            }
        }
    }
}

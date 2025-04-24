using PluginInterface;
using System.Diagnostics.Metrics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Windows.Forms;
using MethodInvoker = System.Windows.Forms.MethodInvoker;

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

        /// <summary>
        /// ����������� �������
        /// </summary>
        Dictionary<string, IPlugin> plugins = new Dictionary<string, IPlugin>();

        string configPath = "plugins_config.json";
        PluginConfig config;

        CancellationTokenSource pluginCancellationSource;
        bool pluginRunning = false;

        void LoadPluginConfig()
        {
            if (File.Exists(configPath))
            {
                string json = File.ReadAllText(configPath);
                config = JsonSerializer.Deserialize<PluginConfig>(json);
            }
            else
            {
                config = new PluginConfig();
            }
        }

        void SavePluginConfig()
        {
            var options = new JsonSerializerOptions
            {
                WriteIndented = true,
                Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping
            };

            string json = JsonSerializer.Serialize(config, options);
            File.WriteAllText(configPath, json);
        }

        public MainForm()
        {
            InitializeComponent();
            FindPlugins();
            CreatePluginsMenu();

            CurrentColor = Color.Black;
            CurrentWidth = 5;
            Tool = Tools.Brush;
            trackBar_Width.Value = CurrentWidth;
            label_CurrentWith.Text = $"{CurrentWidth} px";
            label_Scale.Text = "�������: " + Convert.ToInt32(100 * 1.0f).ToString() + "%";
            trackBar_Scale.Value = Convert.ToInt32(100 * 1.0f);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            // ���������� ��������� � �������� ����� �������� �����
            ShowPluginsInfo();
        }

        private void ShowPluginsInfo()
        {
            if (plugins.Count > 0)
            {
                string LoadedPluginInfo = $"��������� �������� ��� ������������� �����������: {plugins.Count}\n\n";

                int count = 1;
                foreach (var plugin in plugins)
                {
                    LoadedPluginInfo += $"{count}. {plugin.Value.Name}\n";
                    count++;
                }

                this.BeginInvoke((MethodInvoker)delegate
                {
                    MessageBox.Show(
                        LoadedPluginInfo,
                        "�������� ��������",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );
                });
            }
        }

        void FindPlugins()
        {
            LoadPluginConfig();

            // ����� � ���������
            string folder = System.AppDomain.CurrentDomain.BaseDirectory;

            // dll-����� � ���� �����
            string[] files = Directory.GetFiles(folder, "*.dll");

            foreach (string file in files)
                try
                {
                    Assembly assembly = Assembly.LoadFile(file);

                    foreach (Type type in assembly.GetTypes())
                    {
                        if (type.GetInterface("PluginInterface.IPlugin") != null)
                        {
                            IPlugin plugin = (IPlugin)Activator.CreateInstance(type);
                            var configEntry = config.Plugins.FirstOrDefault(p => p.Name == plugin.Name);

                            if (configEntry == null)
                            {
                                configEntry = new PluginConfigEntry { Name = plugin.Name, Enabled = true };
                                config.Plugins.Add(configEntry);
                            }

                            if (configEntry.Enabled)
                                plugins[plugin.Name] = plugin;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("������ �������� �������\n" + ex.Message);
                }

            SavePluginConfig();
        }

        private void CreatePluginsMenu()
        {
            foreach (var p in plugins)
            {
                var item = �������ToolStripMenuItem.DropDownItems.Add(p.Value.Name);
                item.Click += OnPluginClick;
            }
        }

        private async void OnPluginClick(object sender, EventArgs args)
        {
            if (pluginRunning)
            {
                MessageBox.Show("�������� ��� �����������");
                return;
            }

            var activeDocument = this.ActiveMdiChild as FormDocument;
            if (activeDocument == null || activeDocument.bitmap == null)
                return;

            IPlugin plugin = plugins[((ToolStripMenuItem)sender).Text];

            // ������ ����� �����������
            Bitmap original = (Bitmap)activeDocument.bitmap.Clone();
            pluginCancellationSource = new CancellationTokenSource();
            CancellationToken token = pluginCancellationSource.Token;

            try
            {
                pluginRunning = true;
                Cursor = Cursors.WaitCursor;
                activeDocument.Cursor = Cursors.WaitCursor;
                PluginProgress.Visible = true;
                progressBar.Value = 0;

                var progress = new Progress<int>(value =>
                {
                    progressBar.Value = Math.Min(100, Math.Max(0, value));
                });

                // ��������� ������ � ����
                await Task.Run(() =>
                {
                    if (token.IsCancellationRequested)
                        token.ThrowIfCancellationRequested();

                    plugin.Transform(original, token, progress);

                    if (token.IsCancellationRequested)
                        token.ThrowIfCancellationRequested();
                }, token);

                // ����� ���������� � ��������� ��������
                activeDocument.bitmap = original;
                activeDocument.Refresh();
                activeDocument.isModified = true;
            }
            catch (AggregateException aggEx) when (aggEx.InnerExceptions.Any(e => e is OperationCanceledException))
            {
                MessageBox.Show("�������� ���� ��������.");
                original.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show("������ ���������� �������: " + ex.Message);
                original.Dispose();
            }
            finally
            {
                Cursor = Cursors.Default;
                activeDocument.Cursor = Cursors.Default;
                pluginRunning = false;
                pluginCancellationSource.Dispose();
                pluginCancellationSource = null;
                progressBar.Value = 0;
                PluginProgress.Visible = false;
            }
        }

        private void �������ToolStripMenuItem_DropDownOpening(object sender, EventArgs e)
        {
            foreach (ToolStripMenuItem item in �������ToolStripMenuItem.DropDownItems)
            {
                item.Enabled = (this.ActiveMdiChild != null);
            }
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
                    UpdateBitmapSize(resizeForm.CanvasWidth, resizeForm.CanvasHeight);
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

        private void buttonCancelPlugin_Click(object sender, EventArgs e)
        {
            if (pluginRunning && pluginCancellationSource != null)
            {
                pluginCancellationSource.Cancel();
            }
        }
    }
}

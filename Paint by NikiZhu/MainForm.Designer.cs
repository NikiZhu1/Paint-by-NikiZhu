namespace Paint_by_NikiZhu
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            menuStrip1 = new MenuStrip();
            файлToolStripMenuItem = new ToolStripMenuItem();
            новыйToolStripMenuItem = new ToolStripMenuItem();
            открытьToolStripMenuItem = new ToolStripMenuItem();
            toolStripMenuItem1 = new ToolStripSeparator();
            сохранитьToolStripMenuItem = new ToolStripMenuItem();
            сохранитьКакToolStripMenuItem = new ToolStripMenuItem();
            toolStripMenuItem2 = new ToolStripSeparator();
            выходToolStripMenuItem = new ToolStripMenuItem();
            рисунокToolStripMenuItem = new ToolStripMenuItem();
            размерХолстаToolStripMenuItem = new ToolStripMenuItem();
            видToolStripMenuItem = new ToolStripMenuItem();
            кToolStripMenuItem = new ToolStripMenuItem();
            рядомToolStripMenuItem = new ToolStripMenuItem();
            слеваНаправоToolStripMenuItem = new ToolStripMenuItem();
            сверхуВнизToolStripMenuItem = new ToolStripMenuItem();
            упорядочитьВкладкиToolStripMenuItem = new ToolStripMenuItem();
            toolStripMenuItem3 = new ToolStripSeparator();
            маToolStripMenuItem = new ToolStripMenuItem();
            масштабToolStripMenuItem = new ToolStripMenuItem();
            сброситьМасштабToolStripMenuItem = new ToolStripMenuItem();
            фильтрыToolStripMenuItem = new ToolStripMenuItem();
            помощьToolStripMenuItem = new ToolStripMenuItem();
            оПрограммеToolStripMenuItem = new ToolStripMenuItem();
            flowLayoutPanel1 = new FlowLayoutPanel();
            button_Color1 = new Button();
            button_Color2 = new Button();
            button_Color3 = new Button();
            button_Color4 = new Button();
            button_Color5 = new Button();
            button_Color6 = new Button();
            button_Color7 = new Button();
            button_Color8 = new Button();
            button_Color9 = new Button();
            button_Color10 = new Button();
            button_Color11 = new Button();
            button_Color12 = new Button();
            button_Color13 = new Button();
            button_Color14 = new Button();
            toolTip1 = new ToolTip(components);
            tool_Brush = new Button();
            tool_Eraser = new Button();
            tool_Filler = new Button();
            tool_Text = new Button();
            tool_Line = new Button();
            tool_Ellipse = new Button();
            tool_Cylinder = new Button();
            panel1 = new Panel();
            tableLayoutPanel4 = new TableLayoutPanel();
            tableLayoutPanel3 = new TableLayoutPanel();
            checkBox_Fill = new CheckBox();
            button_FontChoose = new Button();
            flowLayoutPanel3 = new FlowLayoutPanel();
            label2 = new Label();
            tableLayoutPanel2 = new TableLayoutPanel();
            button_NewColor = new Button();
            label1 = new Label();
            tableLayoutPanel1 = new TableLayoutPanel();
            trackBar_Width = new TrackBar();
            label_CurrentWith = new Label();
            label3 = new Label();
            statusStrip1 = new StatusStrip();
            label_Cordinates = new ToolStripStatusLabel();
            label_Size = new ToolStripStatusLabel();
            tableLayoutPanel5 = new TableLayoutPanel();
            trackBar_Scale = new TrackBar();
            label_Scale = new Label();
            menuStrip1.SuspendLayout();
            flowLayoutPanel1.SuspendLayout();
            panel1.SuspendLayout();
            tableLayoutPanel4.SuspendLayout();
            tableLayoutPanel3.SuspendLayout();
            flowLayoutPanel3.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)trackBar_Width).BeginInit();
            statusStrip1.SuspendLayout();
            tableLayoutPanel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)trackBar_Scale).BeginInit();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { файлToolStripMenuItem, рисунокToolStripMenuItem, видToolStripMenuItem, фильтрыToolStripMenuItem, помощьToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.MdiWindowListItem = видToolStripMenuItem;
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1089, 24);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // файлToolStripMenuItem
            // 
            файлToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { новыйToolStripMenuItem, открытьToolStripMenuItem, toolStripMenuItem1, сохранитьToolStripMenuItem, сохранитьКакToolStripMenuItem, toolStripMenuItem2, выходToolStripMenuItem });
            файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            файлToolStripMenuItem.Size = new Size(48, 20);
            файлToolStripMenuItem.Text = "&Файл";
            файлToolStripMenuItem.DropDownOpening += файлToolStripMenuItem_DropDownOpening;
            // 
            // новыйToolStripMenuItem
            // 
            новыйToolStripMenuItem.Name = "новыйToolStripMenuItem";
            новыйToolStripMenuItem.ShortcutKeyDisplayString = "";
            новыйToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.N;
            новыйToolStripMenuItem.Size = new Size(235, 22);
            новыйToolStripMenuItem.Text = "&Создать...";
            новыйToolStripMenuItem.Click += новыйToolStripMenuItem_Click;
            // 
            // открытьToolStripMenuItem
            // 
            открытьToolStripMenuItem.Name = "открытьToolStripMenuItem";
            открытьToolStripMenuItem.ShortcutKeyDisplayString = "";
            открытьToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.O;
            открытьToolStripMenuItem.Size = new Size(235, 22);
            открытьToolStripMenuItem.Text = "&Открыть...";
            открытьToolStripMenuItem.Click += открытьToolStripMenuItem_Click;
            // 
            // toolStripMenuItem1
            // 
            toolStripMenuItem1.Name = "toolStripMenuItem1";
            toolStripMenuItem1.Size = new Size(232, 6);
            // 
            // сохранитьToolStripMenuItem
            // 
            сохранитьToolStripMenuItem.Name = "сохранитьToolStripMenuItem";
            сохранитьToolStripMenuItem.ShortcutKeyDisplayString = "";
            сохранитьToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.S;
            сохранитьToolStripMenuItem.Size = new Size(235, 22);
            сохранитьToolStripMenuItem.Text = "Со&хранить";
            сохранитьToolStripMenuItem.Click += сохранитьToolStripMenuItem_Click;
            // 
            // сохранитьКакToolStripMenuItem
            // 
            сохранитьКакToolStripMenuItem.Name = "сохранитьКакToolStripMenuItem";
            сохранитьКакToolStripMenuItem.ShortcutKeyDisplayString = "";
            сохранитьКакToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.Shift | Keys.S;
            сохранитьКакToolStripMenuItem.Size = new Size(235, 22);
            сохранитьКакToolStripMenuItem.Text = "Сохранить &как...";
            сохранитьКакToolStripMenuItem.Click += сохранитьКакToolStripMenuItem_Click;
            // 
            // toolStripMenuItem2
            // 
            toolStripMenuItem2.Name = "toolStripMenuItem2";
            toolStripMenuItem2.Size = new Size(232, 6);
            // 
            // выходToolStripMenuItem
            // 
            выходToolStripMenuItem.AccessibleDescription = "В";
            выходToolStripMenuItem.Name = "выходToolStripMenuItem";
            выходToolStripMenuItem.ShortcutKeys = Keys.Alt | Keys.F4;
            выходToolStripMenuItem.Size = new Size(235, 22);
            выходToolStripMenuItem.Text = "&Выход";
            выходToolStripMenuItem.Click += выходToolStripMenuItem_Click;
            // 
            // рисунокToolStripMenuItem
            // 
            рисунокToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { размерХолстаToolStripMenuItem });
            рисунокToolStripMenuItem.Name = "рисунокToolStripMenuItem";
            рисунокToolStripMenuItem.Size = new Size(65, 20);
            рисунокToolStripMenuItem.Text = "&Рисунок";
            рисунокToolStripMenuItem.DropDownOpening += рисунокToolStripMenuItem_DropDownOpening;
            // 
            // размерХолстаToolStripMenuItem
            // 
            размерХолстаToolStripMenuItem.Name = "размерХолстаToolStripMenuItem";
            размерХолстаToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.W;
            размерХолстаToolStripMenuItem.Size = new Size(208, 22);
            размерХолстаToolStripMenuItem.Text = "Ра&змер холста...";
            размерХолстаToolStripMenuItem.Click += размерХолстаToolStripMenuItem_Click;
            // 
            // видToolStripMenuItem
            // 
            видToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { кToolStripMenuItem, рядомToolStripMenuItem, слеваНаправоToolStripMenuItem, сверхуВнизToolStripMenuItem, упорядочитьВкладкиToolStripMenuItem, toolStripMenuItem3, маToolStripMenuItem, масштабToolStripMenuItem, сброситьМасштабToolStripMenuItem });
            видToolStripMenuItem.Name = "видToolStripMenuItem";
            видToolStripMenuItem.Size = new Size(39, 20);
            видToolStripMenuItem.Text = "&Вид";
            видToolStripMenuItem.DropDownOpening += видToolStripMenuItem_DropDownOpening;
            // 
            // кToolStripMenuItem
            // 
            кToolStripMenuItem.Name = "кToolStripMenuItem";
            кToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.D1;
            кToolStripMenuItem.Size = new Size(233, 22);
            кToolStripMenuItem.Text = "&Каскадом";
            кToolStripMenuItem.Click += кToolStripMenuItem_Click;
            // 
            // рядомToolStripMenuItem
            // 
            рядомToolStripMenuItem.Name = "рядомToolStripMenuItem";
            рядомToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.D2;
            рядомToolStripMenuItem.Size = new Size(233, 22);
            рядомToolStripMenuItem.Text = "&Рядом";
            рядомToolStripMenuItem.Click += рядомToolStripMenuItem_Click;
            // 
            // слеваНаправоToolStripMenuItem
            // 
            слеваНаправоToolStripMenuItem.Name = "слеваНаправоToolStripMenuItem";
            слеваНаправоToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.D3;
            слеваНаправоToolStripMenuItem.Size = new Size(233, 22);
            слеваНаправоToolStripMenuItem.Text = "Слева &направо";
            слеваНаправоToolStripMenuItem.Click += слеваНаправоToolStripMenuItem_Click;
            // 
            // сверхуВнизToolStripMenuItem
            // 
            сверхуВнизToolStripMenuItem.Name = "сверхуВнизToolStripMenuItem";
            сверхуВнизToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.D4;
            сверхуВнизToolStripMenuItem.Size = new Size(233, 22);
            сверхуВнизToolStripMenuItem.Text = "Сверху &вниз";
            сверхуВнизToolStripMenuItem.Click += сверхуВнизToolStripMenuItem_Click;
            // 
            // упорядочитьВкладкиToolStripMenuItem
            // 
            упорядочитьВкладкиToolStripMenuItem.Name = "упорядочитьВкладкиToolStripMenuItem";
            упорядочитьВкладкиToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.D5;
            упорядочитьВкладкиToolStripMenuItem.Size = new Size(233, 22);
            упорядочитьВкладкиToolStripMenuItem.Text = "&Упорядочить вкладки";
            упорядочитьВкладкиToolStripMenuItem.Click += упорядочитьВкладкиToolStripMenuItem_Click;
            // 
            // toolStripMenuItem3
            // 
            toolStripMenuItem3.Name = "toolStripMenuItem3";
            toolStripMenuItem3.Size = new Size(230, 6);
            // 
            // маToolStripMenuItem
            // 
            маToolStripMenuItem.Name = "маToolStripMenuItem";
            маToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl +";
            маToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.Oemplus;
            маToolStripMenuItem.Size = new Size(233, 22);
            маToolStripMenuItem.Text = "&Приблизить";
            маToolStripMenuItem.Click += scalePlus_Click;
            // 
            // масштабToolStripMenuItem
            // 
            масштабToolStripMenuItem.Name = "масштабToolStripMenuItem";
            масштабToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl -";
            масштабToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.OemMinus;
            масштабToolStripMenuItem.Size = new Size(233, 22);
            масштабToolStripMenuItem.Text = "&Отдалить";
            масштабToolStripMenuItem.Click += scaleMinus_Click;
            // 
            // сброситьМасштабToolStripMenuItem
            // 
            сброситьМасштабToolStripMenuItem.Name = "сброситьМасштабToolStripMenuItem";
            сброситьМасштабToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.D0;
            сброситьМасштабToolStripMenuItem.Size = new Size(233, 22);
            сброситьМасштабToolStripMenuItem.Text = "&Сбросить масштаб";
            сброситьМасштабToolStripMenuItem.Click += scaleReset_Click;
            // 
            // фильтрыToolStripMenuItem
            // 
            фильтрыToolStripMenuItem.Name = "фильтрыToolStripMenuItem";
            фильтрыToolStripMenuItem.Size = new Size(69, 20);
            фильтрыToolStripMenuItem.Text = "Фильтры";
            фильтрыToolStripMenuItem.DropDownOpening += фильтрыToolStripMenuItem_DropDownOpening;
            // 
            // помощьToolStripMenuItem
            // 
            помощьToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { оПрограммеToolStripMenuItem });
            помощьToolStripMenuItem.Name = "помощьToolStripMenuItem";
            помощьToolStripMenuItem.Size = new Size(68, 20);
            помощьToolStripMenuItem.Text = "&Помощь";
            // 
            // оПрограммеToolStripMenuItem
            // 
            оПрограммеToolStripMenuItem.Name = "оПрограммеToolStripMenuItem";
            оПрограммеToolStripMenuItem.Size = new Size(149, 22);
            оПрограммеToolStripMenuItem.Text = "&О программе";
            оПрограммеToolStripMenuItem.Click += оПрограммеToolStripMenuItem_Click;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Controls.Add(button_Color1);
            flowLayoutPanel1.Controls.Add(button_Color2);
            flowLayoutPanel1.Controls.Add(button_Color3);
            flowLayoutPanel1.Controls.Add(button_Color4);
            flowLayoutPanel1.Controls.Add(button_Color5);
            flowLayoutPanel1.Controls.Add(button_Color6);
            flowLayoutPanel1.Controls.Add(button_Color7);
            flowLayoutPanel1.Controls.Add(button_Color8);
            flowLayoutPanel1.Controls.Add(button_Color9);
            flowLayoutPanel1.Controls.Add(button_Color10);
            flowLayoutPanel1.Controls.Add(button_Color11);
            flowLayoutPanel1.Controls.Add(button_Color12);
            flowLayoutPanel1.Controls.Add(button_Color13);
            flowLayoutPanel1.Controls.Add(button_Color14);
            flowLayoutPanel1.Dock = DockStyle.Fill;
            flowLayoutPanel1.Location = new Point(0, 0);
            flowLayoutPanel1.Margin = new Padding(0);
            flowLayoutPanel1.MinimumSize = new Size(0, 50);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(175, 69);
            flowLayoutPanel1.TabIndex = 5;
            // 
            // button_Color1
            // 
            button_Color1.BackColor = Color.Red;
            button_Color1.FlatAppearance.BorderColor = Color.White;
            button_Color1.FlatStyle = FlatStyle.Flat;
            button_Color1.Location = new Point(0, 0);
            button_Color1.Margin = new Padding(0);
            button_Color1.Name = "button_Color1";
            button_Color1.Size = new Size(25, 25);
            button_Color1.TabIndex = 10;
            button_Color1.UseVisualStyleBackColor = false;
            button_Color1.Click += button_Color_Click;
            // 
            // button_Color2
            // 
            button_Color2.BackColor = Color.DarkOrange;
            button_Color2.FlatAppearance.BorderColor = Color.White;
            button_Color2.FlatStyle = FlatStyle.Flat;
            button_Color2.Location = new Point(25, 0);
            button_Color2.Margin = new Padding(0);
            button_Color2.Name = "button_Color2";
            button_Color2.Size = new Size(25, 25);
            button_Color2.TabIndex = 11;
            button_Color2.UseVisualStyleBackColor = false;
            button_Color2.Click += button_Color_Click;
            // 
            // button_Color3
            // 
            button_Color3.BackColor = Color.Yellow;
            button_Color3.FlatAppearance.BorderColor = Color.White;
            button_Color3.FlatStyle = FlatStyle.Flat;
            button_Color3.Location = new Point(50, 0);
            button_Color3.Margin = new Padding(0);
            button_Color3.Name = "button_Color3";
            button_Color3.Size = new Size(25, 25);
            button_Color3.TabIndex = 12;
            button_Color3.UseVisualStyleBackColor = false;
            button_Color3.Click += button_Color_Click;
            // 
            // button_Color4
            // 
            button_Color4.BackColor = Color.Chartreuse;
            button_Color4.FlatAppearance.BorderColor = Color.White;
            button_Color4.FlatStyle = FlatStyle.Flat;
            button_Color4.Location = new Point(75, 0);
            button_Color4.Margin = new Padding(0);
            button_Color4.Name = "button_Color4";
            button_Color4.Size = new Size(25, 25);
            button_Color4.TabIndex = 13;
            button_Color4.UseVisualStyleBackColor = false;
            button_Color4.Click += button_Color_Click;
            // 
            // button_Color5
            // 
            button_Color5.BackColor = Color.ForestGreen;
            button_Color5.FlatAppearance.BorderColor = Color.White;
            button_Color5.FlatStyle = FlatStyle.Flat;
            button_Color5.Location = new Point(100, 0);
            button_Color5.Margin = new Padding(0);
            button_Color5.Name = "button_Color5";
            button_Color5.Size = new Size(25, 25);
            button_Color5.TabIndex = 7;
            button_Color5.UseVisualStyleBackColor = false;
            button_Color5.Click += button_Color_Click;
            // 
            // button_Color6
            // 
            button_Color6.BackColor = Color.Cyan;
            button_Color6.FlatAppearance.BorderColor = Color.White;
            button_Color6.FlatStyle = FlatStyle.Flat;
            button_Color6.Location = new Point(125, 0);
            button_Color6.Margin = new Padding(0);
            button_Color6.Name = "button_Color6";
            button_Color6.Size = new Size(25, 25);
            button_Color6.TabIndex = 8;
            button_Color6.UseVisualStyleBackColor = false;
            button_Color6.Click += button_Color_Click;
            // 
            // button_Color7
            // 
            button_Color7.BackColor = Color.RoyalBlue;
            button_Color7.FlatAppearance.BorderColor = Color.White;
            button_Color7.FlatStyle = FlatStyle.Flat;
            button_Color7.Location = new Point(150, 0);
            button_Color7.Margin = new Padding(0);
            button_Color7.Name = "button_Color7";
            button_Color7.Size = new Size(25, 25);
            button_Color7.TabIndex = 9;
            button_Color7.UseVisualStyleBackColor = false;
            button_Color7.Click += button_Color_Click;
            // 
            // button_Color8
            // 
            button_Color8.BackColor = Color.Navy;
            button_Color8.FlatAppearance.BorderColor = Color.White;
            button_Color8.FlatStyle = FlatStyle.Flat;
            button_Color8.Location = new Point(0, 25);
            button_Color8.Margin = new Padding(0);
            button_Color8.Name = "button_Color8";
            button_Color8.Size = new Size(25, 25);
            button_Color8.TabIndex = 14;
            button_Color8.UseVisualStyleBackColor = false;
            button_Color8.Click += button_Color_Click;
            // 
            // button_Color9
            // 
            button_Color9.BackColor = Color.MediumPurple;
            button_Color9.FlatAppearance.BorderColor = Color.White;
            button_Color9.FlatStyle = FlatStyle.Flat;
            button_Color9.Location = new Point(25, 25);
            button_Color9.Margin = new Padding(0);
            button_Color9.Name = "button_Color9";
            button_Color9.Size = new Size(25, 25);
            button_Color9.TabIndex = 15;
            button_Color9.UseVisualStyleBackColor = false;
            button_Color9.Click += button_Color_Click;
            // 
            // button_Color10
            // 
            button_Color10.BackColor = Color.Purple;
            button_Color10.FlatAppearance.BorderColor = Color.White;
            button_Color10.FlatStyle = FlatStyle.Flat;
            button_Color10.Location = new Point(50, 25);
            button_Color10.Margin = new Padding(0);
            button_Color10.Name = "button_Color10";
            button_Color10.Size = new Size(25, 25);
            button_Color10.TabIndex = 16;
            button_Color10.UseVisualStyleBackColor = false;
            button_Color10.Click += button_Color_Click;
            // 
            // button_Color11
            // 
            button_Color11.BackColor = Color.Magenta;
            button_Color11.FlatAppearance.BorderColor = Color.White;
            button_Color11.FlatStyle = FlatStyle.Flat;
            button_Color11.Location = new Point(75, 25);
            button_Color11.Margin = new Padding(0);
            button_Color11.Name = "button_Color11";
            button_Color11.Size = new Size(25, 25);
            button_Color11.TabIndex = 17;
            button_Color11.UseVisualStyleBackColor = false;
            button_Color11.Click += button_Color_Click;
            // 
            // button_Color12
            // 
            button_Color12.BackColor = Color.DarkGray;
            button_Color12.FlatAppearance.BorderColor = Color.White;
            button_Color12.FlatStyle = FlatStyle.Flat;
            button_Color12.Location = new Point(100, 25);
            button_Color12.Margin = new Padding(0);
            button_Color12.Name = "button_Color12";
            button_Color12.Size = new Size(25, 25);
            button_Color12.TabIndex = 18;
            button_Color12.UseVisualStyleBackColor = false;
            button_Color12.Click += button_Color_Click;
            // 
            // button_Color13
            // 
            button_Color13.BackColor = Color.Black;
            button_Color13.FlatAppearance.BorderColor = Color.White;
            button_Color13.FlatStyle = FlatStyle.Flat;
            button_Color13.Location = new Point(125, 25);
            button_Color13.Margin = new Padding(0);
            button_Color13.Name = "button_Color13";
            button_Color13.Size = new Size(25, 25);
            button_Color13.TabIndex = 19;
            button_Color13.UseVisualStyleBackColor = false;
            button_Color13.Click += button_Color_Click;
            // 
            // button_Color14
            // 
            button_Color14.BackColor = Color.White;
            button_Color14.FlatAppearance.BorderColor = Color.White;
            button_Color14.FlatStyle = FlatStyle.Flat;
            button_Color14.Location = new Point(150, 25);
            button_Color14.Margin = new Padding(0);
            button_Color14.Name = "button_Color14";
            button_Color14.Size = new Size(25, 25);
            button_Color14.TabIndex = 20;
            button_Color14.UseVisualStyleBackColor = false;
            button_Color14.Click += button_Color_Click;
            // 
            // tool_Brush
            // 
            tool_Brush.BackColor = Color.Transparent;
            tool_Brush.BackgroundImageLayout = ImageLayout.Center;
            tool_Brush.FlatAppearance.BorderColor = SystemColors.Highlight;
            tool_Brush.FlatAppearance.BorderSize = 2;
            tool_Brush.FlatStyle = FlatStyle.Flat;
            tool_Brush.Image = Properties.Resources.paintbrush;
            tool_Brush.ImageAlign = ContentAlignment.TopCenter;
            tool_Brush.Location = new Point(0, 1);
            tool_Brush.Name = "tool_Brush";
            tool_Brush.Size = new Size(81, 90);
            tool_Brush.TabIndex = 7;
            tool_Brush.Text = "Кисть";
            tool_Brush.TextAlign = ContentAlignment.BottomCenter;
            tool_Brush.TextImageRelation = TextImageRelation.ImageAboveText;
            toolTip1.SetToolTip(tool_Brush, "Кисть");
            tool_Brush.UseVisualStyleBackColor = true;
            tool_Brush.Click += toolButton_Click;
            // 
            // tool_Eraser
            // 
            tool_Eraser.BackColor = Color.Transparent;
            tool_Eraser.BackgroundImage = Properties.Resources.eraser;
            tool_Eraser.BackgroundImageLayout = ImageLayout.Center;
            tool_Eraser.FlatAppearance.BorderColor = SystemColors.Highlight;
            tool_Eraser.FlatAppearance.BorderSize = 0;
            tool_Eraser.FlatStyle = FlatStyle.Flat;
            tool_Eraser.Location = new Point(1, 1);
            tool_Eraser.Margin = new Padding(1);
            tool_Eraser.Name = "tool_Eraser";
            tool_Eraser.Size = new Size(30, 30);
            tool_Eraser.TabIndex = 13;
            tool_Eraser.TextAlign = ContentAlignment.BottomCenter;
            tool_Eraser.TextImageRelation = TextImageRelation.ImageAboveText;
            toolTip1.SetToolTip(tool_Eraser, "Ластик");
            tool_Eraser.UseVisualStyleBackColor = true;
            tool_Eraser.Click += toolButton_Click;
            // 
            // tool_Filler
            // 
            tool_Filler.BackColor = Color.Transparent;
            tool_Filler.BackgroundImage = Properties.Resources.fill;
            tool_Filler.BackgroundImageLayout = ImageLayout.Center;
            tool_Filler.FlatAppearance.BorderColor = SystemColors.Highlight;
            tool_Filler.FlatAppearance.BorderSize = 0;
            tool_Filler.FlatStyle = FlatStyle.Flat;
            tool_Filler.Location = new Point(33, 1);
            tool_Filler.Margin = new Padding(1);
            tool_Filler.Name = "tool_Filler";
            tool_Filler.Size = new Size(30, 30);
            tool_Filler.TabIndex = 14;
            tool_Filler.TextAlign = ContentAlignment.BottomCenter;
            tool_Filler.TextImageRelation = TextImageRelation.ImageAboveText;
            toolTip1.SetToolTip(tool_Filler, "Заливка");
            tool_Filler.UseVisualStyleBackColor = true;
            tool_Filler.Click += toolButton_Click;
            // 
            // tool_Text
            // 
            tool_Text.BackColor = Color.Transparent;
            tool_Text.BackgroundImage = Properties.Resources.text;
            tool_Text.BackgroundImageLayout = ImageLayout.Center;
            tool_Text.FlatAppearance.BorderColor = SystemColors.Highlight;
            tool_Text.FlatAppearance.BorderSize = 0;
            tool_Text.FlatStyle = FlatStyle.Flat;
            tool_Text.Location = new Point(65, 1);
            tool_Text.Margin = new Padding(1);
            tool_Text.Name = "tool_Text";
            tool_Text.Size = new Size(30, 30);
            tool_Text.TabIndex = 15;
            tool_Text.TextAlign = ContentAlignment.BottomCenter;
            tool_Text.TextImageRelation = TextImageRelation.ImageAboveText;
            toolTip1.SetToolTip(tool_Text, "Текст");
            tool_Text.UseVisualStyleBackColor = true;
            tool_Text.Click += toolButton_Click;
            // 
            // tool_Line
            // 
            tool_Line.BackColor = Color.Transparent;
            tool_Line.BackgroundImage = Properties.Resources.slash;
            tool_Line.BackgroundImageLayout = ImageLayout.Center;
            tool_Line.FlatAppearance.BorderColor = SystemColors.Highlight;
            tool_Line.FlatAppearance.BorderSize = 0;
            tool_Line.FlatStyle = FlatStyle.Flat;
            tool_Line.Location = new Point(1, 33);
            tool_Line.Margin = new Padding(1);
            tool_Line.Name = "tool_Line";
            tool_Line.Size = new Size(30, 30);
            tool_Line.TabIndex = 16;
            tool_Line.TextAlign = ContentAlignment.BottomCenter;
            tool_Line.TextImageRelation = TextImageRelation.ImageAboveText;
            toolTip1.SetToolTip(tool_Line, "Линия");
            tool_Line.UseVisualStyleBackColor = true;
            tool_Line.Click += toolButton_Click;
            // 
            // tool_Ellipse
            // 
            tool_Ellipse.BackColor = Color.Transparent;
            tool_Ellipse.BackgroundImage = Properties.Resources.circle;
            tool_Ellipse.BackgroundImageLayout = ImageLayout.Center;
            tool_Ellipse.FlatAppearance.BorderColor = SystemColors.Highlight;
            tool_Ellipse.FlatAppearance.BorderSize = 0;
            tool_Ellipse.FlatStyle = FlatStyle.Flat;
            tool_Ellipse.Location = new Point(33, 33);
            tool_Ellipse.Margin = new Padding(1);
            tool_Ellipse.Name = "tool_Ellipse";
            tool_Ellipse.Size = new Size(30, 30);
            tool_Ellipse.TabIndex = 17;
            tool_Ellipse.TextAlign = ContentAlignment.BottomCenter;
            tool_Ellipse.TextImageRelation = TextImageRelation.ImageAboveText;
            toolTip1.SetToolTip(tool_Ellipse, "Эллипс");
            tool_Ellipse.UseVisualStyleBackColor = true;
            tool_Ellipse.Click += toolButton_Click;
            // 
            // tool_Cylinder
            // 
            tool_Cylinder.BackColor = Color.Transparent;
            tool_Cylinder.BackgroundImage = Properties.Resources.cylinder;
            tool_Cylinder.BackgroundImageLayout = ImageLayout.Center;
            tool_Cylinder.FlatAppearance.BorderColor = SystemColors.Highlight;
            tool_Cylinder.FlatAppearance.BorderSize = 0;
            tool_Cylinder.FlatStyle = FlatStyle.Flat;
            tool_Cylinder.Location = new Point(65, 33);
            tool_Cylinder.Margin = new Padding(1);
            tool_Cylinder.Name = "tool_Cylinder";
            tool_Cylinder.Size = new Size(30, 30);
            tool_Cylinder.TabIndex = 18;
            tool_Cylinder.TextAlign = ContentAlignment.BottomCenter;
            tool_Cylinder.TextImageRelation = TextImageRelation.ImageAboveText;
            toolTip1.SetToolTip(tool_Cylinder, "Цилиндр");
            tool_Cylinder.UseVisualStyleBackColor = true;
            tool_Cylinder.Click += toolButton_Click;
            // 
            // panel1
            // 
            panel1.Controls.Add(tableLayoutPanel4);
            panel1.Controls.Add(tableLayoutPanel2);
            panel1.Controls.Add(tableLayoutPanel1);
            panel1.Controls.Add(tool_Brush);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 24);
            panel1.MinimumSize = new Size(0, 90);
            panel1.Name = "panel1";
            panel1.Size = new Size(1089, 90);
            panel1.TabIndex = 7;
            // 
            // tableLayoutPanel4
            // 
            tableLayoutPanel4.ColumnCount = 2;
            tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 135F));
            tableLayoutPanel4.Controls.Add(tableLayoutPanel3, 1, 0);
            tableLayoutPanel4.Controls.Add(flowLayoutPanel3, 0, 0);
            tableLayoutPanel4.Controls.Add(label2, 0, 1);
            tableLayoutPanel4.Location = new Point(87, 0);
            tableLayoutPanel4.Name = "tableLayoutPanel4";
            tableLayoutPanel4.RowCount = 2;
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Absolute, 71F));
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Absolute, 14F));
            tableLayoutPanel4.Size = new Size(233, 90);
            tableLayoutPanel4.TabIndex = 12;
            // 
            // tableLayoutPanel3
            // 
            tableLayoutPanel3.ColumnCount = 1;
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel3.Controls.Add(checkBox_Fill, 0, 1);
            tableLayoutPanel3.Controls.Add(button_FontChoose, 0, 0);
            tableLayoutPanel3.Dock = DockStyle.Fill;
            tableLayoutPanel3.Location = new Point(98, 0);
            tableLayoutPanel3.Margin = new Padding(0);
            tableLayoutPanel3.Name = "tableLayoutPanel3";
            tableLayoutPanel3.RowCount = 2;
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel3.Size = new Size(135, 71);
            tableLayoutPanel3.TabIndex = 13;
            // 
            // checkBox_Fill
            // 
            checkBox_Fill.AutoSize = true;
            checkBox_Fill.Dock = DockStyle.Fill;
            checkBox_Fill.Location = new Point(5, 40);
            checkBox_Fill.Margin = new Padding(5);
            checkBox_Fill.Name = "checkBox_Fill";
            checkBox_Fill.Size = new Size(125, 26);
            checkBox_Fill.TabIndex = 1;
            checkBox_Fill.Text = "Заливка фигуры";
            checkBox_Fill.UseVisualStyleBackColor = true;
            // 
            // button_FontChoose
            // 
            button_FontChoose.Dock = DockStyle.Fill;
            button_FontChoose.Location = new Point(5, 5);
            button_FontChoose.Margin = new Padding(5);
            button_FontChoose.Name = "button_FontChoose";
            button_FontChoose.Size = new Size(125, 25);
            button_FontChoose.TabIndex = 2;
            button_FontChoose.Text = "Изменить шрифт";
            button_FontChoose.UseVisualStyleBackColor = true;
            button_FontChoose.Click += button_FontChoose_Click;
            // 
            // flowLayoutPanel3
            // 
            flowLayoutPanel3.Controls.Add(tool_Eraser);
            flowLayoutPanel3.Controls.Add(tool_Filler);
            flowLayoutPanel3.Controls.Add(tool_Text);
            flowLayoutPanel3.Controls.Add(tool_Line);
            flowLayoutPanel3.Controls.Add(tool_Ellipse);
            flowLayoutPanel3.Controls.Add(tool_Cylinder);
            flowLayoutPanel3.Dock = DockStyle.Fill;
            flowLayoutPanel3.Location = new Point(0, 0);
            flowLayoutPanel3.Margin = new Padding(0);
            flowLayoutPanel3.Name = "flowLayoutPanel3";
            flowLayoutPanel3.Size = new Size(98, 71);
            flowLayoutPanel3.TabIndex = 11;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Bottom;
            label2.AutoSize = true;
            tableLayoutPanel4.SetColumnSpan(label2, 2);
            label2.Location = new Point(75, 75);
            label2.Name = "label2";
            label2.Size = new Size(83, 15);
            label2.TabIndex = 10;
            label2.Text = "Инструменты";
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.ColumnCount = 2;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 68.199234F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 31.800766F));
            tableLayoutPanel2.Controls.Add(flowLayoutPanel1, 0, 0);
            tableLayoutPanel2.Controls.Add(button_NewColor, 1, 0);
            tableLayoutPanel2.Controls.Add(label1, 0, 1);
            tableLayoutPanel2.Location = new Point(494, 0);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 2;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 77.52809F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 22.47191F));
            tableLayoutPanel2.Size = new Size(258, 90);
            tableLayoutPanel2.TabIndex = 11;
            // 
            // button_NewColor
            // 
            button_NewColor.Dock = DockStyle.Fill;
            button_NewColor.Location = new Point(178, 3);
            button_NewColor.Name = "button_NewColor";
            button_NewColor.Size = new Size(77, 63);
            button_NewColor.TabIndex = 6;
            button_NewColor.Text = "Выбрать цвет";
            button_NewColor.UseVisualStyleBackColor = true;
            button_NewColor.Click += button_NewColor_Click;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Bottom;
            label1.AutoSize = true;
            tableLayoutPanel2.SetColumnSpan(label1, 2);
            label1.Location = new Point(112, 75);
            label1.Name = "label1";
            label1.Size = new Size(33, 15);
            label1.TabIndex = 9;
            label1.Text = "Цвет";
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Controls.Add(trackBar_Width, 0, 0);
            tableLayoutPanel1.Controls.Add(label_CurrentWith, 0, 1);
            tableLayoutPanel1.Controls.Add(label3, 0, 2);
            tableLayoutPanel1.Location = new Point(338, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 3;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 36F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 24F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.Size = new Size(138, 90);
            tableLayoutPanel1.TabIndex = 10;
            // 
            // trackBar_Width
            // 
            trackBar_Width.BackColor = SystemColors.Control;
            trackBar_Width.Location = new Point(3, 3);
            trackBar_Width.Maximum = 100;
            trackBar_Width.Minimum = 1;
            trackBar_Width.Name = "trackBar_Width";
            trackBar_Width.RightToLeftLayout = true;
            trackBar_Width.Size = new Size(132, 30);
            trackBar_Width.TabIndex = 8;
            trackBar_Width.TickFrequency = 10;
            trackBar_Width.Value = 1;
            trackBar_Width.Scroll += trackBar_Width_Scroll;
            // 
            // label_CurrentWith
            // 
            label_CurrentWith.Anchor = AnchorStyles.None;
            label_CurrentWith.AutoSize = true;
            label_CurrentWith.Location = new Point(54, 40);
            label_CurrentWith.Name = "label_CurrentWith";
            label_CurrentWith.Size = new Size(29, 15);
            label_CurrentWith.TabIndex = 9;
            label_CurrentWith.Text = "5 px";
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Bottom;
            label3.AutoSize = true;
            label3.Location = new Point(40, 75);
            label3.Name = "label3";
            label3.Size = new Size(58, 15);
            label3.TabIndex = 10;
            label3.Text = "Толщина";
            // 
            // statusStrip1
            // 
            statusStrip1.Items.AddRange(new ToolStripItem[] { label_Cordinates, label_Size });
            statusStrip1.Location = new Point(0, 651);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.RenderMode = ToolStripRenderMode.Professional;
            statusStrip1.Size = new Size(1089, 22);
            statusStrip1.TabIndex = 9;
            statusStrip1.Text = "statusStrip1";
            // 
            // label_Cordinates
            // 
            label_Cordinates.Image = Properties.Resources.coordinate;
            label_Cordinates.Margin = new Padding(0, 3, 50, 2);
            label_Cordinates.Name = "label_Cordinates";
            label_Cordinates.RightToLeft = RightToLeft.No;
            label_Cordinates.Size = new Size(62, 17);
            label_Cordinates.Text = "X: - Y: -";
            label_Cordinates.ToolTipText = "Координаты";
            // 
            // label_Size
            // 
            label_Size.Image = Properties.Resources.dimension;
            label_Size.Name = "label_Size";
            label_Size.Size = new Size(44, 17);
            label_Size.Text = "- * -";
            // 
            // tableLayoutPanel5
            // 
            tableLayoutPanel5.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            tableLayoutPanel5.BackColor = SystemColors.Control;
            tableLayoutPanel5.ColumnCount = 2;
            tableLayoutPanel5.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 45.059288F));
            tableLayoutPanel5.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 54.940712F));
            tableLayoutPanel5.Controls.Add(trackBar_Scale, 1, 0);
            tableLayoutPanel5.Controls.Add(label_Scale, 0, 0);
            tableLayoutPanel5.Location = new Point(816, 649);
            tableLayoutPanel5.Name = "tableLayoutPanel5";
            tableLayoutPanel5.RowCount = 1;
            tableLayoutPanel5.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel5.Size = new Size(253, 24);
            tableLayoutPanel5.TabIndex = 11;
            // 
            // trackBar_Scale
            // 
            trackBar_Scale.Dock = DockStyle.Fill;
            trackBar_Scale.Enabled = false;
            trackBar_Scale.LargeChange = 10;
            trackBar_Scale.Location = new Point(117, 3);
            trackBar_Scale.Maximum = 200;
            trackBar_Scale.Minimum = 10;
            trackBar_Scale.Name = "trackBar_Scale";
            trackBar_Scale.Size = new Size(133, 18);
            trackBar_Scale.SmallChange = 10;
            trackBar_Scale.TabIndex = 0;
            trackBar_Scale.TickFrequency = 10;
            trackBar_Scale.TickStyle = TickStyle.None;
            trackBar_Scale.Value = 100;
            trackBar_Scale.Scroll += trackBar_Scale_Scroll;
            // 
            // label_Scale
            // 
            label_Scale.AutoSize = true;
            label_Scale.BackColor = SystemColors.Control;
            label_Scale.Dock = DockStyle.Fill;
            label_Scale.Location = new Point(3, 0);
            label_Scale.Name = "label_Scale";
            label_Scale.Size = new Size(108, 24);
            label_Scale.TabIndex = 1;
            label_Scale.Text = "Масштаб: 100%";
            label_Scale.TextAlign = ContentAlignment.MiddleRight;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1089, 673);
            Controls.Add(tableLayoutPanel5);
            Controls.Add(statusStrip1);
            Controls.Add(panel1);
            Controls.Add(menuStrip1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            IsMdiContainer = true;
            MainMenuStrip = menuStrip1;
            MinimumSize = new Size(768, 309);
            Name = "MainForm";
            Text = "My Paint";
            toolTip1.SetToolTip(this, "File\r\nHOme\r\n");
            WindowState = FormWindowState.Maximized;
            Load += MainForm_Load;
            MdiChildActivate += MainForm_MdiChildActivate;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            flowLayoutPanel1.ResumeLayout(false);
            panel1.ResumeLayout(false);
            tableLayoutPanel4.ResumeLayout(false);
            tableLayoutPanel4.PerformLayout();
            tableLayoutPanel3.ResumeLayout(false);
            tableLayoutPanel3.PerformLayout();
            flowLayoutPanel3.ResumeLayout(false);
            tableLayoutPanel2.ResumeLayout(false);
            tableLayoutPanel2.PerformLayout();
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)trackBar_Width).EndInit();
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            tableLayoutPanel5.ResumeLayout(false);
            tableLayoutPanel5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)trackBar_Scale).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem файлToolStripMenuItem;
        private ToolStripMenuItem выходToolStripMenuItem;
        private ToolStripMenuItem новыйToolStripMenuItem;
        private ToolStripSeparator toolStripMenuItem1;
        private ToolStripMenuItem помощьToolStripMenuItem;
        private ToolStripMenuItem оПрограммеToolStripMenuItem;
        private ToolStrip toolStrip1;
        private ToolStripMenuItem рисунокToolStripMenuItem;
        private ToolStripMenuItem размерХолстаToolStripMenuItem;
        private ToolStripMenuItem открытьToolStripMenuItem;
        private ToolStripMenuItem сохранитьToolStripMenuItem;
        private ToolStripMenuItem сохранитьКакToolStripMenuItem;
        private ToolStripSeparator toolStripMenuItem2;
        private FlowLayoutPanel flowLayoutPanel1;
        private Button button_Color2;
        private Button button5;
        private Button button6;
        private Button button7;
        private Button button_Color5;
        private Button button_Color6;
        private Button button_Color7;
        private Panel panel1;
        private Button button_NewColor;
        private Button tool_Brush;
        private Label label1;
        private TrackBar trackBar_Width;
        private TableLayoutPanel tableLayoutPanel1;
        private Label label_CurrentWith;
        private Label label3;
        private TableLayoutPanel tableLayoutPanel2;
        private Label label5;
        private FlowLayoutPanel flowLayoutPanel2;
        private Button button_Color1;
        private Button button_Color3;
        private Button button_Color4;
        private Button button_Color8;
        private Button button_Color9;
        private Button button_Color10;
        private Button button_Color11;
        private Button button_Color12;
        private Button button_Color13;
        private Button button_Color14;
        private ToolStripMenuItem видToolStripMenuItem;
        private ToolStripMenuItem кToolStripMenuItem;
        private ToolStripMenuItem слеваНаправоToolStripMenuItem;
        private ToolStripMenuItem сверхуВнизToolStripMenuItem;
        private ToolStripMenuItem упорядочитьВкладкиToolStripMenuItem;
        private ToolStripSeparator toolStripMenuItem3;
        private ToolStripMenuItem маToolStripMenuItem;
        private ToolStripMenuItem масштабToolStripMenuItem;
        private TableLayoutPanel tableLayoutPanel4;
        private Label label2;
        private FlowLayoutPanel flowLayoutPanel3;
        private Button tool_Eraser;
        public ToolTip toolTip1;
        private Button tool_Filler;
        private Button tool_Text;
        private Button tool_Line;
        private Button tool_Ellipse;
        private Button tool_Cylinder;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel label_Cordinates;
        private TableLayoutPanel tableLayoutPanel5;
        public TrackBar trackBar_Scale;
        private Label label_Scale;
        public CheckBox checkBox_Fill;
        private ToolStripMenuItem сброситьМасштабToolStripMenuItem;
        private ToolStripStatusLabel label_Size;
        private ToolStripMenuItem рядомToolStripMenuItem;
        private TableLayoutPanel tableLayoutPanel3;
        public Button button_FontChoose;
        private ToolStripMenuItem фильтрыToolStripMenuItem;
    }
}

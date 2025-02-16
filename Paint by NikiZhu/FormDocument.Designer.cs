namespace Paint_by_NikiZhu
{
    partial class FormDocument
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            textBoxPaint = new RichTextBox();
            SuspendLayout();
            // 
            // textBoxPaint
            // 
            textBoxPaint.BorderStyle = BorderStyle.FixedSingle;
            textBoxPaint.DetectUrls = false;
            textBoxPaint.Location = new Point(12, 12);
            textBoxPaint.Multiline = false;
            textBoxPaint.Name = "textBoxPaint";
            textBoxPaint.ScrollBars = RichTextBoxScrollBars.None;
            textBoxPaint.Size = new Size(153, 70);
            textBoxPaint.TabIndex = 0;
            textBoxPaint.Text = "";
            textBoxPaint.Visible = false;
            textBoxPaint.TextChanged += textBoxPaint_TextChanged;
            textBoxPaint.KeyDown += TextBox_KeyDown;
            textBoxPaint.MouseDown += textBoxPaint_MouseDown;
            textBoxPaint.MouseMove += textBoxPaint_MouseMove;
            textBoxPaint.MouseUp += textBoxPaint_MouseUp;
            // 
            // FormDocument
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            BackColor = SystemColors.AppWorkspace;
            ClientSize = new Size(518, 386);
            Controls.Add(textBoxPaint);
            DoubleBuffered = true;
            Name = "FormDocument";
            ShowIcon = false;
            Text = "FormDocument";
            Activated += FormDocument_Activated;
            MouseDown += FormDocument_MouseDown;
            MouseEnter += FormDocument_MouseEnter;
            MouseLeave += FormDocument_MouseLeave;
            MouseMove += FormDocument_MouseMove;
            MouseUp += FormDocument_MouseUp;
            ResumeLayout(false);
        }

        #endregion

        public RichTextBox textBoxPaint;
    }
}
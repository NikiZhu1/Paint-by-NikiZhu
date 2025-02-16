namespace Paint_by_NikiZhu
{
    partial class CanvasSizeForm
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
            Cancel_button = new Button();
            OK_button = new Button();
            label1 = new Label();
            label2 = new Label();
            numericWidth = new NumericUpDown();
            numericHeight = new NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)numericWidth).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericHeight).BeginInit();
            SuspendLayout();
            // 
            // Cancel_button
            // 
            Cancel_button.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            Cancel_button.Location = new Point(167, 155);
            Cancel_button.Name = "Cancel_button";
            Cancel_button.Size = new Size(75, 23);
            Cancel_button.TabIndex = 3;
            Cancel_button.Text = "Отмена";
            Cancel_button.UseVisualStyleBackColor = true;
            Cancel_button.Click += Cancel_button_Click;
            // 
            // OK_button
            // 
            OK_button.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            OK_button.DialogResult = DialogResult.OK;
            OK_button.Location = new Point(86, 155);
            OK_button.Name = "OK_button";
            OK_button.Size = new Size(75, 23);
            OK_button.TabIndex = 2;
            OK_button.Text = "ОК";
            OK_button.UseVisualStyleBackColor = true;
            OK_button.Click += OK_button_Click;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top;
            label1.AutoSize = true;
            label1.Location = new Point(40, 27);
            label1.Name = "label1";
            label1.Size = new Size(50, 15);
            label1.TabIndex = 3;
            label1.Text = "Высота:";
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Top;
            label2.AutoSize = true;
            label2.Location = new Point(28, 78);
            label2.Name = "label2";
            label2.Size = new Size(62, 15);
            label2.TabIndex = 5;
            label2.Text = "Ширирна:";
            // 
            // numericWidth
            // 
            numericWidth.Location = new Point(96, 76);
            numericWidth.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            numericWidth.Minimum = new decimal(new int[] { 5, 0, 0, 0 });
            numericWidth.Name = "numericWidth";
            numericWidth.Size = new Size(109, 23);
            numericWidth.TabIndex = 1;
            numericWidth.Value = new decimal(new int[] { 100, 0, 0, 0 });
            // 
            // numericHeight
            // 
            numericHeight.Location = new Point(96, 25);
            numericHeight.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            numericHeight.Minimum = new decimal(new int[] { 5, 0, 0, 0 });
            numericHeight.Name = "numericHeight";
            numericHeight.Size = new Size(109, 23);
            numericHeight.TabIndex = 0;
            numericHeight.Value = new decimal(new int[] { 100, 0, 0, 0 });
            // 
            // CanvasSizeForm
            // 
            AcceptButton = OK_button;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = Cancel_button;
            ClientSize = new Size(254, 190);
            Controls.Add(numericHeight);
            Controls.Add(numericWidth);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(OK_button);
            Controls.Add(Cancel_button);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "CanvasSizeForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Размер холста";
            ((System.ComponentModel.ISupportInitialize)numericWidth).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericHeight).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button Cancel_button;
        private Button OK_button;
        private Label label1;
        private Label label2;
        private NumericUpDown numericWidth;
        private NumericUpDown numericHeight;
    }
}
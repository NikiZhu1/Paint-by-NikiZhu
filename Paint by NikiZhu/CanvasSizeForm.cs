using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Paint_by_NikiZhu
{
    public partial class CanvasSizeForm : Form
    {
        public int CanvasWidth { get; private set; }
        public int CanvasHeight { get; private set; }

        public CanvasSizeForm(int currentWidth, int currentHeight)
        {
            InitializeComponent();
            numericHeight.Value = currentHeight;
            numericWidth.Value = currentWidth;
        }

        private void OK_button_Click(object sender, EventArgs e)
        {
            CanvasWidth = (int)numericWidth.Value;
            CanvasHeight = (int)numericHeight.Value;
            DialogResult = DialogResult.OK;
            Close();
        }

        private void Cancel_button_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}

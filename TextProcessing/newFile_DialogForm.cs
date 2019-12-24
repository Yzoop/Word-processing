using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TextProcessing
{
    public partial class newFile_DialogForm : Form
    {
        public newFile_DialogForm()
        {
            InitializeComponent();
        }

        private void Button_CancelNewFile_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Button_AgreeNewFile_Click(object sender, EventArgs e)
        {
            Program.mainFormInstance.startNewFileUploading();
            this.Close();
        }
    }
}

using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImageProcessingTrackbar
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void 開くToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // ダイアログボックスの表示
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                // 選択されたファイルをテキストボックスに表示する
                textselectfilename.Text = openFileDialog1.FileName;

                // 選択された画像ファイルをpictureboxに表示する
                pictureBox1.ImageLocation = textselectfilename.Text;
                pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

            // OpenFileDialog img = new OpenFileDialog();
            // pictureBox1.ImageLocation = Image.FromFile(img.FileName);
        }

        private void 上書き保存ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FileStream fs = new FileStream(openFileDialog1.FileName, FileMode.Open, FileAccess.Read);

            Bitmap bmp = (Bitmap)System.Drawing.Bitmap.FromStream(fs);

            fs.Close();

            pictureBox1.Image = new Bitmap(bmp);
            pictureBox1.Image.Save(textselectfilename.Text);
        }

        private void リセットToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // 画像をクリア
            this.pictureBox1.Image = null;
            // 画像ファイルパスをクリア
            textselectfilename.Text = null;
        }
    }
}

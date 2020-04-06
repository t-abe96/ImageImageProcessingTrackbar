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

        private void 名前を付けて保存ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // フィルターの設定
            saveFileDialog1.Filter = "Image FORMAT(*.JPEG;*.PNG*.GIF)|*.JPEG;*.PNG;*.GIF";
            // ファイル保存のダイアログを表示
            saveFileDialog1.ShowDialog();

            string extension = System.IO.Path.GetExtension(saveFileDialog1.FileName);

            switch (extension.ToUpper())
            { 
                case ".JPEG":
                    // ★★★PictureBoxのイメージをJPEG形式で保存する★★★
                    pictureBox1.Image.Save(saveFileDialog1.FileName, System.Drawing.Imaging.ImageFormat.Jpeg);
                    break;

                case ".PNG":
                    // ★★★PictureBoxのイメージをGIF形式で保存する★★★
                    pictureBox1.Image.Save(saveFileDialog1.FileName, System.Drawing.Imaging.ImageFormat.Png);
                    break;

                case ".GIF":
                    // ★★★PictureBoxのイメージをGIF形式で保存する★★★
                    pictureBox1.Image.Save(saveFileDialog1.FileName, System.Drawing.Imaging.ImageFormat.Gif);
                    break;
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

using System;
using System.Windows.Forms;

using TreeApp.Core.Models;
using TreeApp.Core.Services;

namespace TreeApp.DesktopApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            label1.Text = (trackBar1.Value).ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var random = new Random();
            var treeModel = new TreeModel()
            {
                Height = trackBar1.Value,
                Seed = string.IsNullOrEmpty(textBox1.Text) ? random.Next() : int.Parse(textBox1.Text),
            };

            pictureBox1.Image = TreeDrawerService.DrawTree(treeModel, pictureBox1.Width, pictureBox1.Height);
        }
    }
}

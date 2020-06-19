using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using MaterialSkin.Controls;
using MaterialSkin.Animations;
using MaterialSkin;

namespace ExeToBin
{
    public partial class Form1 : MaterialForm
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void materialCheckBox1_CheckStateChanged(object sender, EventArgs e)
        {
            try
            {
                if (materialCheckBox1.Checked)
                {
                    //convert to base64
                    byte[] buffer = File.ReadAllBytes(textBox1.Text);
                    string base64Encoded = Convert.ToBase64String(buffer);
                    richTextBox1.Text = base64Encoded;
                    materialLabel1.Text = "BASE64";
                }
                else
                {
                    //convert to bytes
                    byte[] buffer = File.ReadAllBytes(textBox1.Text);
                    richTextBox1.Text = BitConverter.ToString(buffer);
                    materialLabel1.Text = "BINARY";
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Select A File First!", "Conversion Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void materialRaisedButton1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog
            {
                InitialDirectory = @"C:\",
                Title = "Select an Exe",

                CheckFileExists = true,
                CheckPathExists = true,

                DefaultExt = "exe",
                Filter = "exe files (*.exe)|*.exe",
                FilterIndex = 2,
                RestoreDirectory = true,

                ReadOnlyChecked = true,
                ShowReadOnly = true
            };

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = openFileDialog1.FileName;
                byte[] buffer = File.ReadAllBytes(textBox1.Text);
                string base64Encoded = Convert.ToBase64String(buffer);
                richTextBox1.Text = base64Encoded;
                materialLabel1.Text = "BASE64";
                MessageBox.Show("Your File Has Been Loaded!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void materialRaisedButton2_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(richTextBox1.Text);
            MessageBox.Show("Data Copied!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}

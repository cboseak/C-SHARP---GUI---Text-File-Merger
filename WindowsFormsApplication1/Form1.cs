using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        private string path1, path2, savePath;

        private List<String> mergeQueue = new List<string> { };
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                StreamReader sr = new StreamReader(openFileDialog1.FileName);
       
                path1 = Path.GetDirectoryName(openFileDialog1.FileName) + "\\" + Path.GetFileName(openFileDialog1.FileName);
                string line;
                textBox1.Text = path1;
                try
                {
                    while ((line = sr.ReadLine()) != null)
                    {
                        mergeQueue.Add(line);
                        textBox4.AppendText(line);
                        textBox4.AppendText("\n");
                        
                    }
                }
                catch
                {
                    MessageBox.Show("Error Reading File!");
                }
                sr.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (openFileDialog2.ShowDialog() == DialogResult.OK)
            {
                StreamReader sr = new StreamReader(openFileDialog2.FileName);
                path1 = Path.GetDirectoryName(openFileDialog2.FileName) + "\\" + Path.GetFileName(openFileDialog2.FileName);
                string line;
                textBox2.Text = path1;
                try
                {
                    while ((line = sr.ReadLine()) != null)
                    {
                        mergeQueue.Add(line);
                        textBox5.AppendText(line);
                        textBox5.AppendText("\n");

                    }
                }
                catch
                {
                    MessageBox.Show("Error Reading File!");
                }
                sr.Close();
            }
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if(saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                savePath = Path.GetDirectoryName(saveFileDialog1.FileName) + "\\" + Path.GetFileName(saveFileDialog1.FileName);
                textBox3.Text = savePath;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            foreach(var line in mergeQueue)
            {
                textBox6.AppendText(line);
                textBox6.AppendText("\n");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if(comboBox1.SelectedIndex == 0)
            {
                textBox6.Clear();
                var results =
                    from i in mergeQueue
                    orderby i ascending
                    select i;
                foreach (var line in results)
                {
                    textBox6.AppendText(line);
                    textBox6.AppendText("\n");
                }
            }
            else if (comboBox1.SelectedIndex == 1)
            {
                textBox6.Clear();
                var results =
                    from i in mergeQueue
                    orderby i descending
                    select i;
                foreach (var line in results)
                {
                    textBox6.AppendText(line);
                    textBox6.AppendText("\n");
                }
            }

        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(File.Create(savePath)))
                {
                    sw.Write(textBox6.Text);

                    MessageBox.Show("Output File Written!" + "\n" + savePath);
                }
            }
            catch
            {
                MessageBox.Show("Please specify output file directory before saving");
            }

        }


    }
}

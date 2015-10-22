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
        private string path1, path2;
        private List<String> mergeQueue = new List<string> { };
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {

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



        private void label1_Click(object sender, EventArgs e)
        {

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
                string save = saveFileDialog1.FileName;

   
            }
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            //string pathOf = Path.GetDirectoryName();
            //textBox1.Text = 
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            foreach(var line in mergeQueue)
            {
                textBox6.AppendText(line);
                textBox6.AppendText("\n");
            }
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
 
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if(comboBox1.SelectedIndex == 0)
            {
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

        }

    }
}

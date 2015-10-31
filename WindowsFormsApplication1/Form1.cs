using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

/*********************************************************************************
 * Author:      Chris Boseak - Cboseak@gmail.com
 * Description: A program that takes 2 input text files and lets
 *              the user manipulate them before saving to a
 *              merged output file. Both files are read, line by line, into a 
 *              list of strings. The list is then able to be sorted and 
 *              manipulated before it is written to the output file.
 * ******************************************************************************/

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        private string pathOfFile, savePath;

        //This is a list of strings that will contains the lines as they are pulled
        //out of the input files.
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
       
                //this is the path of the first input file, saved in a string, so that it
                //can be used anywhere that it is needed.
                pathOfFile = Path.GetDirectoryName(openFileDialog1.FileName) + "\\" + Path.GetFileName(openFileDialog1.FileName);
                string line;

                //textbox that shows the file path in the GUI. We will
                //set it equal to the variable that we previously declared
                textBox1.Text = pathOfFile;
                try
                {
                    //set line(string var) to current line while current line is not null
                    while ((line = sr.ReadLine()) != null)
                    {
                        //while current line is not null, add to list that was 
                        //previously declared. Also add each line to the display
                        //for the tab that corresponds to the file
                        mergeQueue.Add(line);
                        textBox4.AppendText(line);
                        textBox4.AppendText("\n");
                        
                    }
                }
                //just incase there is an issue reading the file. I may later implement
                //a more specific exception handling systes.
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

                //this is the path of the second input file, saved in a string, so that it
                //can be used anywhere that it is needed.
                pathOfFile = Path.GetDirectoryName(openFileDialog2.FileName) + "\\" + Path.GetFileName(openFileDialog2.FileName);
                string line;
                textBox2.Text = pathOfFile;
                try
                {
                    //set line(string var) to current line while current line is not null
                    while ((line = sr.ReadLine()) != null)
                    {
                        //while current line is not null, add to list that was 
                        //previously declared. Also add each line to the display
                        //for the tab that corresponds to the file
                        mergeQueue.Add(line);
                        textBox5.AppendText(line);
                        textBox5.AppendText("\n");

                    }
                }
                //just incase there is an issue reading the file. I may later implement
                //a more specific exception handling systes.
                catch
                {
                    MessageBox.Show("Error Reading File!");
                }
                sr.Close();
            }
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //this saves the path of the file needing to be saved to the savePath
            //variable so it can be inserted into anywhere that may need the output
            //directory
            if(saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                savePath = Path.GetDirectoryName(saveFileDialog1.FileName) + "\\" + Path.GetFileName(saveFileDialog1.FileName);
                textBox3.Text = savePath;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //This is where the merged list (mergeQueue) is output into the visible box
            //so that the user can remove any unwanted elements or sort before saving to file
            foreach(var line in mergeQueue)
            {
                textBox6.AppendText(line);
                textBox6.AppendText("\n");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //if ascending is selected
            if(comboBox1.SelectedIndex == 0)
            {
                //clear the output box in the GUI
                textBox6.Clear();

                //LINQ query to sort the list of strings to 
                //ascending
                var results =
                    from i in mergeQueue
                    orderby i ascending
                    select i;

                //after sorting this is the foreach
                //loop that will output the strings
                foreach (var line in results)
                {
                    textBox6.AppendText(line);
                    textBox6.AppendText("\n");
                }
            }
            else if (comboBox1.SelectedIndex == 1)
            {
                //clear the output box in the GUI
                textBox6.Clear();

                //LINQ query to sort the list of strings to 
                //descending
                var results =
                    from i in mergeQueue
                    orderby i descending
                    select i;

                //after sorting this is the foreach
                //loop that will output the strings
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
                    //foreach line in list of strings (lines from input files)
                    //write them to the output file
                    foreach (var line in mergeQueue)
                    {
                        sw.Write(line + Environment.NewLine);                        
                    }

                    //once operation is completed, give sucess message
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

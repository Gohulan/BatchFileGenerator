using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;


namespace BatchFileGenerator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string command = textBox1.Text;
            string logFileName = textBox2.Text;

            if (string.IsNullOrWhiteSpace(command) || string.IsNullOrWhiteSpace(logFileName))
            {
                MessageBox.Show("Please enter both command and log file name.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Batch Files (*.bat)|*.bat|All Files (*.*)|*.*";
            saveFileDialog.FileName = "RunCommand.bat";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string batchFilePath = saveFileDialog.FileName;

                // Generate the batch file content
                StringBuilder batchFileContent = new StringBuilder();
                batchFileContent.AppendLine("@echo off");
                batchFileContent.AppendLine("echo Running command: " + command + " > " + logFileName);
                batchFileContent.AppendLine(command + " >> " + logFileName);
                batchFileContent.AppendLine("echo Command completed. >> " + logFileName);

                // Save the content to the batch file
                File.WriteAllText(batchFilePath, batchFileContent.ToString());

                MessageBox.Show("Batch file generated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}



using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.IO;


namespace logomaticBinaryConverterCSharp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            System.IO.Stream fileStream;
            // Displays an OpenFileDialog so the user can select a binary file.
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "Binary Files|*.*";
            openFileDialog1.Title = "Select a Saved Logomatic Binary File";

            // Show the Dialog.
            // If the user clicked OK in the dialog and
            // a .txt file was selected, open it.
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                // Put the filename into the filname box
                openedFileBox.Text = openFileDialog1.FileName;
                // Assign the file to a file stream
                fileStream = openFileDialog1.OpenFile();
                // read the file into a byte array
                byte[] binaryArray = readFile(fileStream);
                // decode the byte array into ascii
                List<List<int>> list = decodeBinaryArray(binaryArray);
                displayDecodedData(list);
            }

        }

        private static byte[] readFile(System.IO.Stream fileStream)
        {
            byte[] buffer;
            try
            {
                int length = (int)fileStream.Length;  // get file length
                buffer = new byte[length];            // create buffer
                int count;                            // actual number of bytes read
                int sum = 0;                          // total number of bytes read

                // read until Read method returns 0 (end of the stream has been reached)
                while ((count = fileStream.Read(buffer, sum, length - sum)) > 0)
                    sum += count;  // sum is a buffer offset for next reading
            }
            finally
            {
                fileStream.Close();
            }

            return buffer;

        }

        private List<List<int>> decodeBinaryArray(byte[] binaryArray)
        {
            List<List<int>> list = new List<List<int>>(); // 2D list containing multiple samples per reading
            List<int> subList = new List<int>(); // list containing samples
            int sample = 0;
            int count = 1;

            foreach(byte b in binaryArray) {
                // Check if this is the first byte or the second that makes up a 16 bit signed integer
                if (count % 2 == 0) // if this is the second byte
                {
                    if (((char)b == '$') && ((char)sample == '$'))
                    {
                        if (subList.Count > 0)
                        {
                            list.Add(subList);
                        }
                        subList = new List<int>();
                        sample = 0;
                        count = 0;
                    } // if there are two $ characters found back to back which signifies the end of the line
                    else
                    {
                        sample = sample << 8;
                        sample = sample + b;
                        subList.Add(sample);
                    }
                } // if this is the second byte
                else // else this is the first byte
                {
                    sample = 0;
                    sample = b;
                } // the first byte
                count++;
            }

            return list;
        }

        private void displayDecodedData(List<List<int>> list)
        {
            StringBuilder builder = new StringBuilder();
            int counter = 1;

            foreach (var sublist in list)
            {
                builder.Append(counter++ + ","); // add a column for the count 
                foreach (var value in sublist)
                {
                    // Append each int to the StringBuilder overload.
                    builder.Append(value).Append(","); // add the sample value seperated by a comma
                }
                builder.Remove(builder.Length - 1, 1); // remove the extra comma for the last sample of the line
                builder.Append(System.Environment.NewLine);  // add a new line
            }
            decodedTextBox.Text = builder.ToString();
        }


        private void saveDecodedFileButton_Click(object sender, EventArgs e)
        {

            // Displays an SaveFileDialog so the user can select a csv file.
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();

          
            saveFileDialog1.Filter = "CSV Files|*.csv|Text Files|*.txt";
            saveFileDialog1.Title = "Choose a file to save the text data";

            // Show the Dialog.
            // If the user clicked OK in the dialog and
            // a .txt file was selected, open it.
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {

                // Create an instance of StreamWriter to write text to a file.
                // The using statement also closes the StreamWriter.
                using (StreamWriter sw = new StreamWriter(saveFileDialog1.FileName)) 
                {
                    // Add some text to the file.
                    sw.Write(decodedTextBox.Text);
                    sw.Close();
                }

                MessageBox.Show("File: " + saveFileDialog1.FileName + "\n" + "Saved Successfully", "File Saved", MessageBoxButtons.OK);
            }
        }

    }
}

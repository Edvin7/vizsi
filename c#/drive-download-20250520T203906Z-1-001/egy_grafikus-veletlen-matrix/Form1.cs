using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Schema;

namespace veletlenMatrix
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;

        }

        private void button1_Click(object sender, EventArgs e)
        {

            List<int> matrixOssz = new List<int>();


            richTextBox1.ResetText();

            int height = Convert.ToInt32(Math.Round(numericUpDown2.Value, 0));
            int width = Convert.ToInt32(Math.Round(numericUpDown1.Value, 0));


            int[,] matrixLista = new int[height, width];

            int max = matrixLista[0, 0];
            int maxIndex1 = 0;
            int maxIndex2 = 0;

            /*int min = matrixLista[maxIndex1, maxIndex2];
            int minIndex1 = maxIndex1;
            int minIndex2 = maxIndex2;*/

            Random rnd = new Random();
            
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    matrixLista[i, j] = rnd.Next(1, 1000);
                    matrixOssz.Add(matrixLista[i, j]);

                    if (matrixLista[i, j] > max)
                    {
                        max = matrixLista[i, j];
                        maxIndex1 = i;
                        maxIndex2 = j;

                    }

                   /* if (matrixLista[i, j] < min)
                    {
                        min = matrixLista[i, j];
                        minIndex1 = i;
                        minIndex2 = j;
                    }*/


                }
            }


            this.dataGridView1.ColumnCount = width;

            for (int r = 0; r < height; r++)
            {
                DataGridViewRow row = new DataGridViewRow();
                row.CreateCells(this.dataGridView1);

                for (int c = 0; c < width; c++)
                {
                    row.Cells[c].Value = matrixLista[r, c];
                }

                this.dataGridView1.Rows.Add(row);


            }

            int min = matrixLista[maxIndex1, maxIndex2];
            int minIndex1 = maxIndex1;
            int minIndex2 = maxIndex2;

            for (int i = 0; i < matrixOssz.Count; i++)
            {
                if (matrixOssz[i] < min)
                {
                    min = matrixOssz[i];
 
                }
            }

            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {

                    if (matrixLista[i, j] == min)
                    {
                        minIndex1 = i; minIndex2 = j;

                    }
                }
            }

                        richTextBox1.AppendText("A legnagyobb elem: " + max + "\n");
            richTextBox1.AppendText("A legnagyobb elem indexe: (" + maxIndex1 + "," + maxIndex2 + ")\n");
            richTextBox1.AppendText("A legkisebb elem: " + min + "\n");
            richTextBox1.AppendText("A legkisebb elem indexe: (" + minIndex1 + "," + minIndex2 + ")\n");

        }

    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace veletlenMatrix
{
    public partial class Form1 : Form
    {
        private int[,] matrix;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.AllowUserToAddRows = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int sorok = (int)numericUpDown1.Value;
            int oszlopok = (int)numericUpDown2.Value;


            Random random = new Random();
            matrix = new int[sorok, oszlopok];

            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();

            for (int i = 0; i < oszlopok; i++)
            {
                dataGridView1.Columns.Add("", "");
            }

            dataGridView1.Rows.Add(sorok);

            #region Min/Max keres
            int min = int.MaxValue;
            int max = int.MinValue;
            int minsor = 0;
            int minosz = 0;
            int maxsor = 0;
            int maxosz = 0;
            
            for (int i = 0; i < sorok; i++)
            {
                for (int j = 0; j < oszlopok; j++)
                {
                    matrix[i, j] = random.Next(1000); 
                    dataGridView1.Rows[i].Cells[j].Value = matrix[i, j];

                    if (matrix[i, j] < min)
                    {
                        min = matrix[i, j];
                        minsor = i;
                        minosz = j;
                    }

                    if (matrix[i, j] > max)
                    {
                        max = matrix[i, j];
                        maxsor = i;
                        maxosz = j;
                    }
                }
            }
            richTextBox1.Text = "Legkisebb szám: " + min + 
                                "\n\t sor: " + (minsor + 1) + 
                                "\n\t oszlop: " + (minosz + 1) + 
                                "\n\n" +
                                "Legnagyobb szám: " + max + 
                                "\n\t sor: " + (maxsor + 1) + 
                                "\n\t oszlop: " + (maxosz + 1);
            #endregion
        }
    }
}


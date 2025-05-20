using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SzozroTabla
{
    public partial class Form1 : Form
    {
        private int[,] matrix;

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

            // Create the Check button
            Button checkButton = new Button();
            checkButton.Text = "Ellenőrzés";
            checkButton.Location = new Point(20, 380);
            checkButton.Click += new EventHandler(checkButton_Click);
            this.Controls.Add(checkButton);

            int[,] szorzo = new int[10, 10];

            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    szorzo[i, j] = (i + 1) * (j + 1);
                }
            }

            matrix = new int[11, 11];

            for (int i = 0; i < 11; i++)
            {
                dataGridView1.Columns.Add("", "");
            }

            dataGridView1.Rows.Add(11);

            for (int i = 0; i < 1; i++)
            {
                for (int j = 1; j < 11; j++)
                {
                    dataGridView1[i, j].Value = j;
                }
            }
            for (int i = 1; i < 11; i++)
            {
                for (int j = 0; j < 1; j++)
                {
                    dataGridView1[i, j].Value = i;
                }
            }

            dataGridView1.Rows[3].DefaultCellStyle.BackColor = Color.Yellow;
            dataGridView1.Columns[3].DefaultCellStyle.BackColor = Color.Yellow;

            Random rnd = new Random();
            for (int i = 0; i < 100; i++)
            {
                int ii = rnd.Next(1, 11);
                int jj = rnd.Next(1, 11);

                dataGridView1.Rows[ii].DefaultCellStyle.BackColor = Color.Yellow;
                dataGridView1.Columns[jj].DefaultCellStyle.BackColor = Color.Yellow;
            }
        }

        private void checkButton_Click(object sender, EventArgs e)
        {
            int correctAnswers = 0;
            int wrongAnswers = 0;

            for (int i = 1; i < 11; i++)
            {
                for (int j = 1; j < 11; j++)
                {
                    if (dataGridView1[j, i].Value != null)
                    {
                        string cellValue = dataGridView1[j, i].Value.ToString();
                        int enteredValue;
                        bool isNumber = int.TryParse(cellValue, out enteredValue);

                        int correctValue = i * j;

                        if (isNumber && enteredValue == correctValue)
                        {
                            correctAnswers++;
                        }
                        else
                        {
                            wrongAnswers++;
                        }
                    }
                    else
                    {
                        wrongAnswers++;
                    }
                }
            }
            helyes.Text = correctAnswers.ToString();
            rossz.Text = wrongAnswers.ToString(); 
        }

        private void button1_Click(object sender, EventArgs e)
        {
            System.Environment.Exit(0);
        }

 
    }
}
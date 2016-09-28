using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace metod_Monte_Carlo
{
    public partial class Form1 : Form
    {
        double Ig;
        double Ig2;
        double AbsEr;//абсолютная погрешность
        double dispersion;//дисперсия
        double E;
        Random rand = new Random();
        double a =0;
        double b = Math.PI;
        //решение интеграла
        double I = 1.7653;

        public Form1()
        {
            InitializeComponent();

        }

        public double gFunction(double x)
        {
            return Math.Cos(x);// cosx;// (x + 1) / (x * x);
        }
        private void button3_Click(object sender, EventArgs e)
        {
            dataGridView1.Visible = true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.Visible = false;
        }
        public void Iocenka(int n, out double Ig, out double Ig2)
        {
            Ig = 0;
            Ig2 = 0;
            double Ui = 0;
            double Xi = 0;
            double Gi = 0;
            for (int i = 0; i < n; i++)
            {
                Ui = rand.NextDouble();
                Xi = a + (b - a) * Ui;
                Gi = gFunction(Xi);
                Ig += Gi;
                Ig2 += Gi * Gi;
                dataGridView1.Rows.Add(i + 1, Math.Round(Ui,3),Math.Round( Xi,3), Math.Round(Gi, 3));
            }
            Ig = (b - a) * Ig / n;
            Ig2 = (b - a) * Ig2 / n;
        }
        
        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            I_gLabel.Text = "";
            AbsErLabel.Text = "";
            dispersionLabel.Text = "";
            int n=0;//число испытаний
           
            n=Convert.ToInt32(textBox1.Text);
            Iocenka(n, out Ig, out Ig2);
            AbsEr = Math.Abs(I - Ig);
            dispersion = (b - a) * Ig2 - Ig * Ig;
            E = 1.96*0.0265/Math.Sqrt(n);

            I_gLabel.Text = Math.Round(Ig,4).ToString();
            AbsErLabel.Text = Math.Round(AbsEr,4).ToString();
            dispersionLabel.Text = Math.Round(dispersion, 4).ToString();
            label6.Text = "(" + Math.Round(Ig - E, 4).ToString() + "; " + Math.Round(Ig + E, 4).ToString() + ")"; 
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            
        }

      

       


     
    }
}

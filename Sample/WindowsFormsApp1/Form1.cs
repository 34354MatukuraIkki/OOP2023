﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1 {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        private void btButton_Click(object sender, EventArgs e) {

            //tbAns.Text = (int.Parse(tbNum1.Text) + int.Parse(tbNum2.Text)).ToString();

            int num1 = int.Parse(tbNum1.Text);
            int num2 = int.Parse(tbNum2.Text);
            int sum = num1 + num2;
            tbAns.Text = sum.ToString();
        }

        private void button1_Click(object sender, EventArgs e) {

            //int x = (int)nudX.Value;
            //int y = (int)nudY.Value;
            //int z = 1;

            //for (int i = 0; i < y; i++)
            //{
            //    z = z * x;
            //}

            //tbPow.Text = z.ToString();

            tbPow.Text = Math.Pow((double)nudX.Value , (double)nudY.Value).ToString();
        }
    }
}

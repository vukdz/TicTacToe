﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TicTacToe
{
    public partial class P1chName : Form
    {
        public string name { get; set; }

        public P1chName(string name)
        {
            this.name = name;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            name = textBox1.Text;
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using com.calitha.commons;
using com.calitha.goldparser;

namespace gui
{
    public partial class Form1 : Form
    {
        MyParser parser;
        public Form1()
        {
            InitializeComponent();
            parser = new MyParser("table.cgt", listBox1);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            parser.Parse(textBox1.Text);

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

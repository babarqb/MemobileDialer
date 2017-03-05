using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace MemobileDialer
{
    public partial class Form1 : Form
    {

        private StringBuilder sb;
        private SerialPort sp = new SerialPort();


        public Form1()
        {
            InitializeComponent();

            sb = new StringBuilder();
            foreach (object portName in SerialPort.GetPortNames())
                this.PortSE.Items.Add(portName);
            PortSE.SelectedIndex = -1;
            PortSE.Text = "Select";
        }



        private void btnSend_Click(object sender, EventArgs e)
        {
            this.sp.PortName = this.PortSE.Text;
            this.sp.Close();
            Thread.Sleep(1000);
            if (this.PortSE.Text == "Select")
            {
                int num1 = (int)MessageBox.Show("Please Select Port !", "Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                this.sp.Open();
                Thread.Sleep(1000);
                this.sp.Write("at+creg?\r\n");
                Thread.Sleep(500);
                this.sp.Write("atd" + this.PHONN.Text + ";\r\n");
                Thread.Sleep(1000);
                int num2 = (int)MessageBox.Show("Success !", "Message", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                this.sp.Close();
            }
        }

        private void R_Click(object sender, EventArgs e)
        {
            if (SerialPort.GetPortNames().Length < 1)
            {
                PortSE.Text = "Select";
                return;
            }

            this.PortSE.DataSource = (object)SerialPort.GetPortNames();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            PortSE.SelectedItem = "Select";

        }

        private void button3_Click(object sender, EventArgs e)
        {
            PHONN.Text = sb.Append("1").ToString();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            PHONN.Text = sb.Append("2").ToString();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            PHONN.Text = sb.Append("3").ToString();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            PHONN.Text = sb.Append("4").ToString();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            PHONN.Text = sb.Append("5").ToString();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            PHONN.Text = sb.Append("6").ToString();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            PHONN.Text = sb.Append("7").ToString();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            PHONN.Text = sb.Append("8").ToString();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            PHONN.Text = sb.Append("9").ToString();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            PHONN.Text = sb.Append("0").ToString();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            if (PHONN.Text == "")
            {
                return;
            }
            PHONN.Text = sb.Remove(sb.Length - 1, 1).ToString();
        }

        private void button14_Click(object sender, EventArgs e)
        {

            PHONN.Text = "";
            sb.Remove(0, sb.Length);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Process.Start("devmgmt.msc");
        }
    }
}

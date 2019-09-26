using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Test
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnAddPP_Click(object sender, EventArgs e)
        {
            wccGraph1.AddPairPoint(Double.Parse(tbX.Text), Double.Parse(tbY.Text), Int16.Parse(tbCN.Text));
        }

        private void btnDrawC_Click(object sender, EventArgs e)
        {
            wccGraph1.DrawCurve(Int16.Parse(tbCN.Text));
        }

        private void btnRemoveC_Click(object sender, EventArgs e)
        {
            wccGraph1.RemoveCurve(Int16.Parse(tbCN.Text));
        }

        private void button7_Click(object sender, EventArgs e)
        {
            labXY.Text = wccGraph1.PullX(Int16.Parse(tbPullCN.Text), Int16.Parse(tbPullInd.Text)).ToString() + "; " + wccGraph1.PullY(Int16.Parse(tbPullCN.Text), Int16.Parse(tbPullInd.Text)).ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            wccGraph1.SetTitles("Xtt", "Ytt", "Gtt");
            labXY.Text = wccGraph1.PPCount.ToString();
        }        


    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CrystalDecisions.Shared;

namespace phase
{
    public partial class MainForm : Form
    {
        CrystalReport1 cr;
        public MainForm()
        {
            InitializeComponent();
        }

     

        private void Connected_Mode_Click(object sender, EventArgs e)
        {
            connectedForm CF = new connectedForm();
            CF.Show();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            disconnectedForm DF = new disconnectedForm();
            DF.Show();
        }

        private void crystalReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form1 cr = new Form1();
            cr.Show();
     
    
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }
    }
}

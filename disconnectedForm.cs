using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;
namespace phase
{
    public partial class disconnectedForm : Form
    {
        OracleDataAdapter adap;
        OracleCommandBuilder ocb;
        OracleCommandBuilder build;
        DataSet ds;
        string s = " Data Source=orcl; User Id=scott; Password=tiger";
        public disconnectedForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {


        }
/*        private void button1_Click(object sender, EventArgs e)
        {
            string age = "select USERS_ID,USER_EMAIL,USER_PASSWORD,USER_FAVO from USERS u where u.USER_AGE=:n";
            adap = new OracleDataAdapter(age, s);
            adap.SelectCommand.Parameters.Add("n", textBox1.Text);
            ds = new DataSet();
            adap.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
        }

        private void button2_Click(object sender, EventArgs e)
        {
            build = new OracleCommandBuilder(adap);
            adap.Update(ds.Tables[0]);
            MessageBox.Show("3aaaaaaaaaaaaaaaaaaaaaaaaaash");
        }*/

        private void button1_Click_1(object sender, EventArgs e)
        {
            string age = "select USERS_ID,USER_EMAIL,USER_PASSWORD,USER_FAVO from USERS u where u.USER_AGE=:n";
            adap = new OracleDataAdapter(age, s);
            adap.SelectCommand.Parameters.Add("n", textBox1.Text);
            ds = new DataSet();
            adap.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            build = new OracleCommandBuilder(adap);
            adap.Update(ds.Tables[0]);
            MessageBox.Show("DONE");
        }

        private void disconnectedForm_Load(object sender, EventArgs e)
        {

        }
    }
}

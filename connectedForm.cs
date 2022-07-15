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
    public partial class connectedForm : Form
    {
        string ordb = "Data source=orcl; User Id=scott; Password=tiger;";
        OracleConnection conn;
        public connectedForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            conn = new OracleConnection(ordb);
            conn.Open();

            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandText = "select pins_id from pins";
            cmd.CommandType = CommandType.Text;
            OracleDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                cmb_pinId.Items.Add(dr[0]);
            }
            dr.Close();

           // OracleCommand c = new OracleCommand();
           // c.Connection = conn;
            cmd.CommandText = "select users_id from users";
            cmd.CommandType = CommandType.Text;
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                cmb_userID.Items.Add(dr[0]);
                proc_userID.Items.Add(dr[0]);
            }
            dr.Close();

        }

        private void search1_Click(object sender, EventArgs e)
        {
            cmb_PinCreator.Items.Clear();
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandText = @"select us.user_email
                                from users us, pins p
                                WHERE p.user_id = us.users_id and p.category_name = :catName";
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("catName", text_cat.Text.ToString());
            OracleDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                cmb_PinCreator.Items.Add(dr[0].ToString());
            }
            dr.Close();
        }

        private void insert_Click(object sender, EventArgs e)
        {
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandText = @"insert into pins values (:pin_ID, :cat_name, :pin_type, :user_id)";
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("pin_ID", cmb_pinId.Text.ToString());
            cmd.Parameters.Add("cat_name", text_pinCat.Text.ToString());
            cmd.Parameters.Add("pin_type", text_pinType.Text.ToString());
            cmd.Parameters.Add("user_id", cmb_userID.SelectedItem.ToString());

            int q = cmd.ExecuteNonQuery();
            if (q != -1)
            {
                cmb_pinId.Items.Add(cmb_pinId.Text.ToString());
                cmb_pinId.Text = "";
                text_pinCat.Text = "";
                text_pinType.Text = "";
                cmb_userID.Text = "";
                MessageBox.Show("new pin is added");
            }
        }

        private void proc_search_Click(object sender, EventArgs e)
        {
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandText = "GetUserFav";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("id", proc_userID.Text);
            cmd.Parameters.Add("fav", OracleDbType.Varchar2,2000, null,ParameterDirection.Output);
            int r = cmd.ExecuteNonQuery();
            if(r != -1)
            {
                MessageBox.Show("success");
            }
            proc_userFav.Text = cmd.Parameters["fav"].Value.ToString();
        }

        private void sys_search_Click(object sender, EventArgs e)
        {
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandText = "getCatName";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("title", sys_pinType.Text);
            cmd.Parameters.Add("cat", OracleDbType.RefCursor, ParameterDirection.Output);
            OracleDataReader dr = cmd.ExecuteReader();
            while(dr.Read())
            {
                sys_catOut.Items.Add(dr[0]);
            }
            dr.Close();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            connectedForm f = new connectedForm();
            f.Show();
        }

        private void proc_userID_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}

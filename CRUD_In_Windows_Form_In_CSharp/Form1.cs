using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CRUD_In_Windows_Form_In_CSharp
{
    public partial class Form1 : Form
    {
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-TKUISVD;Initial Catalog=StudentDBWindowsForm;Integrated Security=True");
        SqlCommand cmd;
        SqlDataAdapter sda;
        int ID = 0;
        public Form1()
        {
            InitializeComponent();
            loadStudent();
        }

     
        private void loadStudent()
        {
            con.Open();
            sda = new SqlDataAdapter("select * from Student",con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            StudentGridView.DataSource = dt;
            con.Close();

        }

        private void StudentGridView_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            ID = Convert.ToInt32(StudentGridView.Rows[e.RowIndex].Cells[0].Value.ToString());

             nameTxt.Text= StudentGridView.Rows[e.RowIndex].Cells[1].Value.ToString();
            emailTxt.Text =StudentGridView.Rows[e.RowIndex].Cells[2].Value.ToString();
            addressTxt.Text =StudentGridView.Rows[e.RowIndex].Cells[3].Value.ToString();
        }

        private void updateBtn_Click(object sender, EventArgs e)
        {
            if(nameTxt.Text!="" && emailTxt.Text!="" && addressTxt.Text != "")
            {
                cmd = new SqlCommand("update Student Set Name=@name,Email=@email,Address=@address where ID=@id",con);
                con.Open();
                cmd.Parameters.AddWithValue("@id",ID);
                cmd.Parameters.AddWithValue("@name", nameTxt.Text);
                cmd.Parameters.AddWithValue("@email", emailTxt.Text);
                cmd.Parameters.AddWithValue("@address", addressTxt.Text);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Successfully Updated.");
                con.Close();
                loadStudent();
                clear();

            }
            else
            {
                MessageBox.Show("Field can not be null or empty ....");
            }
        }
       private void clear()
        {
            nameTxt.Text = "";
            emailTxt.Text = "";
            addressTxt.Text = "";
        }

        private void deleteBtn_Click(object sender, EventArgs e)
        {
            if (ID != 0)
            {
                cmd = new SqlCommand("delete Student where ID=@id",con);
                con.Open();
                cmd.Parameters.AddWithValue("@id",ID);
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show(ID+" no id has been deleted");
                loadStudent();
                clear();
            }
            else
            {
                MessageBox.Show("ID can not be null");
            }
        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            if (nameTxt.Text != "" && emailTxt.Text != "" && addressTxt.Text != "")
            {
                cmd = new SqlCommand("insert into Student(Name,Email,Address) values(@name,@email,@address)", con);
                con.Open();
             
                cmd.Parameters.AddWithValue("@name", nameTxt.Text);
                cmd.Parameters.AddWithValue("@email", emailTxt.Text);
                cmd.Parameters.AddWithValue("@address", addressTxt.Text);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Successfully Added.");
                con.Close();
                loadStudent();
                clear();

            }
            else
            {
                MessageBox.Show("Field can not be null or empty ....");
            }
        }
    }
}

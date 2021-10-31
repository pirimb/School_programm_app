using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;

namespace School_App
{
    public partial class Form3Students : Form
    {
        string classNumber = null;
        private SqlConnection sqlConnection = null;

        public Form3Students(string number)
        {
            InitializeComponent();
            classNumber = number;
        }

        private void Form3Students_Load(object sender, EventArgs e)
        {
            sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["School_DB"].ConnectionString);

            sqlConnection.Open();

            labelCN.Text = classNumber;

            SqlDataAdapter dataAdapter = new SqlDataAdapter($"select firstName,lastName from students left join classes on students.classId = classes.classId where classNumber = '{classNumber}'", sqlConnection);

            DataTable dataTable = new DataTable();

            dataAdapter.Fill(dataTable);

            dataGridView1.DataSource = dataTable;
        }
    }
}

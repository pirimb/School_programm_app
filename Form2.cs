using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace School_App
{
    public partial class Form2 : Form
    {
        private SqlConnection sqlConnection = null;

        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["School_DB"].ConnectionString);

            sqlConnection.Open();

            SqlDataAdapter dataAdapter = new SqlDataAdapter($"select day,classNumber,roomNumber,firstName as teacherName, subjectName from day_class left join days on day_class.dayId = days.dayId left join classes on day_class.classId = classes.classId left join rooms on day_class.roomId = rooms.roomId left join teachers on day_class.teacherId = Teachers.teacherId left join subjects on teachers.subjectId = Subjects.subjectId where day='{labelF2.Text}' ", sqlConnection);

            DataTable dataTable = new DataTable();

            dataAdapter.Fill(dataTable);

            dataGridView1.DataSource = dataTable;
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            string classNumber = dataGridView1.Rows[e.RowIndex].Cells["classNumber"].Value.ToString();

            Form3Students studentsF3 = new Form3Students(classNumber);
            studentsF3.ShowDialog();
        }
    }
}

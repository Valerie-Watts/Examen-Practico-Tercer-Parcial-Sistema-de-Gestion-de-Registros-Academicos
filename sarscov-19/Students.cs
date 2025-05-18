using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sarscov_19
{
    public partial class Students: Form
    {
        DataTable table = new DataTable("table");
        List<Student> students = new List<Student>();
         
       
        int index; 

        public Students()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
            table.Columns.Add("Student name", typeof(string));
            table.Columns.Add("ID", typeof(int));
            table.Columns.Add("Average", typeof(float));
            dataGridView1.DataSource = table;
            
        }


        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
             
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String name = textBox1.Text;
            string ID = textBox2.Text;
            float average = Convert.ToSingle(textBox3.Text);

            Student s = new Student
            {
                name = name,
                matricula = ID,
                promedio = average,
            };

            students.Add(s);

            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();

            MessageBox.Show("You have entered: " + name + " into the grid.");

            table.Rows.Add(name,ID,average);

            

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (students.Count == 0)
            {
                MessageBox.Show("No students to sort.");
                return;
            }

            Algorithms.QuickSort(students);

            table.Clear();

            foreach (Student s in students)
            {
                table.Rows.Add(s.name, s.matricula, s.promedio);
            }

            MessageBox.Show("Students sorted successfully.");
        }


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            index = e.RowIndex;
            DataGridViewRow row = dataGridView1.Rows[index];
            textBox1.Text = row.Cells[0].Value.ToString();
            textBox2.Text = row.Cells[1].Value.ToString();
            textBox3.Text = row.Cells[2].Value.ToString();
        }

        private void label7_Click_1(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged_1(object sender, EventArgs e)
        {
            

            
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            bool found;
            string target = textBox4.Text;

            if (string.IsNullOrEmpty(target))
            {
                MessageBox.Show("Please enter an ID number.");
                return;
            }

            found = Algorithms.LinearSearchMatricula(students, target);

            if (!found)
            {
                MessageBox.Show("Student ID not found.");
                textBox4.Clear();
                return;
            }

            textBox4.Clear();
            MessageBox.Show("The student with the ID " + target + " exists.");
            
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Cells[1].Value != null && row.Cells[1].Value.ToString() == target)
                {
                    row.Selected = true;
                    dataGridView1.CurrentCell = row.Cells[0];
                    return;
                }
            }

        }

        private void button5_Click(object sender, EventArgs e)
        {
            DataGridViewRow newdata = dataGridView1.Rows[index];
            newdata.Cells[0].Value = textBox1.Text;
            newdata.Cells[1].Value = textBox2.Text;
            newdata.Cells[2].Value = textBox3.Text;

        }

        private void button7_Click(object sender, EventArgs e)
        {
            index = dataGridView1.CurrentCell.RowIndex;
            dataGridView1.Rows.RemoveAt(index);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            bool found;
            string target = textBox5.Text;

            if (string.IsNullOrEmpty(target))
            {
                MessageBox.Show("Please enter a student name.");
                return;
            }

            found = Algorithms.LinearSearchName(students, target);

            if (!found)
            {
                MessageBox.Show("Student not found.");
                textBox5.Clear();
                return;
            }

            textBox5.Clear();
            MessageBox.Show("The student with the name " + target + " exists.");
            
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Cells[0].Value != null && row.Cells[0].Value.ToString() == target)
                {
                    row.Selected = true;
                    dataGridView1.CurrentCell = row.Cells[0];
                    return;
                }
            }
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

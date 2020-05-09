using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace Practice
{
    public partial class AddTimetableForm : Form
    {
        String id, role;

        public AddTimetableForm(String id, String role)
        {
            InitializeComponent();
            this.id = id;
            this.role = role;

            for (int i = 0; i < 11; i++)
            {
                classComboBox.Items.Add((i + 1).ToString());
            }
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonExit_MouseEnter(object sender, EventArgs e)
        {
            this.buttonExit.BackColor = Color.FromArgb(232, 98, 69);
        }

        private void buttonExit_MouseLeave(object sender, EventArgs e)
        {
            this.buttonExit.BackColor = Color.FromArgb(182, 182, 182);
        }

        Point prevPoint;
        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - prevPoint.X;
                this.Top += e.Y - prevPoint.Y;
            }
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            if (classComboBox.Text == "")
            {
                MessageBox.Show("Вы не ввели номер класса", "Ошибка");
            }
            else
            {
                String monday = monday1.Text + "," +
                            monday2.Text + "," +
                            monday3.Text + "," +
                            monday4.Text + "," +
                            monday5.Text + "," +
                            monday6.Text;
                String tuesday = tuesday1.Text + "," +
                                 tuesday2.Text + "," +
                                 tuesday3.Text + "," +
                                 tuesday4.Text + "," +
                                 tuesday5.Text + "," +
                                 tuesday6.Text;
                String wednesday = wednesday1.Text + "," +
                                   wednesday2.Text + "," +
                                   wednesday3.Text + "," +
                                   wednesday4.Text + "," +
                                   wednesday5.Text + "," +
                                   wednesday6.Text;
                String thursday = thursday1.Text + "," +
                                  thursday2.Text + "," +
                                  thursday3.Text + "," +
                                  thursday4.Text + "," +
                                  thursday5.Text + "," +
                                  thursday6.Text;
                String friday = friday1.Text + "," +
                                friday2.Text + "," +
                                friday3.Text + "," +
                                friday4.Text + "," +
                                friday5.Text + "," +
                                friday6.Text;
                String saturday = saturday1.Text + "," +
                                  saturday2.Text + "," +
                                  saturday3.Text + "," +
                                  saturday4.Text + "," +
                                  saturday5.Text + "," +
                                  saturday6.Text;


                Database database = new Database();
                MySqlCommand command = new MySqlCommand
                    ("INSERT INTO `timetable` (`monday`, `tuesday`, `wednesday`, `thursday`, `friday`, `saturday`, `class`)" +
                    " VALUES (@monday, @tuesday, @wednesday, @thursday, @friday, @saturday, @class);", database.getConnection());
                command.Parameters.AddWithValue("@monday", monday);
                command.Parameters.AddWithValue("@tuesday", tuesday);
                command.Parameters.AddWithValue("@wednesday", wednesday);
                command.Parameters.AddWithValue("@thursday", thursday);
                command.Parameters.AddWithValue("@friday", friday);
                command.Parameters.AddWithValue("@saturday", saturday);
                command.Parameters.AddWithValue("@class", classComboBox.Text);
                database.openConnection();
                command.ExecuteNonQuery();
                database.closeConnection();

                MessageBox.Show("Расписание добавлено", "Уведомление");
                this.Close();
            }
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            this.ActiveControl = null;
            prevPoint = new Point(e.X, e.Y);
        }
    }
}

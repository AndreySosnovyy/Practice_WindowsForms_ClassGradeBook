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

namespace Practice
{
    public partial class BookForm : Form
    {
        String id, role;
        int columns = 0;
        int rows = 0;

        public BookForm(String id, String role)
        {
            InitializeComponent();
            this.id = id;
            this.role = role;

            switch (role)
            {
                case "0":
                    this.panel7.Hide();
                    this.markPanel.Hide();
                    this.classComboBox.Hide();
                    this.label6.Hide();
                    break;
                case "1":
                    this.panel7.Hide();
                    //this.subjectComboBox.Hide();
                    //this.label8.Hide();
                    break;
                case "2":
                    //this.subjectComboBox.Hide();
                    //this.label8.Hide();
                    break;
            }

            this.exitButton.ForeColor = Color.FromArgb(164, 164, 164);
            this.StartPosition = FormStartPosition.CenterScreen;

            for (int i = 0; i < 11; i++)
            {
                classComboBox.Items.Add("" + (i + 1));
            }

            this.monthComboBox.Items.Add("Январь");
            this.monthComboBox.Items.Add("Февраль");
            this.monthComboBox.Items.Add("Март");
            this.monthComboBox.Items.Add("Апрель");
            this.monthComboBox.Items.Add("Май");
            this.monthComboBox.Items.Add("Июнь");
            this.monthComboBox.Items.Add("Июль");
            this.monthComboBox.Items.Add("Август");
            this.monthComboBox.Items.Add("Сентябрь");
            this.monthComboBox.Items.Add("Окнтябрь");
            this.monthComboBox.Items.Add("Ноябрь");
            this.monthComboBox.Items.Add("Декабрь");

            this.subjectComboBox.Items.Add("Физика");
            this.subjectComboBox.Items.Add("Математика");
            this.subjectComboBox.Items.Add("Информатика");
            this.subjectComboBox.Items.Add("Русский язык");
            this.subjectComboBox.Items.Add("География");
            this.subjectComboBox.Items.Add("Физическая культура");

            DateTime now = DateTime.Now;

            switch (now.Month)
            {
                case 1: monthComboBox.Text = "Январь"; break;
                case 2: monthComboBox.Text = "Февраль"; break;
                case 3: monthComboBox.Text = "Март"; break;
                case 4: monthComboBox.Text = "Апрель"; break;
                case 5: monthComboBox.Text = "Май"; break;
                case 6: monthComboBox.Text = "Июнь"; break;
                case 7: monthComboBox.Text = "Июль"; break;
                case 8: monthComboBox.Text = "Август"; break;
                case 9: monthComboBox.Text = "Сентябрт"; break;
                case 10: monthComboBox.Text = "Октябрь"; break;
                case 11: monthComboBox.Text = "Ноябрь"; break;
                case 12: monthComboBox.Text = "Декабрь"; break;
            }

            monthComboBox.Text = now.Month.ToString();

            if (role == "0")
            {
                Database database = new Database();
                MySqlCommand command = new MySqlCommand
                    ("SELECT `class` FROM `student` WHERE id = @id", database.getConnection());
                command.Parameters.AddWithValue("@id", id);
                database.openConnection();
                MySqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    classComboBox.Text = reader.GetValue(0).ToString();
                }
                reader.Close();
                database.closeConnection();
            }

            if (role == "1" || role == "2")
            {
                Database database = new Database();
                MySqlCommand command = new MySqlCommand
                    ("SELECT `subject` FROM `teachers` WHERE id = @id", database.getConnection());
                command.Parameters.AddWithValue("@id", id);
                database.openConnection();
                MySqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    this.subjectComboBox.Text = reader.GetValue(0).ToString();
                }
                reader.Close();
                database.closeConnection();
            }
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
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

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            this.ActiveControl = null;
            prevPoint = new Point(e.X, e.Y);
        }

        private void exitButton_MouseEnter(object sender, EventArgs e)
        {
            this.exitButton.ForeColor = Color.FromArgb(0, 0, 0);
        }

        private void exitButton_MouseLeave(object sender, EventArgs e)
        {
            this.exitButton.ForeColor = Color.FromArgb(164, 164, 164);
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            this.Close();
            LoginForm loginForm = new LoginForm();
            loginForm.Show();
        }

        private void adsPanel_Click(object sender, EventArgs e)
        {
            this.Close();
            AdsForm adsForm = new AdsForm(id, role);
            adsForm.Show();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            this.Close();
            AdsForm adsForm = new AdsForm(id, role);
            adsForm.Show();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
            AdsForm adsForm = new AdsForm(id, role);
            adsForm.Show();
        }

        private void timetablePanel_Click(object sender, EventArgs e)
        {
            this.Close();
            TimetableForm timetableForm = new TimetableForm(id, role);
            timetableForm.Show();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            this.Close();
            TimetableForm timetableForm = new TimetableForm(id, role);
            timetableForm.Show();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.Close();
            TimetableForm timetableForm = new TimetableForm(id, role);
            timetableForm.Show();
        }

        private void markPanel_Click(object sender, EventArgs e)
        {
            this.Close();
            MarkForm markForm = new MarkForm(id, role);
            markForm.Show();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            this.Close();
            MarkForm markForm = new MarkForm(id, role);
            markForm.Show();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            this.Close();
            MarkForm markForm = new MarkForm(id, role);
            markForm.Show();
        }

        private void panel7_Click(object sender, EventArgs e)
        {
            this.Close();
            EditForm editForm = new EditForm(id, role);
            editForm.Show();
        }

        private void editPanel_Click(object sender, EventArgs e)
        {
            this.Close();
            EditForm editForm = new EditForm(id, role);
            editForm.Show();
        }

        private void showButton_Click(object sender, EventArgs e)
        {
            switch (this.monthComboBox.Text)
            {
                case "Январь":
                case "Март":
                case "Май":
                case "Июль":
                case "Август":
                case "Октябрь":
                case "Декабрь":
                    columns = 31 + 1;
                    break;
                case "Апрель":
                case "Июнь":
                case "Сентябрь":
                case "Ноябрь":
                    columns = 30 + 1;
                    break;

                case "Февраль":
                    columns = 28 + 1;
                    break;
            }

            Database database = new Database();
            MySqlCommand command = new MySqlCommand
                ("SELECT `id`, COUNT(*) FROM `student` WHERE `class` = @class", database.getConnection());
            command.Parameters.AddWithValue("@class", this.classComboBox.Text);
            database.openConnection();
            MySqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                rows = 1 + Int32.Parse(reader.GetValue(1).ToString());
            }
            reader.Close();
            database.closeConnection();

            table.ColumnCount = columns;
            table.RowCount = rows;

            MessageBox.Show(columns + " " + rows);

            // заполнение ячеек лейблами

            // заполнение дат и ФИО

            // заполнение каждой ячейки
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            this.Close();
            EditForm editForm = new EditForm(id, role);
            editForm.Show();
        }
    }
}

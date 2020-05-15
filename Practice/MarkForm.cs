using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Practice
{
    public partial class MarkForm : Form
    {
        String id, role;

        public MarkForm(String id, String role)
        {
            InitializeComponent();
            this.id = id;
            this.role = role;

            this.exitButton.ForeColor = Color.FromArgb(164, 164, 164);

            switch (role)
            {
                case "0":
                    this.panel7.Hide();
                    this.markPanel.Hide();
                    break;
                case "1":
                    this.panel7.Hide();
                    break;
            }

            for (int i = 0; i < 11; i++)
            {
                classComboBox.Items.Add("" + (i + 1));
            }
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            Singleton singleton = Singleton.GetInstance();
            singleton.DeleteTable("example");
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
            int temp = -1;
            for (int i = Application.OpenForms.Count - 1; i >= 0; i--)
            {
                if (Application.OpenForms[i].Name != "LoginForm")
                {
                    Application.OpenForms[i].Close();
                }
                else
                {
                    temp = i;
                }
            }

            if (temp != -1)
            {
                Application.OpenForms[temp].Show();
            }
        }

        private void adsPanel_Click(object sender, EventArgs e)
        {
            Form adsForm = Application.OpenForms[0];
            if (Application.OpenForms["AdsForm"] != null)
            {
                adsForm = Application.OpenForms["AdsForm"];
            }
            else
            {
                adsForm = new AdsForm(id, role);
            }
            adsForm.Left = this.Left;
            adsForm.Top = this.Top;
            adsForm.Show();
            this.Hide();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            Form adsForm = Application.OpenForms[0];
            if (Application.OpenForms["AdsForm"] != null)
            {
                adsForm = Application.OpenForms["AdsForm"];
            }
            else
            {
                adsForm = new AdsForm(id, role);
            }
            adsForm.Left = this.Left;
            adsForm.Top = this.Top;
            adsForm.Show();
            this.Hide();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Form adsForm = Application.OpenForms[0];
            if (Application.OpenForms["AdsForm"] != null)
            {
                adsForm = Application.OpenForms["AdsForm"];
            }
            else
            {
                adsForm = new AdsForm(id, role);
            }
            adsForm.Left = this.Left;
            adsForm.Top = this.Top;
            adsForm.Show();
            this.Hide();
        }

        private void timetablePanel_Click(object sender, EventArgs e)
        {
            Form timetableForm = Application.OpenForms[0];
            if (Application.OpenForms["TimetableForm"] != null)
            {
                timetableForm = Application.OpenForms["TimetableForm"];
            }
            else
            {
                timetableForm = new TimetableForm(id, role);
            }
            timetableForm.Left = this.Left;
            timetableForm.Top = this.Top;
            timetableForm.Show();
            this.Hide();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Form timetableForm = Application.OpenForms[0];
            if (Application.OpenForms["TimetableForm"] != null)
            {
                timetableForm = Application.OpenForms["TimetableForm"];
            }
            else
            {
                timetableForm = new TimetableForm(id, role);
            }
            timetableForm.Left = this.Left;
            timetableForm.Top = this.Top;
            timetableForm.Show();
            this.Hide();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Form timetableForm = Application.OpenForms[0];
            if (Application.OpenForms["TimetableForm"] != null)
            {
                timetableForm = Application.OpenForms["TimetableForm"];
            }
            else
            {
                timetableForm = new TimetableForm(id, role);
            }
            timetableForm.Left = this.Left;
            timetableForm.Top = this.Top;
            timetableForm.Show();
            this.Hide();
        }

        private void logPanel_Click(object sender, EventArgs e)
        {
            Form bookForm = Application.OpenForms[0];
            if (Application.OpenForms["BookForm"] != null)
            {
                bookForm = Application.OpenForms["BookForm"];
            }
            else
            {
                bookForm = new BookForm(id, role);
            }
            bookForm.Left = this.Left;
            bookForm.Top = this.Top;
            bookForm.Show();
            this.Hide();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            Form bookForm = Application.OpenForms[0];
            if (Application.OpenForms["BookForm"] != null)
            {
                bookForm = Application.OpenForms["BookForm"];
            }
            else
            {
                bookForm = new BookForm(id, role);
            }
            bookForm.Left = this.Left;
            bookForm.Top = this.Top;
            bookForm.Show();
            this.Hide();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Form bookForm = Application.OpenForms[0];
            if (Application.OpenForms["BookForm"] != null)
            {
                bookForm = Application.OpenForms["BookForm"];
            }
            else
            {
                bookForm = new BookForm(id, role);
            }
            bookForm.Left = this.Left;
            bookForm.Top = this.Top;
            bookForm.Show();
            this.Hide();
        }

        private void panel7_Click(object sender, EventArgs e)
        {
            Form editForm = Application.OpenForms[0];
            if (Application.OpenForms["EditForm"] != null)
            {
                editForm = Application.OpenForms["EditForm"];
            }
            else
            {
                editForm = new EditForm(id, role);
            }
            editForm.Left = this.Left;
            editForm.Top = this.Top;
            editForm.Show();
            this.Hide();
        }

        private void editPanel_Click(object sender, EventArgs e)
        {
            Form editForm = Application.OpenForms[0];
            if (Application.OpenForms["EditForm"] != null)
            {
                editForm = Application.OpenForms["EditForm"];
            }
            else
            {
                editForm = new EditForm(id, role);
            }
            editForm.Left = this.Left;
            editForm.Top = this.Top;
            editForm.Show();
            this.Hide();
        }

        private void classComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            int count = 0;

            this.studentComboBox.Items.Clear();
            this.studentComboBox.Text = "";

            Database database = new Database();
            MySqlCommand commandCount = new MySqlCommand
                ("SELECT `id`, COUNT(*) FROM `student` WHERE `class` = @class", database.getConnection());
            commandCount.Parameters.AddWithValue("@class", this.classComboBox.Text);
            database.openConnection();
            MySqlDataReader readerC = commandCount.ExecuteReader();
            if (readerC.Read())
            {
                count = Int32.Parse(readerC.GetValue(1).ToString());
            }
            readerC.Close();
            database.closeConnection();

            MySqlCommand commandNames = new MySqlCommand
                ("SELECT `secondName`, `firstName`, `thirdName` FROM `student` WHERE `class` = @class ORDER BY secondName", database.getConnection());
            commandNames.Parameters.AddWithValue("@class", this.classComboBox.Text);
            database.openConnection();
            MySqlDataReader reader1 = commandNames.ExecuteReader();

            String[] names = new String[count];
            int index = 0;

            while (reader1.Read())
            {
                names[index] = reader1.GetValue(0).ToString() + " " + reader1.GetValue(1).ToString() + " " + reader1.GetValue(2).ToString();
                index++;
            }

            reader1.Close();
            database.closeConnection();

            for (int i = 0; i < count; i++)
            {
                studentComboBox.Items.Add(names[i]);
            }
        }

        private void setMarkButton_Click(object sender, EventArgs e)
        {
            String teachersName = "";
            String subject = "";
            String date = dateTimePicker.Value.ToString();
            date = "" + date[6] + date[7] + date[8] + date[9] + "-" + date[3] + date[4] + "-" + date[0] + date[1];

            Database database = new Database();
            MySqlCommand command = new MySqlCommand
                ("SELECT `subject` FROM `teachers` WHERE id = @id", database.getConnection());
            command.Parameters.AddWithValue("@id", id);
            database.openConnection();
            MySqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                subject = reader.GetValue(0).ToString();
            }
            reader.Close();
            database.closeConnection();

            MySqlCommand commandGetName = new MySqlCommand
                ("SELECT `firstName`, `secondName`, `thirdName` FROM `teachers` WHERE id = @id", database.getConnection());
            commandGetName.Parameters.AddWithValue("@id", id);
            database.openConnection();
            MySqlDataReader reader2 = commandGetName.ExecuteReader();
            if (reader2.Read())
            {
                teachersName = reader2.GetValue(1).ToString() + " " + reader2.GetValue(0).ToString() + " " + reader2.GetValue(2).ToString();
            }
            database.closeConnection();
            reader2.Close();

            if (this.classComboBox.Text == "")
            {
                MessageBox.Show("Вы не выбрали класс!", "Ошибка");
            }
            else if (this.studentComboBox.Text == "")
            {
                MessageBox.Show("Вы не выбрали ученика!", "Ошибка");
            }
            else if (valueField.Text == "")
            {
                MessageBox.Show("Вы не поставили значение!\n" +
                    "Отсутствовал/болел/число от 1 до 5/любое другое.", "Ошибка");
            }
            else
            {
                MySqlCommand commandAdd = new MySqlCommand
                ("INSERT INTO `marks` (`name`, `class`, `mark`, `date`, `subject`, `teachersName`)" +
                " VALUES(@name, @class, @mark, @date, @subject, @teachersName);", database.getConnection());
                commandAdd.Parameters.AddWithValue("@name", this.studentComboBox.Text);
                commandAdd.Parameters.AddWithValue("@class", this.classComboBox.Text);
                commandAdd.Parameters.AddWithValue("@mark", this.valueField.Text);
                commandAdd.Parameters.AddWithValue("@date", date);
                commandAdd.Parameters.AddWithValue("@subject", subject);
                commandAdd.Parameters.AddWithValue("@teachersName", teachersName);
                database.openConnection();
                if (commandAdd.ExecuteNonQuery() > 0)
                {
                    MessageBox.Show("Оценка выставылена", "Уведомление");
                }
                else
                {
                    MessageBox.Show("Не удалось выставить оценку", "Ошибка");
                }
                database.closeConnection();
                reader.Close();
                valueField.Text = "";
            }
        }
    


        private void pictureBox6_Click(object sender, EventArgs e)
        {
            Form editForm = Application.OpenForms[0];
            if (Application.OpenForms["EditForm"] != null)
            {
                editForm = Application.OpenForms["EditForm"];
            }
            else
            {
                editForm = new EditForm(id, role);
            }
            editForm.Left = this.Left;
            editForm.Top = this.Top;
            editForm.Show();
            this.Hide();
        }
    }
}

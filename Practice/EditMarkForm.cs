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
    public partial class EditMarkForm : Form
    {
        String id, role;

        private void editMarkButton_Click(object sender, EventArgs e)
        {
            if(this.classComboBox.Text == "")
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
                String subject = "";
                String date = dateTimePicker.Value.ToString();
                date = "" + date[6] + date[7] + date[8] + date[9] + "-" + date[3] + date[4] + "-" + date[0] + date[1];

                DatabaseSingleton database = DatabaseSingleton.GetInstance();
                MySqlCommand commandEdit = new MySqlCommand
                ("UPDATE `marks` SET `mark` = @mark WHERE `subject` = @subject AND `class` = @class AND " +
                "`name` = @name AND `date` = @date", database.getConnection());
                commandEdit.Parameters.AddWithValue("@name", this.studentComboBox.Text);
                commandEdit.Parameters.AddWithValue("@class", this.classComboBox.Text);
                commandEdit.Parameters.AddWithValue("@mark", this.valueField.Text);
                commandEdit.Parameters.AddWithValue("@date", date);
                commandEdit.Parameters.AddWithValue("@subject", subjectTextBox.Text);
                database.openConnection();

                if (commandEdit.ExecuteNonQuery() > 0)
                {
                    MessageBox.Show("Оценка изменена", "Уведомление");
                }
                else
                {
                    MessageBox.Show("Не удалось изменить оценку", "Ошибка");
                }
                database.closeConnection();
                valueField.Text = "";
            }
        }

        public EditMarkForm(String id, String role)
        {
            InitializeComponent();
            this.id = id;
            this.role = role;

            for (int i = 0; i < 11; i++)
            {
                classComboBox.Items.Add("" + (i + 1));
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

        private void classComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            int count = 0;

            this.studentComboBox.Items.Clear();
            this.studentComboBox.Text = "";

            DatabaseSingleton database = DatabaseSingleton.GetInstance();
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

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            this.ActiveControl = null;
            prevPoint = new Point(e.X, e.Y);
        }
    }
}

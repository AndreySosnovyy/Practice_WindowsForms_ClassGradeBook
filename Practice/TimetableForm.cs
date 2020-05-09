using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Printing;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Practice
{
    public partial class TimetableForm : Form
    {
        String id, role;
        int ind = 0;
        String[] lesson;
        String globalId = "";
        String dayStr = "";

        private String GetTime(int i)
        {
            switch (i)
            {
                case 0: return "1 урок\n8:00 - 9:15";
                case 1: return "2 урок\n9:25 - 10:10";
                case 2: return "3 урок\n10:30 - 11:15";
                case 3: return "4 урок\n11:25 - 12:10";
                case 4: return "5 урок\n12:25 - 13:10";
                case 5: return "6 урок\n13:20 - 14:05";
            }
            return "";
        }

        private String GetDayEng(String str)
        {
            switch (str)
            {
                case "Понедельник": return "monday";
                case "Вторник": return "tuesday";
                case "Среда": return "wednesday";
                case "Четверг": return "thursday";
                case "Пятница": return "friday";
                case "Суббота": return "saturday";
            }
            return "0";
        }

        public TimetableForm(String id, String role)
        {
            InitializeComponent();
            this.id = id;
            this.role = role;
            String[] lesson;

            this.button1.Hide();
            this.dayComboBox.Hide();

            this.exitButton.ForeColor = Color.FromArgb(164, 164, 164);

            Database database = new Database();
            switch (role)
            {
                case "0":
                    this.panel7.Hide();
                    this.markPanel.Hide();

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
                    label8.Hide();
                    break;
                case "1":
                    this.panel7.Hide();
                    label8.Hide();
                    break;
            }

            label8.Text = "*Чтобы изменить расписание нужно нажать на название предмета, затем\n" +
                " написать новое название и нажать на клавишу 'Enter'";

            for (int i = 0; i < 11; i++)
            {
                this.classComboBox.Items.Add((i + 1).ToString());
            }

            this.dayComboBox.Items.Add("Понедельник");
            this.dayComboBox.Items.Add("Вторник");
            this.dayComboBox.Items.Add("Среда");
            this.dayComboBox.Items.Add("Четверг");
            this.dayComboBox.Items.Add("Пятница");
            this.dayComboBox.Items.Add("Суббота");

            table.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;

            for (int i = 0; i < 6; i++)
            {
                Label label = new Label();
                label.Text = GetTime(i);
                label.Font = new Font("Times New Roman", 14F, FontStyle.Regular);
                label.AutoSize = true;
                label.TextAlign = ContentAlignment.MiddleCenter;
                this.table.Controls.Add(label, 0, i);

            }
        }


        private int GetDay(String str)
        {
            switch(str)
            {
                case "Понедельник": return 1;
                case "Вторник": return 2;
                case "Среда": return 3;
                case "Четверг": return 4;
                case "Пятница": return 5;
                case "Суббота": return 6;
            }
            return 0;
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

        private void markPanel_Click(object sender, EventArgs e)
        {
            Form markForm = Application.OpenForms[0];
            if (Application.OpenForms["MarkForm"] != null)
            {
                markForm = Application.OpenForms["MarkForm"];
            }
            else
            {
                markForm = new MarkForm(id, role);
            }
            markForm.Left = this.Left;
            markForm.Top = this.Top;
            markForm.Show();
            this.Hide();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            Form markForm = Application.OpenForms[0];
            if (Application.OpenForms["MarkForm"] != null)
            {
                markForm = Application.OpenForms["MarkForm"];
            }
            else
            {
                markForm = new MarkForm(id, role);
            }
            markForm.Left = this.Left;
            markForm.Top = this.Top;
            markForm.Show();
            this.Hide();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            Form markForm = Application.OpenForms[0];
            if (Application.OpenForms["MarkForm"] != null)
            {
                markForm = Application.OpenForms["MarkForm"];
            }
            else
            {
                markForm = new MarkForm(id, role);
            }
            markForm.Left = this.Left;
            markForm.Top = this.Top;
            markForm.Show();
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

        private void button1_Click(object sender, EventArgs e)
        {
            ind = 0;
            table.Hide();
            table.SuspendLayout();

            while (table.Controls.Count > 0)
            {
                table.Controls[0].Dispose();
            }

            for (int i = 0; i < 6; i++)
            {
                Label label = new Label();
                label.Text = GetTime(i);
                label.Font = new Font("Times New Roman", 14F, FontStyle.Regular);
                label.AutoSize = true;
                label.TextAlign = ContentAlignment.MiddleCenter;
                this.table.Controls.Add(label, 0, i);

            }

            String result = "";
            Database database = new Database();
            MySqlCommand commandTimetable = new MySqlCommand
                ("SELECT * FROM `timetable` WHERE `class` = @class", database.getConnection());

            commandTimetable.Parameters.AddWithValue("@class", this.classComboBox.Text);
            database.openConnection();
            MySqlDataReader reader2 = commandTimetable.ExecuteReader();
            if (reader2.Read())
            {
                globalId = reader2.GetValue(0).ToString();
                //result = reader2[GetDayEng(dayComboBox.Text)].ToString();
                result = reader2[dayStr].ToString();
            }
            reader2.Close();
            database.closeConnection();

            lesson = result.Split(',');
            for (ind = 0; ind < lesson.Length; ind++)
            {
                Label label = new Label();
                label.Name = ind.ToString();
                label.Text = lesson[ind];
                label.Font = new Font("Times New Roman", 18F, FontStyle.Regular);
                label.AutoSize = true;
                label.TextAlign = ContentAlignment.MiddleCenter;
                label.Click += new EventHandler(Label_Click);
                this.table.Controls.Add(label, 1, ind);
            }
            //ind = 0;

            table.ResumeLayout();
            table.Visible = true;
        }

        private void Label_Click(object sender, EventArgs e)
        {
            if (role == "2")
            {
                Label dynamicLabel = (sender as Label);
                int ind2 = Int32.Parse(dynamicLabel.Name);
                TextBox textBox = new TextBox();
                textBox.Left = dynamicLabel.Left;
                textBox.Top = dynamicLabel.Top;
                textBox.Font = new Font("Times New Roman", 18F, FontStyle.Regular);
                textBox.Dock = DockStyle.Fill;
                dynamicLabel.Dispose();
                textBox.Name = dynamicLabel.Name;
                textBox.Show();
                this.table.Controls.Add(textBox, 1, ind2);
                textBox.KeyPress += new KeyPressEventHandler(Tb_Click);
            }
        }

        private void Tb_Click(object sender, KeyPressEventArgs e)
        {
            TextBox dynamicTb = (sender as TextBox);
            Char chr = e.KeyChar;
            int ind3 = Int32.Parse(dynamicTb.Name);

            if (chr == 13)
            {
                lesson[ind3] = dynamicTb.Text;
                String toDB = "";
                for (int i = 0; i < lesson.Length; i++)
                {
                    toDB = toDB + lesson[i] + ",";
                }
                toDB = toDB.Substring(0, toDB.Length - 1);

                String str = "UPDATE `timetable` SET " + dayStr +
                    "= @str WHERE `timetable`.`id` = @id";

                Database database = new Database();
                MySqlCommand commandTimetable = new MySqlCommand
                    (str, database.getConnection());
                commandTimetable.Parameters.AddWithValue("@str", toDB);
                commandTimetable.Parameters.AddWithValue("@id", globalId);
                database.openConnection();
                commandTimetable.ExecuteNonQuery();
                database.closeConnection();

                button1_Click(sender, e);
            }
        }


        private void button2_Click(object sender, EventArgs e)
        {
            dayStr = "monday";
            button1_Click(sender, e);

        }

        private void button3_Click(object sender, EventArgs e)
        {
            dayStr = "tuesday";
            button1_Click(sender, e);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            dayStr = "wednesday";
            button1_Click(sender, e);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            dayStr = "thursday";
            button1_Click(sender, e);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            dayStr = "friday";
            button1_Click(sender, e);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            dayStr = "saturday";
            button1_Click(sender, e);

        }

        private void printButton_Click(object sender, EventArgs e)
        {
            if (classComboBox.Text == "")
            {
                MessageBox.Show("Вы не ввели класс", "Ошибка");
            }
            else
            {
                Database database = new Database();
                MySqlCommand commandTimetable = new MySqlCommand
                    ("SELECT * FROM `timetable` WHERE `class` = @class", database.getConnection());

                commandTimetable.Parameters.AddWithValue("@class", this.classComboBox.Text);
                database.openConnection();
                MySqlDataReader reader = commandTimetable.ExecuteReader();
                if (reader.Read())
                {
                    StringBuilder sb = new StringBuilder();
                    for (int i = 0; i < 6; i++)
                    {
                        switch (i)
                        {
                            case 0: sb.Append("Понедельник:\n"); break;
                            case 1: sb.Append("Вторник:\n"); break;
                            case 2: sb.Append("Среда:\n"); break;
                            case 3: sb.Append("Черверг:\n"); break;
                            case 4: sb.Append("Пятница:\n"); break;
                            case 5: sb.Append("Суббота:\n"); break;
                        }
                        String[] lesson = reader.GetValue(i + 1).ToString().Split(',');
                        for (int j = 0; j < lesson.Length; j++)
                        {
                            String time = GetTime(j).Replace("\n", " ");
                            sb.Append(time + " - " + lesson[j] + "\n");
                        }
                        sb.Append("\n");
                    }

                    var path = @"C:\Users\Default\Documents\temp.txt";
                    File.WriteAllText(path, sb.ToString());

                    System.Diagnostics.ProcessStartInfo psi = new System.Diagnostics.ProcessStartInfo(@"C:\Users\Default\Documents\temp.txt");
                    psi.Verb = "PRINT";
                    psi.WindowStyle = ProcessWindowStyle.Hidden;
                    Process.Start(psi);
                }
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

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
    public partial class TimetableForm : Form
    {
        String id, role;

        public TimetableForm(String id, String role)
        {
            InitializeComponent();
            this.id = id;
            this.role = role;

            this.exitButton.ForeColor = Color.FromArgb(164, 164, 164);
            this.StartPosition = FormStartPosition.CenterScreen;

<<<<<<< HEAD
            DatabaseSingleton database = DatabaseSingleton.GetInstance();
=======
>>>>>>> parent of a45424e... CLOSE
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

        private void logPanel_Click(object sender, EventArgs e)
        {
            this.Close();
            BookForm bookForm = new BookForm(id, role);
            bookForm.Show();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            this.Close();
            BookForm bookForm = new BookForm(id, role);
            bookForm.Show();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            this.Close();
            BookForm bookForm = new BookForm(id, role);
            bookForm.Show();
        }

        private void markPanel_Click(object sender, EventArgs e)
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

        private void label5_Click(object sender, EventArgs e)
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
<<<<<<< HEAD
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
            DatabaseSingleton database = DatabaseSingleton.GetInstance();
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

                DatabaseSingleton database = DatabaseSingleton.GetInstance();
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
                DatabaseSingleton database = DatabaseSingleton.GetInstance();
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
                    psi.CreateNoWindow = true;
                    psi.WindowStyle = ProcessWindowStyle.Hidden;
                    Process.Start(psi);

                    //File.Delete(@"C:\Users\Default\Documents\temp.txt");
                }
            }
=======
>>>>>>> parent of a45424e... CLOSE
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            this.Close();
            EditForm editForm = new EditForm(id, role);
            editForm.Show();
        }
    }
}

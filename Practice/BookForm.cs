using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
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
        int flag = 0;
        bool sortType = false; 
       
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
                    break;
            }

            this.exitButton.ForeColor = Color.FromArgb(164, 164, 164);

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
            editForm.Show();
            this.Hide();
        }

        private void showButton_Click(object sender, EventArgs e)
        {
            if (this.classComboBox.Text == "")
            {
                MessageBox.Show("Вы не выбрали класс", "Ошибка");
            }
            else if (this.subjectComboBox.Text == "")
            {
                MessageBox.Show("Вы не выбрали предмет", "Ошибка");
            }
            else
            {
                String strNames = "SELECT `secondName`, `firstName`, `thirdName` FROM `student` WHERE" +
                    " `class` = @class ORDER BY secondName";
                String strMarks = "SELECT `name`, DAYOFMONTH(`date`), `mark` FROM `marks` WHERE " +
                    "`class` = @class AND `subject` = @subject AND MONTH(`date`) = @month " +
                    "ORDER BY name";
                if (sortType)
                {
                    strNames = strNames + " DESC";
                    strMarks = strMarks + " DESC";
                }

                table.Hide();
                table.SuspendLayout();

                while (table.Controls.Count > 0)
                {
                    table.Controls[0].Dispose();
                }

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

                table.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;

                table.ColumnCount = columns;
                table.RowCount = rows;

                MySqlCommand commandNames = new MySqlCommand(strNames, database.getConnection());
                commandNames.Parameters.AddWithValue("@class", this.classComboBox.Text);
                database.openConnection();
                MySqlDataReader reader1 = commandNames.ExecuteReader();

                String[] names = new String[rows - 1];
                int index = 0;

                while (reader1.Read())
                {
                    names[index] = reader1.GetValue(0).ToString() + " " + reader1.GetValue(1).ToString() + " " + reader1.GetValue(2).ToString();
                    index++;
                }

                reader1.Close();
                database.closeConnection();

                MySqlCommand commandMarks = new MySqlCommand(strMarks, database.getConnection());
                commandMarks.Parameters.AddWithValue("@class", this.classComboBox.Text);
                commandMarks.Parameters.AddWithValue("@subject", this.subjectComboBox.Text);
                commandMarks.Parameters.AddWithValue("@month", GetMonth(monthComboBox.Text));
                database.openConnection();
                MySqlDataReader reader3 = commandMarks.ExecuteReader();

                String[,] marks = new String[rows - 1, columns - 1];
                index = 0;

                for (int i = 0; i < rows - 1; i++)
                {
                    for (int j = 0; j < columns - 1; j++)
                    {
                        marks[i, j] = "";
                    }
                }

                while (reader3.Read())
                {
                    if (reader3.GetValue(0).ToString() == names[index])
                    {
                        marks[index, Int32.Parse(reader3.GetValue(1).ToString()) - 1] = reader3.GetValue(2).ToString();
                    }
                    else
                    {
                        while (names[index] != reader3.GetValue(0).ToString())
                        {
                            index++;
                        }
                        marks[index, Int32.Parse(reader3.GetValue(1).ToString()) - 1] = reader3.GetValue(2).ToString();
                    }
                }

                reader3.Close();
                database.closeConnection();


                //StringBuilder sb = new StringBuilder();
                //for (int i = 0; i < rows - 1; i++)
                //{
                //    for (int j = 0; j < columns - 1; j++)
                //    {
                //        sb.Append(marks[i, j] + "\t");
                //    }
                //    sb.Append("\n");
                //}
                //MessageBox.Show(sb.ToString());



                //for (int i = 0; i < rows; i++)
                //{
                //    for (int j = 0; j < columns; j++)
                //    {
                //        if (i == 0 && j == 0)
                //        {
                //            continue;
                //        }

                //        if (i == 0 && j > 0)
                //        {
                //            sb.Append(j.ToString() + "\t");
                //        }

                //        if (i > 0 && j == 0)
                //        {
                //            sb.Append(names[i - 1] + "\t");
                //        }

                //        if (i > 0 && j > 0)
                //        {
                //            sb.Append(marks[i - 1, j - 1] + "\t");
                //        }
                //    }
                //    sb.Append("\n");
                //}
                //MessageBox.Show(sb.ToString());



                TableLayoutRowStyleCollection styles = table.RowStyles;
                foreach (RowStyle style in styles)
                {
                    style.SizeType = SizeType.AutoSize;
                }

                TableLayoutColumnStyleCollection styles1 = table.ColumnStyles;
                foreach (ColumnStyle style in styles1)
                {
                    style.SizeType = SizeType.AutoSize;
                }

                Button sort = new Button();
                if (sortType)
                {
                    sort.Text = "В алфавитном порядке";
                }
                else
                {
                    sort.Text = "Против алфавитного порядка";
                }
                sort.Font = new Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular);
                sort.Click += new EventHandler(sort_click);
                sort.Size = new Size(300, 30);
                //sort.Dock = DockStyle.Fill;
                table.Controls.Add(sort);

                for (int i = 0; i < rows; i++)
                {
                    for (int j = 0; j < columns; j++)
                    {
                        if (i == 0 && j == 0)
                        {
                            continue;
                        }

                        Label label = new Label();
                        label.Font = new Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular);
                        label.AutoSize = false;

                        if (i == 0 && j > 0)
                        {
                            label.Text = j.ToString();
                            //label.Size = new System.Drawing.Size(25, 20);
                            label.BackColor = Color.FromArgb(181, 234, 177);
                        }

                        if (i > 0 && j == 0)
                        {
                            label.Text = names[i - 1];
                            //label.Size = new System.Drawing.Size(300, 20);
                            label.BackColor = Color.FromArgb(181, 234, 177);
                        }

                        if (i > 0 && j > 0)
                        {
                            if (i % 2 == 0)
                            {
                                label.BackColor = Color.FromArgb(208, 208, 208);
                            }
                            label.Text = marks[i - 1, j - 1];
                        }
                        label.Dock = DockStyle.Fill;
                        table.Controls.Add(label);
                    }
                }
                table.ResumeLayout();
                table.Visible = true;
            }
        }

        private int GetMonth(String str)
        {
            switch (str)
            {
                case "Январь": return 1;
                case "Февраль": return 2;
                case "Март": return 3;
                case "Апрель": return 4;
                case "Май": return 5;
                case "Июнь": return 6;
                case "Июль": return 7;
                case "Август": return 8;
                case "Сентябрь": return 9;
                case "Октябрь": return 10;
                case "Ноябрь": return 11;
                case "Декабрь": return 12;
            }
            return 0;
        }

        private void sort_click(object sender, EventArgs e)
        {
            if (sortType) sortType = false;
            else sortType = true;
            this.showButton.PerformClick();
        }

        private void csvButton_Click(object sender, EventArgs e)
        {
            if (this.classComboBox.Text == "")
            {
                MessageBox.Show("Вы не выбрали класс", "Ошибка");
            }
            else if (this.subjectComboBox.Text == "")
            {
                MessageBox.Show("Вы не выбрали предмет", "Ошибка");
            }
            else
            {
                Database database = new Database();
                MySqlCommand command = new MySqlCommand
                    ("SELECT * FROM marks WHERE `class` = @class AND `subject` = @subject", database.getConnection());
                command.Parameters.AddWithValue("@class", this.classComboBox.Text);
                command.Parameters.AddWithValue("@subject", this.subjectComboBox.Text);
                database.openConnection();
                MySqlDataReader reader = command.ExecuteReader();

                StringBuilder csv = new StringBuilder();
                csv.Append("ФИО,Класс,Оценка,Дата,Предмет,Учитель\n");
                String rName = "", rClass = "", rMark = "", rDate = "", rSubject = "", rTeacher = "";

                while (reader.Read())
                {
                    rName = reader["name"].ToString();
                    rClass = reader["class"].ToString();
                    rMark = reader["mark"].ToString();
                    rDate = reader["date"].ToString();
                    rSubject = reader["subject"].ToString();
                    rTeacher = reader["teachersName"].ToString();
                    csv.Append(rName);
                    csv.Append(',');
                    csv.Append(rClass);
                    csv.Append(',');
                    csv.Append(rMark);
                    csv.Append(',');
                    csv.Append(rDate);
                    csv.Append(',');
                    csv.Append(rSubject);
                    csv.Append(',');
                    csv.Append(rTeacher);
                    csv.Append('\n');
                }
                reader.Close();
                database.closeConnection();

                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "txt files(*.txt)| *.txt | All files(*.*) | *.* ";
                sfd.FileName = "Журнал " + rClass + " класс. " + rSubject;
                sfd.Title = "Сохранение школьного журанала";
                if (sfd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    String path = sfd.FileName;
                    StreamWriter bw = new StreamWriter(File.Create(path), Encoding.GetEncoding(1251));
                    bw.Write(csv.ToString());
                    bw.Dispose();
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
            editForm.Show();
            this.Hide();
        }
    }
}

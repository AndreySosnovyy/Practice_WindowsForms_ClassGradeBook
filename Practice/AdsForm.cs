using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Practice
{
    public partial class AdsForm : Form
    {
        String id, role;

        public AdsForm(String id, String role)
        {
            InitializeComponent();
            this.id = id;
            this.role = role;

            this.exitButton.ForeColor = Color.FromArgb(164, 164, 164);

           switch(role)
            {
                case "0":
                    this.panel7.Hide();
                    this.markPanel.Hide();
                    break;
                case "1":
                    this.panel7.Hide();
                    break;
            }

            Database database = new Database();
            MySqlCommand commandTeacher = new MySqlCommand
                ("SELECT `text` FROM `ads` WHERE `id` = 1", database.getConnection());
            database.openConnection();
            MySqlDataReader reader = commandTeacher.ExecuteReader();
            
            if (reader.Read())
            {
                adsText.Text = reader.GetValue(0).ToString();
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

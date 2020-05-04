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
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();

            this.StartPosition = FormStartPosition.CenterScreen;
            this.buttonExit.FlatAppearance.BorderSize = 0;
            this.ActiveControl = null;
            this.loginField.Text = " Логин";
            this.loginField.ForeColor = Color.FromArgb(188, 188, 188);
            this.passwordField.Text = " Пароль";
            this.passwordField.ForeColor = Color.FromArgb(188, 188, 188);
            this.label3.ForeColor = Color.FromArgb(164, 164, 164);
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

        private void loginField_Leave(object sender, EventArgs e)
        {
            if (this.loginField.Text.Length == 0)
            {
                this.loginField.Text = " Логин";
                this.loginField.ForeColor = Color.FromArgb(188, 188, 188);
            }
        }

        private void passwordField_Leave(object sender, EventArgs e)
        {
            if (this.passwordField.Text.Length == 0)
            {
                this.passwordField.UseSystemPasswordChar = false;
                this.passwordField.Text = " Пароль";
                this.passwordField.ForeColor = Color.FromArgb(188, 188, 188);
            }
        }

        private void loginField_Enter(object sender, EventArgs e)
        {
            if (this.loginField.Text.Equals(" Логин"))
            {
                this.loginField.Text = "";
                this.loginField.ForeColor = Color.Black;
            }
        }

        private void passwordField_Enter(object sender, EventArgs e)
        {
            if (this.passwordField.Text.Equals(" Пароль"))
            {
                this.passwordField.Text = "";
                this.passwordField.ForeColor = Color.Black;
                this.passwordField.UseSystemPasswordChar = true;
            }
        }

        private void enterButton_Click(object sender, EventArgs e)
        {
            string enteredLogin = this.loginField.Text;
            string enteredPassword = this.passwordField.Text;

            // !!!!!!!!!!!!!!!!!!!!!
            // добавить проерку на пустоту полей + уведомление об этом
            // !!!!!!!!!!!!!!!!!!!!!

            Database database = new Database();
            MySqlCommand commandTeacher = new MySqlCommand
                ("SELECT * FROM `teachers` WHERE `login` = @eLt AND `password` = @ePt", database.getConnection());
            commandTeacher.Parameters.Add("@eLt", MySqlDbType.VarChar).Value = enteredLogin;
            commandTeacher.Parameters.Add("@ePt", MySqlDbType.VarChar).Value = enteredPassword;
            database.openConnection();
            MySqlDataReader reader = commandTeacher.ExecuteReader();

            if(reader.Read())
            {
                //MessageBox.Show("teacher");
                
                database.closeConnection();
                this.Hide();
                AdsForm adsForm = new AdsForm();
                adsForm.Show();
                reader.Close();
            }
            reader.Close();

            MySqlCommand commandStudent = new MySqlCommand
                ("SELECT * FROM `student` WHERE `login` = @eLs AND `password` = @ePs", database.getConnection());
            commandStudent.Parameters.Add("@eLs", MySqlDbType.VarChar).Value = enteredLogin;
            commandStudent.Parameters.Add("@ePs", MySqlDbType.VarChar).Value = enteredPassword;
            database.openConnection();
            MySqlDataReader reader1 = commandStudent.ExecuteReader();
            if (reader1.Read())
            {
                //MessageBox.Show("student");
                
                database.closeConnection();
                this.Hide();
                AdsForm adsForm = new AdsForm();
                adsForm.Show();
                reader.Close();
            }
        }

        private void label3_MouseEnter(object sender, EventArgs e)
        {
            this.label3.ForeColor = Color.FromArgb(0, 0, 0);
        }

        private void label3_MouseLeave(object sender, EventArgs e)
        {
            this.label3.ForeColor = Color.FromArgb(164, 164, 164);
        }

        private void label3_Click(object sender, EventArgs e)
        {
            this.Hide();
            registrationForm registrationForm = new registrationForm();
            registrationForm.Show();
        }
    }
}

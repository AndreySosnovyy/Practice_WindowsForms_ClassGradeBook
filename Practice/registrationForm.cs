using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Practice
{
    public partial class registrationForm : Form
    {
        public registrationForm()
        {
            InitializeComponent();

            this.StartPosition = FormStartPosition.CenterScreen;
            this.buttonExit.FlatAppearance.BorderSize = 0;
            this.ActiveControl = null;
            this.loginField.Text = " Логин";
            this.loginField.ForeColor = Color.FromArgb(188, 188, 188);
            this.passwordField.Text = " Пароль";
            this.passwordField.ForeColor = Color.FromArgb(188, 188, 188);
            this.passwordField2.Text = " Пароль еще раз";
            this.passwordField2.ForeColor = Color.FromArgb(188, 188, 188);
            this.tokenField.Text = " Токен";
            this.tokenField.ForeColor = Color.FromArgb(188, 188, 188);
            this.label10.ForeColor = Color.FromArgb(164, 164, 164);
            this.dataPanel.Visible = false;
            this.subjectComboBox.Items.Add("Физика");
            this.subjectComboBox.Items.Add("Математика");
            this.subjectComboBox.Items.Add("Информатика");
            this.subjectComboBox.Items.Add("Русский язык");
            this.subjectComboBox.Items.Add("География");
            this.subjectComboBox.Items.Add("Физическая культура");
            this.subjectComboBox.Visible = false;
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

        private void tokenField_Leave(object sender, EventArgs e)
        {
            if (this.tokenField.Text.Length == 0)
            {
                this.tokenField.Text = " Токен";
                this.tokenField.ForeColor = Color.FromArgb(188, 188, 188);
            }
        }

        private void tokenField_Enter(object sender, EventArgs e)
        {
            if (this.tokenField.Text.Equals(" Токен"))
            {
                this.tokenField.Text = "";
                this.tokenField.ForeColor = Color.Black;
            }
        }

        private void loginField_Leave(object sender, EventArgs e)
        {
            if (this.loginField.Text.Length == 0)
            {
                this.loginField.Text = " Логин";
                this.loginField.ForeColor = Color.FromArgb(188, 188, 188);
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

        private void passwordField_Leave(object sender, EventArgs e)
        {
            if (this.passwordField.Text.Length == 0)
            {
                this.passwordField.UseSystemPasswordChar = false;
                this.passwordField.Text = " Пароль";
                this.passwordField.ForeColor = Color.FromArgb(188, 188, 188);
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

        private void passwordField2_Leave(object sender, EventArgs e)
        {
            if (this.passwordField2.Text.Length == 0)
            {
                this.passwordField2.UseSystemPasswordChar = false;
                this.passwordField2.Text = " Пароль еще раз";
                this.passwordField2.ForeColor = Color.FromArgb(188, 188, 188);
            }
        }

        private void passwordField2_Enter(object sender, EventArgs e)
        {
            if (this.passwordField2.Text.Equals(" Пароль еще раз"))
            {
                this.passwordField2.Text = "";
                this.passwordField2.ForeColor = Color.Black;
                this.passwordField2.UseSystemPasswordChar = true;
            }
        }

        public String GlobalRole;

        private void continueButton_Click(object sender, EventArgs e)
        {
            String enteredToken = this.tokenField.Text;
            String enteredLogin = this.loginField.Text;
            String enteredPassword = this.passwordField.Text;
            String enteredPassword2 = this.passwordField2.Text;

            if (enteredToken.Length == 0 || tokenField.Text == " Токен")
            {
                MessageBox.Show("Введите токен!", "Ошибка");
            }
            else if (enteredLogin.Length == 0 || loginField.Text == " Логин")
            {
                MessageBox.Show("Введите логин!", "Ошибка");
            }
            else if (enteredPassword.Length == 0 || passwordField.Text == " Пароль")
            {
                MessageBox.Show("Введите пароль!", "Ошибка");
            }
            else if (enteredPassword2.Length == 0 || passwordField2.Text == " Пароль еще раз")
            {
                MessageBox.Show("Подтверите пароль!", "Ошибка");
            }
            else if (enteredPassword != enteredPassword2)
            {
                MessageBox.Show("Пароли не совпадают!", "Ошибка");
            }
            else
            {
                Database database = new Database();
                MySqlCommand command = new MySqlCommand
                    ("SELECT `type` FROM `tokens` WHERE `token` = @t", database.getConnection());
                command.Parameters.AddWithValue("@t", enteredToken);
                database.openConnection();
                MySqlDataReader reader = command.ExecuteReader();

                if (!reader.Read())
                {
                    MessageBox.Show("Введенного Вами токена не существует!", "Ошибка");
                }
                else if ("" + reader.GetValue(0) == "1" || "" + reader.GetValue(0) == "2")
                {
                    this.dataPanel.Visible = true;
                    this.classField.Visible = false;
                    this.label9.Visible = false;
                    this.groupBox.Visible = true;
                    this.regStudentButton.Visible = false;
                    this.regTeacherButton.Visible = true;
                    GlobalRole = "" + reader.GetValue(0);
                    reader.Close();

                    MySqlCommand commandDel = new MySqlCommand
                        ("DELETE FROM `tokens` WHERE `token` = @t", database.getConnection());
                    commandDel.Parameters.AddWithValue("@t", enteredToken);
                    commandDel.ExecuteNonQuery();
                }
                else if ("" + reader.GetValue(0) == "0")
                {
                    this.dataPanel.Visible = true;
                    this.groupBox.Visible = false;
                    this.classField.Visible = true;
                    this.label9.Visible = true;
                    this.regStudentButton.Visible = true;
                    this.regTeacherButton.Visible = false;
                    GlobalRole = "0";

                    MySqlCommand commandDel = new MySqlCommand
                        ("DELETE FROM `tokens` WHERE `token` = @t", database.getConnection());
                    commandDel.Parameters.AddWithValue("@t", enteredToken);
                    commandDel.ExecuteNonQuery();
                }
                reader.Close();
                database.closeConnection();
            }
        }

        private void label10_MouseEnter(object sender, EventArgs e)
        {
            this.label10.ForeColor = Color.FromArgb(0, 0, 0);
        }

        private void label10_MouseLeave(object sender, EventArgs e)
        {
            this.label10.ForeColor = Color.FromArgb(164, 164, 164);
        }

        private void label10_Click(object sender, EventArgs e)
        {
            this.Close();
            LoginForm loginForm = new LoginForm();
            loginForm.Show();
        }

        private void subjectRadioButton1_CheckedChanged(object sender, EventArgs e)
        {
            this.subjectComboBox.Visible = false;
            this.subjectField.Visible = true;
            this.subjectComboBox.Text = "";
        }

        private void subjectRadioButton2_CheckedChanged(object sender, EventArgs e)
        {
            this.subjectField.Visible = false;
            this.subjectComboBox.Visible = true;
            this.subjectField.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Database database = new Database();
            database.openConnection();
            MySqlCommand commandAddTeacher = new MySqlCommand
                ("INSERT INTO `teachers` (`login`, `password`, `token`, `firstName`, `secondName`, `thirdName`, `subject`, `phoneNumber`, `role`)" +
                " VALUES (@login, @pass, @token, @name, @sName, @tName, @subject, @phone, @role);", database.getConnection());
            commandAddTeacher.Parameters.AddWithValue("@login", this.loginField.Text);
            commandAddTeacher.Parameters.AddWithValue("@pass", this.passwordField.Text);
            commandAddTeacher.Parameters.AddWithValue("@token", this.tokenField.Text);
            commandAddTeacher.Parameters.AddWithValue("@name", this.nameField.Text);
            commandAddTeacher.Parameters.AddWithValue("@sName", this.secondNameField.Text);
            commandAddTeacher.Parameters.AddWithValue("@tName", this.thirdNameField.Text);
            commandAddTeacher.Parameters.AddWithValue("@subject", this.subjectField.Text + this.subjectComboBox.Text);
            commandAddTeacher.Parameters.AddWithValue("@phone", this.phoneField.Text);
            commandAddTeacher.Parameters.AddWithValue("@role", GlobalRole);
            database.openConnection();

            if (commandAddTeacher.ExecuteNonQuery() == 1)
            {
                MessageBox.Show("Вы успешно зарегистрировались", "Регистрация");
                this.Close();
                LoginForm loginForm = new LoginForm();
                loginForm.Show();
            }
            else
            {
                MessageBox.Show("Не удалось зарегистрироваться", "Регистрация");
            }
            database.closeConnection();
            //}
        }

        private void regStudentButton_Click(object sender, EventArgs e)
        {
            Database database = new Database();
            MySqlCommand commandAddStudent = new MySqlCommand
                ("INSERT INTO `student` (`login`, `password`, `token`, `role`, `firstName`, `secondName`, `thirdName`, `class`, `phoneNumber`)" +
                " VALUES (@login, @pass, @token, @role, @name, @sName, @tName, @class, @phone);", database.getConnection());
            commandAddStudent.Parameters.AddWithValue("@login", this.loginField.Text);
            commandAddStudent.Parameters.AddWithValue("@pass", this.passwordField.Text);
            commandAddStudent.Parameters.AddWithValue("@token", this.tokenField.Text);
            commandAddStudent.Parameters.AddWithValue("@role", GlobalRole);
            commandAddStudent.Parameters.AddWithValue("@name", this.nameField.Text);
            commandAddStudent.Parameters.AddWithValue("@sName", this.secondNameField.Text);
            commandAddStudent.Parameters.AddWithValue("@tName", this.thirdNameField.Text);
            commandAddStudent.Parameters.AddWithValue("@class", this.classField.Text);
            commandAddStudent.Parameters.AddWithValue("@phone", this.phoneField.Text);
            database.openConnection();

            if (commandAddStudent.ExecuteNonQuery() == 1)
            {
                MessageBox.Show("Вы успешно зарегистрировались", "Регистрация");
                this.Close();
                LoginForm loginForm = new LoginForm();
                loginForm.Show();
            }
            else
            {
                MessageBox.Show("Не удалось зарегистрироваться", "Регистрация");
            }
            database.closeConnection();
        }
    }
}

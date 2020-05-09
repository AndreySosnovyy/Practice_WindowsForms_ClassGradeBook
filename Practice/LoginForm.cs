using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
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

            this.buttonExit.FlatAppearance.BorderSize = 0;
            this.ActiveControl = null;
            this.loginField.Text = " Логин";
            this.loginField.ForeColor = Color.FromArgb(188, 188, 188);
            this.passwordField.Text = " Пароль";
            this.passwordField.ForeColor = Color.FromArgb(188, 188, 188);
            this.label3.ForeColor = Color.FromArgb(164, 164, 164);

            Database database = new Database();
            //SELECT pk_id FROM test ORDER BY rand() LIMIT 1

            String randId = "";

            MySqlCommand commandGetId = new MySqlCommand
                ("SELECT `id` FROM `images` ORDER BY rand() LIMIT 1", database.getConnection());
            database.openConnection();
            MySqlDataReader reader = commandGetId.ExecuteReader();
            if (reader.Read())
            {
                randId = reader.GetValue(0).ToString();
            }
            reader.Close();


            MySqlCommand commandImage = new MySqlCommand
                ("SELECT `image` FROM `images` WHERE `id` = @id", database.getConnection());
            commandImage.Parameters.AddWithValue("@id", randId);
            database.openConnection();
            MySqlDataReader reader2 = commandImage.ExecuteReader();

            if (reader2.Read())
            {
                byte[] image = (byte[])(reader2.GetValue(0));
                if (image == null)
                {
                    imageFromDB.Image = null;
                }
                else
                {
                    MemoryStream mstream = new MemoryStream(image);
                    imageFromDB.Image = System.Drawing.Image.FromStream(mstream);
                }
            }
            reader2.Close();
            database.closeConnection();
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

        bool flag = false;

        private void enterButton_Click(object sender, EventArgs e)
        {
            string enteredLogin = this.loginField.Text;
            string enteredPassword = this.passwordField.Text;

            Database database = new Database();
            MySqlCommand commandTeacher = new MySqlCommand
                ("SELECT * FROM `teachers` WHERE `login` = @eLt AND `password` = @ePt", database.getConnection());
            commandTeacher.Parameters.Add("@eLt", MySqlDbType.VarChar).Value = enteredLogin;
            commandTeacher.Parameters.Add("@ePt", MySqlDbType.VarChar).Value = enteredPassword;
            database.openConnection();
            MySqlDataReader reader = commandTeacher.ExecuteReader();

            if (reader.Read())
            {
                Form adsForm = Application.OpenForms[0];
                if (Application.OpenForms["AdsForm"] != null)
                {
                    adsForm = Application.OpenForms["AdsForm"];
                }
                else
                {
                    adsForm = new AdsForm(reader.GetValue(0).ToString(), reader.GetValue(9).ToString());
                }
                adsForm.Left = this.Left;
                adsForm.Top = this.Top;
                adsForm.Show();
                this.Hide();
                database.closeConnection();
                flag = true;
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
                flag = true;

                Form adsForm = Application.OpenForms[0];
                if (Application.OpenForms["AdsForm"] != null)
                {
                    adsForm = Application.OpenForms["AdsForm"];
                }
                else
                {
                    adsForm = new AdsForm(reader1.GetValue(0).ToString(), reader1.GetValue(4).ToString());
                }
                adsForm.Left = this.Left;
                adsForm.Top = this.Top;
                adsForm.Show();
                this.Hide();
            }
            reader1.Close();
            database.closeConnection();

            if (!flag)
            {
                MessageBox.Show("Неверный логин или пароль", "Ошибка");
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
            Form registrationForm = Application.OpenForms[0];
            if (Application.OpenForms["RegistrationForm"] != null)
            {
                registrationForm = Application.OpenForms["RegistrationForm"];
            }
            else
            {
                registrationForm = new RegistrationForm();
            }
            registrationForm.Left = this.Left;
            registrationForm.Top = this.Top;
            registrationForm.Show();
            this.Hide();
        }
    }
}

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
    public partial class EditForm : Form
    {
        String id, role;

        public EditForm(String id, String role)
        {
            InitializeComponent();
            this.id = id;
            this.role = role;

            this.exitButton.ForeColor = Color.FromArgb(164, 164, 164);
            this.StartPosition = FormStartPosition.CenterScreen;

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

        private void button5_Click(object sender, EventArgs e)
        {
            CreateTokenForm createTokenForm = new CreateTokenForm(id, role);
            createTokenForm.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            EditAdsForm editAdsForm = new EditAdsForm(id, role);
            editAdsForm.Show();
        }
    }
}

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
    public partial class EditAdsForm : Form
    {
        String id, role;

        public EditAdsForm(String id, String role)
        {
            InitializeComponent();
            this.id = id;
            this.role = role;

            this.StartPosition = FormStartPosition.CenterScreen;

            DatabaseSingleton database = DatabaseSingleton.GetInstance();
            MySqlCommand command = new MySqlCommand
                ("SELECT `text` FROM `ads` WHERE `id` = 1", database.getConnection());
            database.openConnection();
            MySqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                newTextField.Text = reader.GetValue(0).ToString();
            }
            database.closeConnection();
            reader.Close();
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

        private void label2_Click(object sender, EventArgs e)
        {
            DatabaseSingleton database = DatabaseSingleton.GetInstance();
            MySqlCommand command = new MySqlCommand
                ("UPDATE `ads` SET `text` = @newText", database.getConnection());
            command.Parameters.AddWithValue("@newText", newTextField.Text);
            database.openConnection();
            command.ExecuteNonQuery();
            database.closeConnection();
        }

        private void label2_MouseEnter(object sender, EventArgs e)
        {
            this.label2.BackColor = Color.FromArgb(127, 182, 123);
        }

        private void label2_MouseLeave(object sender, EventArgs e)
        {
            this.label2.BackColor = Color.FromArgb(182, 182, 182);
        }

<<<<<<< HEAD
        private byte[] ImageToByteArray(System.Drawing.Image imageIn)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Gif);
                return ms.ToArray();
            }
        }

        private void newImageButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                pictureHided.Image = Image.FromFile(dialog.FileName);

                MemoryStream ms = new MemoryStream();
                pictureHided.Image.Save(ms, pictureHided.Image.RawFormat);
                byte[] img = ms.ToArray();

                DatabaseSingleton database = DatabaseSingleton.GetInstance();
                MySqlCommand command = new MySqlCommand
                    ("INSERT INTO `images` (image) VALUES (@img)", database.getConnection());
                command.Parameters.Add("@img", MySqlDbType.Blob);
                command.Parameters["@img"].Value = img;
                database.openConnection();
                if (command.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show("Изображение загружено");
                }
                database.closeConnection();
                this.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DatabaseSingleton database = DatabaseSingleton.GetInstance();
            MySqlCommand command = new MySqlCommand
                ("DELETE FROM `images` WHERE `id` > 0", database.getConnection());
            database.openConnection();
            if (command.ExecuteNonQuery() > 0)
            {
                MessageBox.Show("Список изображений пуст", "Уведомление");
            }
            database.closeConnection();
            this.Close();
        }

=======
>>>>>>> parent of a45424e... CLOSE
        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            this.ActiveControl = null;
            prevPoint = new Point(e.X, e.Y);
        }
    }
}

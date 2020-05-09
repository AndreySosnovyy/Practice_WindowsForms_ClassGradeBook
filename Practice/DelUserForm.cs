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
    public partial class DelUserForm : Form
    {
        String id, role;

        public DelUserForm(String id, String role)
        {
            InitializeComponent();
            this.id = id;
            this.role = role;

            for (int i = 0; i < 11; i++)
            {
                classComboBox.Items.Add("" + (i + 1));
            }

            this.label2.Text = "*Чтобы удалить аккаунт учителя, введите\n" +
                " вручную его ФИО в длинное поле";
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

            Database database = new Database();
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

        private void delButton_Click(object sender, EventArgs e)
        {
            String[] names = studentComboBox.Text.Split(' '); 

            Database database = new Database();
            MySqlCommand commandDelS = new MySqlCommand
                ("DELETE FROM `student` WHERE `secondName` = @sn AND" +
                " `firstName` = @fn AND `thirdName` = @tn", database.getConnection());
            commandDelS.Parameters.AddWithValue("@sn", names[0]);
            commandDelS.Parameters.AddWithValue("@fn", names[1]);
            commandDelS.Parameters.AddWithValue("@tn", names[2]);
            database.openConnection();

            MySqlCommand commandDelM = new MySqlCommand
                ("DELETE FROM `marks` WHERE `name` = @n", database.getConnection());
            commandDelM.Parameters.AddWithValue("@n", names[0] + " " + names[1] + " " + names[2]);

            MySqlCommand commandDelT = new MySqlCommand
                ("DELETE FROM `teachers` WHERE `secondName` = @sn AND" +
                " `firstName` = @fn AND `thirdName` = @tn", database.getConnection());
            commandDelT.Parameters.AddWithValue("@sn", names[0]);
            commandDelT.Parameters.AddWithValue("@fn", names[1]);
            commandDelT.Parameters.AddWithValue("@tn", names[2]);

            if (commandDelT.ExecuteNonQuery() == 1 || 
               (commandDelS.ExecuteNonQuery() == 1 && commandDelM.ExecuteNonQuery() >= 0))
            {
                MessageBox.Show("Пользователь был удален", "Уведомление");
            }
            else
            {
                MessageBox.Show("Не удалось удалить пользователя", "Ошибка");
            }
            database.closeConnection();
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            this.ActiveControl = null;
            prevPoint = new Point(e.X, e.Y);
        }

        
    }
}

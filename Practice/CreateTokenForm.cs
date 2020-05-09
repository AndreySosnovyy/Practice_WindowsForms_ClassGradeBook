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
    public partial class CreateTokenForm : Form
    {
        String id, role;
        int type = 9;
        String name = "";

        public CreateTokenForm(String id, String role)
        {
            InitializeComponent();

            this.id = id;
            this.role = role;

            this.StartPosition = FormStartPosition.CenterScreen;
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

        private void infoButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show("    Токен - набор случайных символов, который предназначен для того, чтобы " +
                "пользователь мог зарегистрироваться в приложении журнала.\n" +
                "    Любой токен является одноразовым. Сразу после того, как он будет использован, " +
                "он удалится. Время существоватния одного токена не огранеичено.\n" +
                "    Токены бывают трех типов: для ученика, учителя и администратора. " +
                "Внешне они никак не отличаются. " +
                "Право на выдачу токенов есть только у администратора.\n" +
                "    После нажатия на кнопку 'Сгенерировать', токен сразу станет доступным для использования.\n" +
                "    После того, как Вы сгенирировали токен, Вы должны передать его " +
                "пользователю (на бумажном насителе, либо переслать электронно, скопировав токен " +
                "нажатием на кнопку 'Копировать токен')", "Информация о токенах");
        }

        private String generator()
        {
            String symbols = "ABCDEFGHJKLMNPQRSTUVWXYZabcdefghijkmnpqrstuvwxyz0123456789";
            Random rnd = new Random();
            int value;
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < 9; i++)
            {
                if (i == 4)
                {
                    sb.Append("-");
                    continue;
                }
                value = rnd.Next(0, symbols.Length);
                sb.Append(symbols[value]);
            }
            return sb.ToString();
        }

        private void generateButton_Click(object sender, EventArgs e)
        {
            Database database = new Database();
            MySqlCommand commandGetName = new MySqlCommand
                ("SELECT `firstName`, `secondName`, `thirdName` FROM `teachers` WHERE id = @id", database.getConnection());
            commandGetName.Parameters.AddWithValue("@id", id);
            database.openConnection();
            MySqlDataReader reader = commandGetName.ExecuteReader();
            if (reader.Read())
            {
                name = reader.GetValue(1).ToString() + " " + reader.GetValue(0).ToString() + " " + reader.GetValue(2).ToString();
            }
            database.closeConnection();
            reader.Close();

            if (!(radioButton1.Checked || radioButton2.Checked || radioButton3.Checked))
            {
                MessageBox.Show("Вы не выбрали тип токена!", "Ошибка");
            }
            else if (radioButton1.Checked)
            {
                type = 0;
            }
            else if (radioButton2.Checked)
            {
                type = 1;
            }
            else
            {
                type = 2;
            }

            if (type != 9)
            {
                tokenField.Text = generator();

                MySqlCommand command = new MySqlCommand
                ("INSERT INTO `tokens` (`token`, `issuedBy`, `type`) VALUES" +
                "(@token, @name, @type);", database.getConnection());
                command.Parameters.AddWithValue("@token", this.tokenField.Text);
                command.Parameters.AddWithValue("@name", name);
                command.Parameters.AddWithValue("@type", type);
                database.openConnection();
                command.ExecuteNonQuery();
                database.closeConnection();
                reader.Close();

                MessageBox.Show("Токен " + tokenField.Text + " был успешно добавлен в базу данных", "Уведомление");
            }
        }

        private void copyButton_Click(object sender, EventArgs e)
        {
            if (tokenField.Text.Length > 0)
            {
                Clipboard.SetText(tokenField.Text);
            }
        }

        private void tokenInFileButton_Click(object sender, EventArgs e)
        {
            if (!(radioButton1.Checked || radioButton2.Checked || radioButton3.Checked))
            {
                MessageBox.Show("Вы не выбрали тип токена!", "Ошибка");
            }
            else if (radioButton1.Checked)
            {
                type = 0;
            }
            else if (radioButton2.Checked)
            {
                type = 1;
            }
            else
            {
                type = 2;
            }

            if(type != 9)
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "txt files(*.txt)| *.txt | All files(*.*) | *.* ";
                sfd.FileName = "Token";
                sfd.Title = "Создание токена в файле";
                if (sfd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    String path = sfd.FileName;
                    BinaryWriter bw = new BinaryWriter(File.Create(path));
                    String token = generator();

                    Database database = new Database();
                    MySqlCommand commandGetName = new MySqlCommand
                        ("SELECT `firstName`, `secondName`, `thirdName` FROM `teachers` WHERE id = @id", database.getConnection());
                    commandGetName.Parameters.AddWithValue("@id", id);
                    database.openConnection();
                    MySqlDataReader reader = commandGetName.ExecuteReader();
                    if (reader.Read())
                    {
                        name = reader.GetValue(1).ToString() + " " + reader.GetValue(0).ToString() + " " + reader.GetValue(2).ToString();
                    }
                    database.closeConnection();
                    reader.Close();

                    MySqlCommand command = new MySqlCommand
                        ("INSERT INTO `tokens` (`token`, `issuedBy`, `type`) VALUES" +
                        "(@token, @name, @type);", database.getConnection());
                    command.Parameters.AddWithValue("@token", token);
                    command.Parameters.AddWithValue("@name", name);
                    command.Parameters.AddWithValue("@type", type);
                    database.openConnection();
                    command.ExecuteNonQuery();
                    database.closeConnection();
                    reader.Close();

                    char[] cToken = token.ToCharArray();

                    if (secretCheckBox.Checked)
                    {
                        for (int i = 0; i < token.Length; i++)
                        {
                            cToken[i] = Convert.ToChar(Convert.ToUInt64(cToken[i]) + 1);
                        }
                    }
                    bw.Write(cToken);
                    bw.Dispose();
                }
            }
        }


        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            this.ActiveControl = null;
            prevPoint = new Point(e.X, e.Y);
        }
    }
}

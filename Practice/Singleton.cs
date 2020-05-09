using MySql.Data.MySqlClient;
using System;

namespace Practice
{
    class Singleton
    {
        private Singleton() { }

        private static Singleton _instance;
        
        public static Singleton GetInstance()
        {
            if (_instance == null)
            {
                _instance = new Singleton();
            }
            return _instance;
        }

        public void CreateTable(String tableName)
        {
            Database database = new Database();
            MySqlCommand command = new MySqlCommand
                    ("CREATE TABLE example " +
                    "(`id` INT(10) UNSIGNED NOT NULL AUTO_INCREMENT , PRIMARY KEY (`id`))" +
                    " ENGINE = InnoDB;", database.getConnection());
            //command.Parameters.AddWithValue("@tableName", tableName);
            database.openConnection();
            command.ExecuteNonQuery();
            database.closeConnection();
        }

        public void DeleteTable(String tableName)
        {
            Database database = new Database();
            MySqlCommand command = new MySqlCommand
                    ("DROP TABLE example", database.getConnection());
            //command.Parameters.AddWithValue("@tableName", tableName);
            database.openConnection();
            command.ExecuteNonQuery();
            database.closeConnection();
        }
    }
}
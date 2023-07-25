using System;
using Demo_Project.Model;
using MySql.Data.MySqlClient;

namespace Demo_Project
{
    public class MySqlDbHelper
    {

        private MySqlConnection connection;
        private String currentServer;
        private String currentDatabase;
        private String currentUserId;
        private String currentUserPassword;


        private String getConnectionString()
        {
            return "SERVER=" + currentServer + ";" + "DATABASE=" + currentDatabase + ";" + "UID=" + currentUserId + ";" + "PASSWORD=" + currentUserPassword + ";";
        }

        public MySqlDbHelper(String server, String database, String userId, String userPassword)
        {
            currentServer = server;
            currentDatabase = database;
            currentUserId = userId;
            currentUserPassword = userPassword;
            connection = new MySqlConnection(getConnectionString());
        }

        private bool OpenConnection()
        {
            try
            {
                connection.Open();
                return true;
            }
            catch
            {
                return false;
            }
        }

        private bool CloseConnection()
        {
            try
            {
                connection.Close();
                return true;
            }
            catch 
            {
                return false;
            }
        }

        public bool AddNote(int userId, Note note)
        {
            return true;
        }


    }
}
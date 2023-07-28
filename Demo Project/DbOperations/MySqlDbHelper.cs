using System;
using System.Data;
using Demo_Project.Model;
using MySql.Data.MySqlClient;

namespace Demo_Project
{
    public class MySqlDbHelper
    {

        private const String loginSQL = "SELECT U.*, COUNT(N.ID) AS NOTE_COUNT FROM USERS U LEFT JOIN NOTES N ON N.ID = U.ID WHERE U.EMAIL = @PEMAIL AND PASSWORD = @PPASSWORD";
        private const String getNotesSQL = "SELECT N.* FROM NOTES N WHERE N.USER_ID = @PUSER_ID";
        private const String deleteNoteSQL = "DELETE FROM NOTES N WHERE N.ID = @PNOTE_ID;";
        private const String insertNoteSQL = "INSERT INTO NOTES(USER_ID, TITLE, DESCRIPTION) VALUES(@PUSER_ID, @PTITLE, @PDESCRIPTION);";
        private const String updateNoteSQL = "UPDATE NOTES N SET N.TITLE = @PTITLE, N.DESCRIPTION = @PDESCRIPTION WHERE ID = @PNOTE_ID;";
        private const String getNoteDetailsSQL = "SELECT N.* FROM NOTES N WHERE N.ID = @PNOTE_ID";
        private const String insertUserSQL = "INSERT INTO USERS(NAME, SURNAME, EMAIL, PASSWORD) VALUES(@PNAME, @PSURNAME, @PEMAIL, @PPASSWORD);";

        private MySqlConnection connection;
        private MySqlCommand command;

        private String currentServer;
        private String currentDatabase;
        private String currentUserId;
        private String currentUserPassword;
        private int currentPortNumber;


        private String getConnectionString()
        {
            return "SERVER=" + currentServer + ";" + "PORT=" + currentPortNumber.ToString() + ";" + "DATABASE=" + currentDatabase + ";" + "UID=" + currentUserId + ";" + "PASSWORD=" + currentUserPassword + ";";
        }

        public MySqlDbHelper()
        {
            currentServer = "127.0.0.1";
            currentDatabase = "note_app";
            currentUserId = "root";
            currentUserPassword = "Adilbaba22!";
            currentPortNumber = 2234;
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

        public User Login(String email, String password)
        {
            if (connection.State == ConnectionState.Closed && !OpenConnection())
                return null;

            command = new MySqlCommand
            {
                Connection = connection,
                CommandText = loginSQL
            };

            command.Parameters.Add("@PEMAIL", MySqlDbType.String);
            command.Parameters.Add("@PPASSWORD", MySqlDbType.String);

            command.Parameters["@PEMAIL"].Value = email;
            command.Parameters["@PPASSWORD"].Value = password;

            MySqlDataReader dataReader = command.ExecuteReader();

            if (dataReader.Read())
            {
                if (dataReader.IsDBNull(dataReader.GetOrdinal("ID")))
                {
                    return null;
                }
                else
                {
                    return new User()
                    {
                        Id = dataReader.GetInt32(dataReader.GetOrdinal("ID")),
                        Name = dataReader.GetString(dataReader.GetOrdinal("NAME")),
                        Surname = dataReader.GetString(dataReader.GetOrdinal("SURNAME")),
                        Email = dataReader.GetString(dataReader.GetOrdinal("EMAIL")),
                        Password = dataReader.GetString(dataReader.GetOrdinal("PASSWORD")),
                    };
                }

            }
            else
            {
                return null;
            }

        }

        public bool GetNotes(ref DataTable dataTable, int userId)
        {
            if (connection.State == ConnectionState.Closed && !OpenConnection())
                return false;

            command = new MySqlCommand
            {
                Connection = connection,
                CommandText = getNotesSQL
            };

            command.Parameters.Add("@PUSER_ID", MySqlDbType.Int32);
            command.Parameters["@PUSER_ID"].Value = userId;

            MySqlDataAdapter dataAdapter = new MySqlDataAdapter(command);
            dataAdapter.Fill(dataTable);

            connection.Close();

            return true;
        }

        public bool DeleteNote(int noteId)
        {
            if (connection.State == ConnectionState.Closed && !OpenConnection())
                return false;

            try
            {
                MySqlCommand command = new MySqlCommand
                {
                    Connection = connection,
                    CommandText = deleteNoteSQL
                };

                command.Parameters.Add("@PNOTE_ID", MySqlDbType.Int32);
                command.Parameters["@PNOTE_ID"].Value = noteId;
                command.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }

        }

        public bool AddNote(int userId, String title, String description)
        {
            if (connection.State == ConnectionState.Closed && !OpenConnection())
                return false;

            try
            {
                MySqlCommand command = new MySqlCommand
                {
                    Connection = connection,
                    CommandText = insertNoteSQL
                };

                command.Parameters.Add("@PUSER_ID", MySqlDbType.Int32);
                command.Parameters.Add("@PTITLE", MySqlDbType.String);
                command.Parameters.Add("@PDESCRIPTION", MySqlDbType.String);

                command.Parameters["@PUSER_ID"].Value = userId;
                command.Parameters["@PTITLE"].Value = title;
                command.Parameters["@PDESCRIPTION"].Value = description;

                command.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }

        }

        public bool UpdateNote(int noteId, String title, String description)
        {
            if (connection.State == ConnectionState.Closed && !OpenConnection())
                return false;

            try
            {
                MySqlCommand command = new MySqlCommand
                {
                    Connection = connection,
                    CommandText = updateNoteSQL
                };

                command.Parameters.Add("@PNOTE_ID", MySqlDbType.Int32);
                command.Parameters.Add("@PTITLE", MySqlDbType.String);
                command.Parameters.Add("@PDESCRIPTION", MySqlDbType.String);

                command.Parameters["@PNOTE_ID"].Value = noteId;
                command.Parameters["@PTITLE"].Value = title;
                command.Parameters["@PDESCRIPTION"].Value = description;

                command.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }

        }

        public Note GetNote(int noteId)
        {
            if (connection.State == ConnectionState.Closed && !OpenConnection())
                return null;

            command = new MySqlCommand
            {
                Connection = connection,
                CommandText = getNoteDetailsSQL
            };

            command.Parameters.Add("@PNOTE_ID", MySqlDbType.Int32);
            command.Parameters["@PNOTE_ID"].Value = noteId;

            MySqlDataReader dataReader = command.ExecuteReader();

            if (dataReader.Read())
            {
                return new Note()
                {
                    Id = dataReader.GetInt32(dataReader.GetOrdinal("ID")),
                    UserId = dataReader.GetInt32(dataReader.GetOrdinal("USER_ID")),
                    Title = dataReader.GetString(dataReader.GetOrdinal("TITLE")),
                    Description = dataReader.GetString(dataReader.GetOrdinal("DESCRIPTION")),
                };
            }
            else
            {
                return null;
            }
        }

        public User InsertUser(String name, String surname, String email, String password)
        {
            if (connection.State == ConnectionState.Closed && !OpenConnection())
                return null;

            try
            {
                MySqlCommand command = new MySqlCommand
                {
                    Connection = connection,
                    CommandText = insertUserSQL
                };

                command.Parameters.Add("@PNAME", MySqlDbType.String);
                command.Parameters.Add("@PSURNAME", MySqlDbType.String);
                command.Parameters.Add("@PEMAIL", MySqlDbType.String);
                command.Parameters.Add("@PPASSWORD", MySqlDbType.String);


                command.Parameters["@PNAME"].Value = name;
                command.Parameters["@PSURNAME"].Value = surname;
                command.Parameters["@PEMAIL"].Value = email;
                command.Parameters["@PPASSWORD"].Value = password;

                command.ExecuteNonQuery();

                int userId = Convert.ToInt32(command.LastInsertedId);

                if (userId > 0)
                {
                    return new User()
                    {
                        Id = userId,
                        Name = name,
                        Surname = surname,
                        Email = email,
                        Password = password,
                    };
                }
                else
                {
                    return null;
                }
            }
            catch
            {
                return null;
            }

        }


    }
}
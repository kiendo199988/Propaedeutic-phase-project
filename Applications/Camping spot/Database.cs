using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace Camping_spot
{
    class Database
    {
        public MySqlConnection connection;
        string connectionString = "Server=studmysql01.fhict.local;Uid=dbi413156;Database=dbi413156;Pwd=dbi413156;";

        public Database()
        {
            connection = new MySqlConnection(connectionString);
        }

        public void CheckIn(int id)
        {

            try
            {
                string sql = "UPDATE dbi413156 . account SET checked_cs = 1 WHERE Id = @id";
                connection.Open();
                MySqlCommand command = new MySqlCommand(sql, connection);
                command.Parameters.AddWithValue("id", id);
                command.ExecuteScalar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (connection != null)
                {
                    connection.Close();
                }
            }
        }

        public void CheckOut(int id)
        {

            try
            {
                string sql = "UPDATE dbi413156 . account SET checked_cs = 0 WHERE Id = @id";
                connection.Open();
                MySqlCommand command = new MySqlCommand(sql, connection);
                command.Parameters.AddWithValue("id", id);
                command.ExecuteScalar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (connection != null)
                {
                    connection.Close();
                }
            }

        }
        //public int CheckAccount()
        //{
        //    int account = 0;
        //    MySqlDataReader reader = null;
        //    try
        //    {
        //        string sql = "SELECT COUNT(*) FROM account WHERE account.id = ?";
        //        connection.Open();
        //        MySqlCommand command = new MySqlCommand(sql, connection);
        //        //command.ExecuteScalar();
        //        reader = command.ExecuteReader();
        //        while (reader.Read())
        //        {
        //            account = Convert.ToInt32(reader["account"]);
        //        }
        //    }
        //    catch(Exception ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //    }
        //    finally
        //    {
        //        if (connection != null)
        //        {
        //            connection.Close();
        //        }
        //    }
        //    return account;
        //}

    }
}


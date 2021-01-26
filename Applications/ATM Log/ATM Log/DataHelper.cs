using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace ATM_Log
{
    class DataHelper
    {
        public MySqlConnection connection;
        string connectionString = "Server=studmysql01.fhict.local;Uid=dbi413156;Database=dbi413156;Pwd=dbi413156;";
        
        public DataHelper()
        {
            connection = new MySqlConnection(connectionString);
        }
        public bool AddMoneyToAccount(List<int> ids, List<Decimal> amounts)
        {
            //MySqlConnection newConnection = new MySqlConnection(connectionString);
            //MySqlDataReader reader = null;
            //string mysqlReader = "SELECT * FROM `account` WHERE `Id` = @id";

            try
            {
                connection.Open();
                //MySqlCommand command = new MySqlCommand(mysqlReader, newConnection);
                //command.Parameters.AddWithValue("@id", id);
                //reader = command.ExecuteReader();

                string sql = "UPDATE `dbi413156`.`account` SET `balance` = balance+@amount WHERE Id = @id";
                for(int i =0; i < ids.Count; i++)
                {
                    MySqlCommand command = new MySqlCommand(sql,connection);
                    command.Parameters.AddWithValue("@amount", amounts[i]);
                    command.Parameters.AddWithValue("@id", ids[i]);
                    command.ExecuteScalar();
                }

                

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if(connection != null)
                {
                    connection.Close();
                }
            }
            return true;
        }

        public void updateMoney(int id, decimal amount)
        {
            try
            {
                connection.Open();
                string sql = "UPDATE `dbi413156`.`account` SET `balance` = balance+@amount WHERE `Id` = @id";
                MySqlCommand command = new MySqlCommand(sql, connection);
                command.Parameters.AddWithValue("@amount", amount);
                command.Parameters.AddWithValue("@id", id);
                command.ExecuteScalar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void UpdateDeposit(decimal deposit)
        {
            try
            {
                string sql = "UPDATE `dbi413156`.`balance` SET `total_deposit` = total_deposit+@amount";
                connection.Open();
                MySqlCommand command = new MySqlCommand(sql, connection);
                command.Parameters.AddWithValue("@amount", deposit);
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
    }
}

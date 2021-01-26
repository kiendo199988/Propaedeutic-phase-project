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


namespace loanApp
    {
    class DatabaseConnection
    {       
        public MySqlConnection connection;     
        string connectiontring = "server=studmysql01.fhict.local;user id=dbi413156;database=dbi413156;password=dbi413156";
        public DatabaseConnection()
        {
            connection = new MySqlConnection(connectiontring);
        }

        public string GetProductNameById(int id)
        {
            try
            {
                
                string sql1 = "SELECT name FROM loan where id=" + id;

                MySqlCommand command1 = new MySqlCommand(sql1, connection);

                connection.Open();
                MySqlDataReader DR7 = command1.ExecuteReader();

                string data = "";
                if (DR7.Read())
                {
                    data = (DR7.GetValue(0).ToString());
                }
                connection.Close();
                return data.ToString();
            }
            catch (MySqlException m)
            {
                System.Windows.Forms.MessageBox.Show("exception caught");
            }
            finally
            {
                
                if (connection != null)
                {
                    connection.Close();

                }
            }
            return "";
        }

        public void Return(int productId)
        {
            try
            {
                connection.Open();
                MySqlCommand command = new MySqlCommand();
                command.CommandText = "update loan set borrower=null where id=@productId";
                command.Parameters.AddWithValue("@productId", productId);
                command.Connection = connection;
                command.ExecuteNonQuery();
                if (command.CommandText == null)
                {
                    connection.Close();
                   // return false;
                }
                else
                {
                    connection.Close();

                    //return true;
                }
            }
            catch (MySqlException m)
            {
                return;
            }
            finally
            {
                if (connection != null)
                {
                    connection.Close();
                }
            }
        }

        public List<int> GetLoanedItems(int id)
        {
            
            List<int> results = new List<int>();
            try
            {            
                string sql1 = "SELECT id FROM loan where borrower=" + id;
                MySqlCommand command1 = new MySqlCommand(sql1, connection);
                connection.Open();
                MySqlDataReader DR7 = command1.ExecuteReader();
               // MySqlDataReader DR8 = command1.ExecuteReader();
                while (DR7.Read())
                {
                    int itm = int.Parse(DR7.GetValue(0).ToString());
                    //string cd = DR7.GetValue(1).ToString();                 
                    results.Add(int.Parse(itm.ToString()));                   
                }              
                connection.Close();
                return results;
            }
            catch (MySqlException m)
            {
                System.Windows.Forms.MessageBox.Show("exception caught");
            }
            finally
            {
                //System.Windows.Forms.MessageBox.Show("Test");
                if (connection != null)
                {
                    connection.Close();
                }
            }
            return results;
        }

        public string LastPrReturned(int id)
        {

            string name = "";

            try
            {
                string sql1 = "SELECT name FROM loan where id=" + id;
                MySqlCommand command1 = new MySqlCommand(sql1, connection);
                connection.Open();
                MySqlDataReader DR7 = command1.ExecuteReader();
               
                while (DR7.Read())
                {
                    name = DR7.GetValue(0).ToString();
                    //string cd = DR7.GetValue(1).ToString();

                    //results.Add(itm.ToString());

                }
                connection.Close();
                return name;
            }
            catch (MySqlException m)
            {
                System.Windows.Forms.MessageBox.Show("exception caught");
            }
            finally
            {
                //System.Windows.Forms.MessageBox.Show("Test");
                if (connection != null)
                {
                    connection.Close();
                }
            }
            return name;
        }

        public List<string> GetItemsName(int id)
        {

            List<string> results = new List<string>();

            try
            {
                string sql1 = "SELECT name FROM loan where borrower=" + id;
                MySqlCommand command1 = new MySqlCommand(sql1, connection);
                connection.Open();
                MySqlDataReader DR7 = command1.ExecuteReader();
                // MySqlDataReader DR8 = command1.ExecuteReader();
                while (DR7.Read())
                {
                    string itm = DR7.GetValue(0).ToString();
                    //string cd = DR7.GetValue(1).ToString();

                    results.Add(itm.ToString());

                }
                connection.Close();
                return results;
            }
            catch (MySqlException m)
            {
                System.Windows.Forms.MessageBox.Show("exception caught");
            }
            finally
            {
                //System.Windows.Forms.MessageBox.Show("Test");
                if (connection != null)
                {
                    connection.Close();
                }
            }
            return results;
        }

        public void DecreaseBalnce(int id, decimal amount)
        {
            try
            {
                connection.Open();
                MySqlCommand command = new MySqlCommand();
                command.CommandText = "update account set balance=(balance-@amount) where id=@id";
                command.Parameters.AddWithValue("@id", id);
                command.Parameters.AddWithValue("@amount", amount);
                command.Connection = connection;
                command.ExecuteNonQuery();
            }
            catch (MySqlException m)
            {
                return;
            }
            finally
            {
                //System.Windows.Forms.MessageBox.Show("Test");
                if (connection != null)
                {
                    connection.Close();
                }
            }
        }

        public bool IsAlreadyLanded(int productId)
        {
            try
            {
                connection.Open();
                MySqlCommand command = new MySqlCommand();
                command.CommandText = "select borrower from loan where id=@productId";
                command.Parameters.AddWithValue("@productId", productId);
                command.Connection = connection;
                command.ExecuteNonQuery();
                if (command.CommandText==null)
                {
                    connection.Close();
                    return false;
                }
                else
                {
                    connection.Close();

                    return true;
                }              
            }
            catch (MySqlException m)
            {
                return true ;
            }
            finally
            {              
                if (connection != null)
                {
                    connection.Close();
                }
            }
        }

        public void Loan(int id, int productId)
        {
            try
            {
                connection.Open();
                MySqlCommand command = new MySqlCommand();
                //System.Windows.Forms.MessageBox.Show("Test");

                command.CommandText = "update loan set borrower=@id where id=@productId";
                command.Parameters.AddWithValue("@id", id);
                command.Parameters.AddWithValue("@productId", productId);
                command.Connection = connection; 
                command.ExecuteNonQuery();
            }
            catch (MySqlException m)
            {
                return;
            }
            finally
            {
                //System.Windows.Forms.MessageBox.Show("Test");
                if (connection != null)
                {
                    connection.Close();
                }
            }
        }


        public void InsertD(string name, decimal price )
        {
            try
            {
                connection.Open();
                MySqlCommand command = new MySqlCommand();
                //System.Windows.Forms.MessageBox.Show("Test");

                command.CommandText = "INSERT INTO loan (name, price)" +
                    "VALUES(@name, @price)";
                command.Parameters.AddWithValue("@name", name);
                command.Parameters.AddWithValue("@price", price);
                command.Connection = connection;              
                command.ExecuteNonQuery();
            }
            catch (MySqlException m)
            {
                return;
            }
            finally
            {
                //System.Windows.Forms.MessageBox.Show("Test");
                if (connection != null)
                {
                    connection.Close();
                }
            }
        }

        public void GiveD()
        {
            try
            {
                string sql1 = "SELECT name FROM age where name='Rares'";
                string sql2 = "SELECT age FROM age where name='Rares'";


                MySqlCommand command1 = new MySqlCommand(sql1, connection);
                MySqlCommand command2 = new MySqlCommand(sql2, connection);

                connection.Open();
                MySqlDataReader DR1 = command1.ExecuteReader();
                MySqlDataReader DR2 = command2.ExecuteReader();

                string name ="";
                string age = "";
                if (DR1.Read())
                {
                    name = DR1.GetValue(0).ToString();
                    age = DR2.GetValue(0).ToString();
                    string data = name +" " +age;
                    System.Windows.Forms.MessageBox.Show(data);
                }
                connection.Close();     
            }
            catch (MySqlException m)
            {
                return;
            }
            finally
            {
                //System.Windows.Forms.MessageBox.Show("Test");
                if (connection != null)
                {
                    connection.Close();
                }
            }
        }

        //receit
        public string GetPurchaseInfo(int id)
        {
            try
            {
                //MySqlCommand command = new MySqlCommand();
                string sql1 = "SELECT price FROM loan where id="+id;

                MySqlCommand command1 = new MySqlCommand(sql1, connection);

                connection.Open();
               MySqlDataReader DR7 = command1.ExecuteReader();

                decimal data = 0;
                if (DR7.Read())
                {
                    data = decimal.Parse(DR7.GetValue(0).ToString());
                    //System.Windows.Forms.MessageBox.Show(data);
                }
                connection.Close();
                return data.ToString();
            }
            catch (MySqlException m)
            {
                System.Windows.Forms.MessageBox.Show("exception caught");
            }
            finally
            {
                //System.Windows.Forms.MessageBox.Show("Test");
                if (connection != null)
                {
                    connection.Close();

                }
            }
            return "";
        }

        public decimal GetBalance(int id)
        {
            try
            {
                //MySqlCommand command = new MySqlCommand();
                string sql1 = "SELECT balance FROM account where id=" + id;

                MySqlCommand command1 = new MySqlCommand(sql1, connection);

                connection.Open();
                MySqlDataReader DR7 = command1.ExecuteReader();

                decimal data = 0;
                if (DR7.Read())
                {
                    data = decimal.Parse(DR7.GetValue(0).ToString());
                    //System.Windows.Forms.MessageBox.Show(data);
                }
                connection.Close();
                return data;
            }
            catch (MySqlException m)
            {
                System.Windows.Forms.MessageBox.Show("exception caught");
            }
            finally
            {
                //System.Windows.Forms.MessageBox.Show("Test");
                if (connection != null)
                {
                    connection.Close();

                }
            }
            return 0;
        }

        public string GetCustomerName(int id)
        {
            try
            {
                //MySqlCommand command = new MySqlCommand();
                string sql1 = "SELECT first_name FROM account where id=" + id;

                MySqlCommand command1 = new MySqlCommand(sql1, connection);

                connection.Open();
                MySqlDataReader DR7 = command1.ExecuteReader();

                string data = "";
                if (DR7.Read())
                {
                    data = (DR7.GetValue(0).ToString());
                    //System.Windows.Forms.MessageBox.Show(data);
                }
                connection.Close();
                return data.ToString();
            }
            catch (MySqlException m)
            {
                System.Windows.Forms.MessageBox.Show("exception caught");
            }
            finally
            {
                //System.Windows.Forms.MessageBox.Show("Test");
                if (connection != null)
                {
                    connection.Close();

                }
            }
            return "";
        }


        public string GetQuantity()
        {
            try
            {

                //MySqlCommand command = new MySqlCommand();
                string sql1 = "SELECT count(id) FROM loan where name='ear plug' and borrower is null";

                MySqlCommand command1 = new MySqlCommand(sql1, connection);

                connection.Open();
                MySqlDataReader DR1 = command1.ExecuteReader();

                string data = "";
                if (DR1.Read())
                {
                    data = DR1.GetValue(0).ToString();
                    //System.Windows.Forms.MessageBox.Show(data);
                }
                connection.Close();
                return data;
            }
            catch (MySqlException m)
            {
                System.Windows.Forms.MessageBox.Show("exception caught");
            }
            finally
            {
                //System.Windows.Forms.MessageBox.Show("Test");
                if (connection != null)
                {
                    connection.Close();

                }

            }
                                return "";

        }

        public string GetQuantity2()
        {
            try
            {

                //MySqlCommand command = new MySqlCommand();
                string sql2 = "SELECT count(id) FROM loan where name='phone charger' and borrower is null";

                MySqlCommand command1 = new MySqlCommand(sql2, connection);

                connection.Open();
                MySqlDataReader DR2 = command1.ExecuteReader();

                string data = "";
                if (DR2.Read())
                {
                    data = DR2.GetValue(0).ToString();
                    //System.Windows.Forms.MessageBox.Show(data);
                }
                connection.Close();
                return data;
            }
            catch (MySqlException m)
            {
                System.Windows.Forms.MessageBox.Show("phone charger");
            }
            finally
            {
                //System.Windows.Forms.MessageBox.Show("Test");
                if (connection != null)
                {
                    connection.Close();

                }

            }
            return "";

        }

        public string GetQuantity3()
        {
            try
            {

                //MySqlCommand command = new MySqlCommand();
                string sql3 = "SELECT count(id) FROM loan where name='laptop charger' and borrower is null";

                MySqlCommand command1 = new MySqlCommand(sql3, connection);

                connection.Open();
                MySqlDataReader DR3 = command1.ExecuteReader();

                string data = "";
                if (DR3.Read())
                {
                    data = DR3.GetValue(0).ToString();
                    //System.Windows.Forms.MessageBox.Show(data);
                }
                connection.Close();
                return data;
            }
            catch (MySqlException m)
            {
                System.Windows.Forms.MessageBox.Show("exception caught");
            }
            finally
            {
                //System.Windows.Forms.MessageBox.Show("Test");
                if (connection != null)
                {
                    connection.Close();

                }

            }
            return "";

        }

        public string GetQuantity4()
        {
            try
            {

                //MySqlCommand command = new MySqlCommand();
                string sql4 = "SELECT count(id) FROM loan where name='speaker' and borrower is null";

                MySqlCommand command1 = new MySqlCommand(sql4, connection);

                connection.Open();
                MySqlDataReader DR4 = command1.ExecuteReader();

                string data = "";
                if (DR4.Read())
                {
                    data = DR4.GetValue(0).ToString();
                    //System.Windows.Forms.MessageBox.Show(data);
                }
                connection.Close();
                return data;
            }
            catch (MySqlException m)
            {
                System.Windows.Forms.MessageBox.Show("exception caught");
            }
            finally
            {
                //System.Windows.Forms.MessageBox.Show("Test");
                if (connection != null)
                {
                    connection.Close();

                }

            }
            return "";


        

        }

        public string GetQuantity5()
        {
            try
            {

                //MySqlCommand command = new MySqlCommand();
                string sql5 = "SELECT count(id) FROM loan where name='external battery' and borrower is null";

                MySqlCommand command1 = new MySqlCommand(sql5, connection);

                connection.Open();
                MySqlDataReader DR5 = command1.ExecuteReader();

                string data = "";
                if (DR5.Read())
                {
                    data = DR5.GetValue(0).ToString();
                    //System.Windows.Forms.MessageBox.Show(data);
                }
                connection.Close();
                return data;
            }
            catch (MySqlException m)
            {
                System.Windows.Forms.MessageBox.Show("exception caught");
            }
            finally
            {
                //System.Windows.Forms.MessageBox.Show("Test");
                if (connection != null)
                {
                    connection.Close();

                }

            }
            return "";

        }







    }
}

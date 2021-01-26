using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace Food_and_Drink_App
{
    class DataHelper
    {
        public MySqlConnection connection;
        string connectionString = "Server=studmysql01.fhict.local;Uid=dbi413156;Database=dbi413156;Pwd=dbi413156;";

        public DataHelper()
        {
            connection = new MySqlConnection(connectionString);
        }
        //decrease balance of the visitor
        public void DecreaseVisitorBalance(int id, decimal totalPrice)
        {
            try
            {
                string sql = "UPDATE `dbi413156`.`account` SET `balance` = balance - @totalPrice WHERE Id = @id";
                connection.Open();
                MySqlCommand command = new MySqlCommand(sql, connection);
                command.Parameters.AddWithValue("id", id);
                command.Parameters.AddWithValue("totalPrice", totalPrice);
                command.ExecuteScalar();
                //reader = command.ExecuteReader();

                //while (reader.Read())
                //{
                //    balance = Convert.ToDecimal(reader["balance"]);
                //}
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
            //    if (reader != null)
            //    {
            //        reader.Close();
            //    }
            }
        }

        //get balance of the visitor
        public decimal GetVisitorBalance(int id)
        {
            decimal balance = 0;
            MySqlDataReader reader = null;

            try
            {
                string sql = "SELECT balance FROM account WHERE Id=@id";
                connection.Open();
                MySqlCommand command = new MySqlCommand(sql, connection);
                command.Parameters.AddWithValue("id", id);
                reader = command.ExecuteReader();

                while (reader.Read())
                {
                    balance = Convert.ToDecimal(reader["balance"]);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (connection != null)
                {
                    connection.Close();
                }
                if (reader != null)
                {
                    reader.Close();
                }
            }
            return balance;
        }

        //increase nr of sold items
        public void IncreaseNrOfSoldItems(List<int> ids, List<int> amounts)
        {
            try
            {
                connection.Open();
                string sql = "UPDATE `dbi413156`.`food` SET `sold_items` = sold_items+@amount WHERE ProductID = @id";

                for (int i = 0; i < ids.Count; i++)
                {
                    MySqlCommand command = new MySqlCommand(sql, connection);
                    command.Parameters.AddWithValue("@amount", amounts[i]);
                    command.Parameters.AddWithValue("@id", ids[i]);
                    command.ExecuteScalar();
                }
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

        //decrease product quantity
        public void decreaseProductQuantity(List<int> ids,List<int> amounts)
        {
            try
            {
                connection.Open();
                string sql = "UPDATE `dbi413156`.`food` SET `quantity` = quantity-@amount WHERE ProductID = @id";
                for (int i = 0; i < ids.Count; i++)
                {
                    MySqlCommand command = new MySqlCommand(sql, connection);
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
                if (connection != null)
                {
                    connection.Close();
                }
            }


        }
        //get product by id
        public Product GetProduct(int id)
        {
            Product pr = null;
            int productId;
            string name;
            int quantity;
            decimal price;
            MySqlDataReader reader = null;

            try
            {
                string mysql = "SELECT * FROM dbi413156.food WHERE ProductID =@id";
                connection.Open();
                MySqlCommand command = new MySqlCommand(mysql, connection);
                command.Parameters.AddWithValue("id", id);
                reader = command.ExecuteReader();

                while (reader.Read())
                {
                    productId = Convert.ToInt32(reader["ProductID"]);
                    name = Convert.ToString(reader["name"]);
                    quantity = Convert.ToInt32(reader["quantity"]);
                    price = Convert.ToDecimal(reader["price"]);
                    pr = new Product(productId, name, quantity, price);
                }
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
                if (reader != null)
                {
                    reader.Close();
                }
            }

            return pr;
        }

        //get list of products
        public List<Product> GetAllProductsDB()
        {
            MySqlConnection connectionnew = new MySqlConnection(connectionString);
            string sql = "SELECT * FROM food";
            MySqlCommand command = new MySqlCommand(sql, connectionnew);
            List<Product> pr = new List<Product>();
            Product P = null;
            MySqlDataReader reader = null;

            try
            {
                connectionnew.Open();
                reader = command.ExecuteReader();

                int productID;
                string name;
                int quantity;
                decimal price;


                while (reader.Read())
                {

                    productID = Convert.ToInt32(reader["ProductID"]);
                    name = Convert.ToString(reader["name"]);
                    quantity = Convert.ToInt32(reader["quantity"]);
                    price = Convert.ToDecimal(reader["price"]);


                    P = new Product(productID, name, quantity, price);

                    pr.Add(P);
                }
            }

            catch (MySqlException)
            {
                MessageBox.Show("Something went wrong!");
            }

            finally
            {
                if (connectionnew != null)
                {
                    connection.Close();
                }
                if (reader != null)
                {
                    reader.Close();
                }
            }

            return pr;
        }

        public void UpdateProfit()
        {
            try
            {
                string sql = "UPDATE `dbi413156`.`food` SET `profit` = sold_items*price";
                connection.Open();
                MySqlCommand command = new MySqlCommand(sql, connection);
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

        // get visitor age
        public int GetVisitorAge(int id)
        {
            int age = 0;
            DateTime now = DateTime.Now;
            DateTime dob=DateTime.MinValue;
            MySqlDataReader reader = null;
            try
            {
                string sql = "SELECT dob FROM account WHERE Id=@id";
                connection.Open();
                MySqlCommand command = new MySqlCommand(sql, connection);
                command.Parameters.AddWithValue("id", id);
                reader = command.ExecuteReader();

                while (reader.Read())
                {
                    dob = Convert.ToDateTime(reader["dob"]);
                }
                age = now.Year - dob.Year;  
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
            return age;
        }
    }
}

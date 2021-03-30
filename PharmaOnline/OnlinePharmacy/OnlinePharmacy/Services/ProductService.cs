using MySql.Data.MySqlClient;
using OnlinePharmacy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlinePharmacy.Services
{
    public class ProductService : MySQLService
    {
        public ProductService() : base()
        {

        }
        public List<Product> getAllByUserId()
        {
            List<Product> list = new List<Product>();

            try
            {
                string selectString = "select * from product";
                connection.Open();

                MySqlCommand cmd = new MySqlCommand(selectString, connection);
                MySqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read() && rdr.HasRows)
                {
                    list.Add(Product.convertFromSqlReader(rdr.GetValue(0), rdr.GetValue(1), rdr.GetValue(2), rdr.GetValue(3), rdr.GetValue(4), rdr.GetValue(5)));
                }
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.Message);
            }
            finally
            {
                connection.Close();

            }

            return list;
        }

        public bool insert(string name, int price_per_unit, int units, string tag, byte[] picture)
        {
            try
            {
                string insertCmd = "INSERT INTO PRODUCT (name,price_per_unit, picture,units,tag) VALUES (@name, @price_per_unit, @picture, @units, @tag)";
                connection.Open();

                MySqlCommand comm = connection.CreateCommand();
                comm.CommandText = insertCmd;
                comm.Parameters.AddWithValue("@name", name);
                comm.Parameters.AddWithValue("@price_per_unit", price_per_unit);
                comm.Parameters.AddWithValue("@picture", picture);
                comm.Parameters.AddWithValue("@units", units);
                comm.Parameters.AddWithValue("@tag", tag);
                comm.ExecuteNonQuery();
                return true;
            }catch(Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.Message);
                return false;
            }
            finally
            {
                connection.Close();
            
            }
           
        }

        public bool updateUnitsOfProduct(int product_id, int newUnits)
        {
            try
            {
                string insertCmd = "UPDATE product SET units = @newUnits WHERE product_id = @product_id";

                connection.Open();

                MySqlCommand comm = connection.CreateCommand();
                comm.CommandText = insertCmd;
                comm.Parameters.AddWithValue("@product_id", product_id);
                comm.Parameters.AddWithValue("@newUnits", newUnits);
                comm.ExecuteNonQuery();

                return true;
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.Message);
                return false;
            }
            finally
            {
                connection.Close();

            }
        }
    }
}
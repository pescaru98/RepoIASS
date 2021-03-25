using MySql.Data.MySqlClient;
using OnlinePharmacy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlinePharmacy.Services
{
    public class CartService : MySQLService
    {
        public CartService() : base()
        {
        }

        public List<VW_Cart_Product> getAllByUserId(int user_id)
        {
            List<VW_Cart_Product> list = new List<VW_Cart_Product>();

            try
            {
                string selectString = "select * from vw_cart_product where user_id = @user_id";
                connection.Open();

                MySqlCommand cmd = new MySqlCommand(selectString, connection);
                cmd.Parameters.AddWithValue("@user_id", user_id);
                MySqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read() && rdr.HasRows)
                {
                    list.Add(VW_Cart_Product.convertFromSqlReader(rdr.GetValue(0), rdr.GetValue(1), rdr.GetValue(2), rdr.GetValue(3), rdr.GetValue(4), rdr.GetValue(5), rdr.GetValue(6), rdr.GetValue(7), rdr.GetValue(8)));
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

        public bool removeProductFromCart(int cart_product_id)
        {
            try
            {
                string deleteString = "delete from cart_product where cart_product_id = @cart_product_id";
                connection.Open();

                MySqlCommand cmd = new MySqlCommand(deleteString, connection);
                cmd.Parameters.AddWithValue("@cart_product_id", cart_product_id);

                cmd.ExecuteNonQuery();

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

        public bool removeProductsOfUserId(int user_id)
        {
            try
            {
                string deleteString = "delete from cart_product where user_id = @user_id";
                connection.Open();

                MySqlCommand cmd = new MySqlCommand(deleteString, connection);
                cmd.Parameters.AddWithValue("@user_id", user_id);

                cmd.ExecuteNonQuery();

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
using MySql.Data.MySqlClient;
using OnlinePharmacy.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace OnlinePharmacy.Services
{
    public class OrderService : MySQLService
    {
        public OrderService() : base()
        {
        }

        public bool addOrderSetWithProducts(int user_id, DateTime issue_date, string product_ids, string units_ids, string current_price_per_units_ids)
        {
            try
            {
                connection.Open();
                MySqlCommand cmd = new MySqlCommand("order_create", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@p_user_id", user_id);
                cmd.Parameters.AddWithValue("@p_issue_date", issue_date);
                cmd.Parameters.AddWithValue("@p_product_ids", product_ids);
                cmd.Parameters.AddWithValue("@p_units", units_ids);
                cmd.Parameters.AddWithValue("@p_current_price_per_units", current_price_per_units_ids);
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
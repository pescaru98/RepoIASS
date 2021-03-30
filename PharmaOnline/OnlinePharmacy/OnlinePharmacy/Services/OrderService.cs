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

        public List<VW_Order_Product> getAllOrderProductsOfUserId(int user_id)
        {
            List<VW_Order_Product> list = new List<VW_Order_Product>();

            try
            {
                string selectString = "select * from vw_order_product where user_id = @user_id";
                connection.Open();

                MySqlCommand cmd = new MySqlCommand(selectString, connection);
                cmd.Parameters.AddWithValue("@user_id", user_id);
                MySqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read() && rdr.HasRows)
                {
                    list.Add(VW_Order_Product.convertFromSqlReader(rdr.GetValue(0), rdr.GetValue(1), rdr.GetValue(2), rdr.GetValue(3), rdr.GetValue(4), rdr.GetValue(5), rdr.GetValue(6), rdr.GetValue(7), rdr.GetValue(8), rdr.GetValue(9), rdr.GetValue(10)));
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
    }
}
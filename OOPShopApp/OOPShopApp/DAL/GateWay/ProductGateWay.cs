using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OOPShopApp.DAL.DAO;

namespace OOPShopApp.DAL.GateWay
{
    class ProductGateWay
    {
        private SqlConnection connection;

         public ProductGateWay()
        {
            string conn = ConfigurationManager.ConnectionStrings["ProductDB"].ConnectionString;
            connection = new SqlConnection(conn);
            connection.ConnectionString = conn;
        }
        public void SaveProduct(Product aProduct)
        {
            connection.Open();
            string query = string.Format("INSERT INTO t_Product VALUES(@CODE,@NAME,@QUANTITY)");
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.Add(new SqlParameter("@CODE", aProduct.Code));
            command.Parameters.Add(new SqlParameter("@NAME", aProduct.Name));
            command.Parameters.Add(new SqlParameter("@QUANTITY", aProduct.Quantity));
            command.ExecuteNonQuery();
            connection.Close();

        }

        public List<Product> GetAllProduct()
        {
            connection.Open();
            string query = String.Format("SELECT* FROM t_Product");
            SqlCommand command = new SqlCommand(query, connection);
            SqlDataReader aReader = command.ExecuteReader();
            List<Product> allProductList = new List<Product>();


            if (aReader.HasRows)
            {
                while (aReader.Read())
                {
                    Product aProduct = new Product();
                    aProduct.Code = aReader[1].ToString();
                    aProduct.Name = aReader[2].ToString();
                    aProduct.Quantity = (int) aReader[3];
                    allProductList.Add(aProduct);
                   
                }
            }
            connection.Close();
            return allProductList;
        }

        public bool HasThisNameValid(string name)
        {
            connection.Open();
            string query = string.Format("SELECT * FROM t_Product WHERE name=@name");
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.Add(new SqlParameter("@name", name));
            SqlDataReader aReader = command.ExecuteReader();
            bool Hasrow = aReader.HasRows;
            connection.Close();
            return Hasrow;
        }

        public bool HasThisCodeValid(string code)
        {
            connection.Open();
            string query = string.Format("SELECT * FROM t_Product WHERE code=@code");
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.Add(new SqlParameter("@code", code));
            SqlDataReader aReader = command.ExecuteReader();
            bool Hasrow = aReader.HasRows;
            connection.Close();
            return Hasrow;
        }
    }
}

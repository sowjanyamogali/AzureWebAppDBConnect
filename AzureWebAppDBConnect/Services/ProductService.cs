using System.Data.SqlClient;
using AzureWebAppDBConnect.Models;
namespace AzureWebAppDBConnect.Services
{
    public class ProductService
    {
        private static string db_source = "azureappserver100.database.windows.net";
        private static string db_user = "sqlazureuser";
        private static string db_pwd = "Darsh@123";
        private static string db_database = "azureappdb";

        private SqlConnection GetConnection()
        {
            var _builder = new SqlConnectionStringBuilder();
            _builder.DataSource = db_source;
            _builder.UserID = db_user;
            _builder.Password = db_pwd;
            _builder.InitialCatalog = db_database;
            return new SqlConnection(_builder.ConnectionString);
        }
        
        public List<Product> GetProducts()
        {
            SqlConnection conn = GetConnection();
            List<Product> _prodList = new List<Product>();
            string statement = "SELECT ProductID, ProductName, Quantity from Products";
            conn.Open();
            SqlCommand cmd = new SqlCommand(statement, conn);
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    Product prod = new Product()
                    {
                        ProductId = reader.GetInt32(0),
                        ProductName = reader.GetString(1),
                        Quantity = reader.GetInt32(2)
                    };
                    _prodList.Add(prod);
                }
            }
            conn.Close();
            return _prodList;                    
        }
    }
}

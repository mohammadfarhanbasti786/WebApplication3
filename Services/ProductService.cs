using System.Data.SqlClient;
using WebApplication3.Models;
using WebApplication3.Pages.Shared;
namespace WebApplication3.Services
{
    public class ProductService
    {
        private static string db_source = "mohammadfarhan.database.windows.net";
        private static string db_user = "mohammadfarhanbasti";
        private static string db_password = "Fa#@%1001";
        private static string db_database = "Mohammad Farhan";

        private SqlConnection GetConnection()
        {
            var _builder= new SqlConnectionStringBuilder();
            _builder.DataSource = db_source;
            _builder.UserID = db_user;  
            _builder.Password = db_password;
            _builder.InitialCatalog = db_database;
            return new SqlConnection(_builder.ConnectionString);
          
        }
        public List<Product> GetProducts()
        {
            List<Product> _products_list = new List<Product>();
            SqlConnection _connection =GetConnection();
            Console.Write(_connection);
            string _statement = "SELECT PRODUCTID,PRODUCTNAME,QUANTITY FROM PRODUCTS";
            _connection.Open(); 
            SqlCommand _sqlcommand=new SqlCommand(_statement, _connection);
            using (SqlDataReader _reader= _sqlcommand.ExecuteReader())
            {
                while (_reader.Read()) { 
                    Product _product=new Product() {
                        ProductID=_reader.GetInt32(0),
                        ProductName=_reader.GetString(1),
                        Quality=_reader.GetInt32(2),   
                    };
                    _products_list.Add(_product);
                }
            }
            _connection.Close();    
            return _products_list;

        }
    }
}

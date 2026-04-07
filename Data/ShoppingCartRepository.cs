using Microsoft.Data.SqlClient;

namespace SportsStore_Spr2026.Data
{
    public class ShoppingCartRepository : IShoppingCartRepository
    {


        private readonly string _connectionString;

        public ShoppingCartRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }







        public void AddToCart(string cartID, int prodID)
        {
            using var connection = new SqlConnection(_connectionString);
            using var command = new SqlCommand("spAddToCart", connection);

            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Parameters.Add(new SqlParameter("@cartID", cartID));
            command.Parameters.Add(new SqlParameter("@prodID", prodID));
            command.Parameters.Add(new SqlParameter("@attributes", "none"));

            connection.Open();
            command.ExecuteNonQuery();
        }
    }
}

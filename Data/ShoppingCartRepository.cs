using Microsoft.Data.SqlClient;
using SportsStore_Spr2026.Models;

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


        public List<ShoppingCart> LoadCartItems(string cartID, out decimal cartTotal)
        {
            List<ShoppingCart> cartItems = new List<ShoppingCart>();
            cartTotal = 0;

            using var connection = new SqlConnection(_connectionString);
            using var command = new SqlCommand("spGetCartItems", connection);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@cartID", cartID);

           
            connection.Open();

            using var reader = command.ExecuteReader();
            while (reader.Read())
            {
                cartItems.Add(new ShoppingCart
                {
                    CartID = reader.GetString(0),
                    ProductID = reader.GetInt32(1),
                    ProductName = reader.GetString(2),
                    Quantity = reader.GetInt32(4),
                    Price = reader.GetDecimal(3),
                    Subtotal = reader.GetDecimal(5)
                });
            }

            
            if (cartItems.Any())
    {
        cartTotal = cartItems.Sum(item => item.Subtotal);
    }

    return cartItems;
}
    }
}

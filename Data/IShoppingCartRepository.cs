using SportsStore_Spr2026.Models;

namespace SportsStore_Spr2026.Data
{
    public interface IShoppingCartRepository
    {

        void AddToCart(string cartID, int prodID);


        public List<ShoppingCart> LoadCartItems(string cartID, out decimal cartTotal);

        


    }
}

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SportsStore_Spr2026.Data;
using SportsStore_Spr2026.Models;

namespace SportsStore_Spr2026.Pages.Customers.Home
{
    public class ShoppingCartModel : PageModel
    {
        private readonly IShoppingCartRepository _shoppingCartRepository;


        public ShoppingCartModel(IShoppingCartRepository shoppingCartRepository)
        {
            _shoppingCartRepository = shoppingCartRepository;
        }



        //create the cartitems

        //bind property to the list of shopping cart items so we can display them on the page. needed for form 
        //because we need to post the data back to the server when the user updates the cart.
        [BindProperty]
        public List<ShoppingCart> CartItems { get; set; } = new List<ShoppingCart>();



        public decimal CartTotal { get; set; }
        public string CartID { get; private set; }

        //these dont have any value so we have to set them within the OnGet method




        public void OnGet()
        {
            //user has to be logged in to see the shopping cart. 
            CartID = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;

            CartItems = _shoppingCartRepository.LoadCartItems(CartID, out decimal cartTotal);
            CartTotal = cartTotal;










        }
        public IActionResult OnPost()
        {

            CartID = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;

            if (ModelState.IsValid)
            {
                foreach (var item in CartItems)
                {
                    _shoppingCartRepository.AddToCart(CartID, item.Quantity);




                }


                CartItems = _shoppingCartRepository.LoadCartItems(CartID, out decimal cartTotal);
                CartTotal = cartTotal;



            }

            return Page();
        }
    }
}

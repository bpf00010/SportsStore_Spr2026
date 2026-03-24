using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SportsStore_Spr2026.Data;
using SportsStore_Spr2026.Models;

namespace SportsStore_Spr2026.Pages.Products
{
    public class CreateModel : PageModel
    {


        private readonly IProductRepository _productRepository;

        //then bring in the constructor
        public CreateModel(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public Product product { get; set; }
        public void OnGet()
        {
            //need to use a post method to create a product and then we can use the on get method to display the form to the user and then we can use the on post method to get the data from the form and then we can use it to create a product in the database.
            //there is no product defined here so we need to 

        }
        public IActionResult OnPost() 
        {
            //so we need to get the data from the form and then we can use it to create a product in the database.
            //use the ProductRepository to talk to the database and create a product in the database.
            _productRepository.CreateProduct(product);


            return RedirectToPage("/Products/Index");

        }
    }
}

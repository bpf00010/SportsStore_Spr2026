using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SportsStore_Spr2026.Data;
using SportsStore_Spr2026.Models;

namespace SportsStore_Spr2026.Pages.Products
{
    public class UpdateProductModel : PageModel
    {



        private readonly IProductRepository _productRepository;

        public UpdateProductModel(IProductRepository productRepository)
        {
            _productRepository = productRepository; //saves the reference to the product repository that is being injected into the constructor so that we can use it to talk to the database and get the data we need.
        }






        [BindProperty]
        
        public Product product { get; set; }



        public void OnGet(int id)
        {
            //needs the id coming in so that we can get the product that we want to update. 

            //should talk to the database
            //then should retrieve the product
            //then should pass the product to the view








        }
        //will also render a blank form if theres no getting of the form.
        //in this case the Update product uses an Onget as well as an Onpost because we need to get the product that we want to update and then we need to post the updated product back to the database so that we can update the product in the database.




        public IActionResult OnPost()
        {
            if (ModelState.IsValid) //this ModelState verifies if the data is there and if it is valid according to the data annotations that we have added to the product model.
                                    //will be true if all required fields are provided.
            {
                bool isUpdated = _productRepository.EditProduct(product); //this will call the EditProduct method in the product repository and pass in the product object that is being bound to the form data that is being posted back to the server. This will update the product in the database with the new values from the form.

                if (isUpdated)
                {
                    return RedirectToPage("/Products/ProductDetails"); //if the update was successful then we can redirect to the product details page for the updated product and pass in the id of the updated product so that we can display the updated product details on that page.
                }
                else
                {
                    ModelState.AddModelError("", "failed to update.");
                }


            
            
            }

            return Page();
        }
        //what should the return value be?
        //probably a redirect to the new updated product
        //we can do that by 

    }
}

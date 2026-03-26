using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SportsStore_Spr2026.Models;

namespace SportsStore_Spr2026.Pages.Products
{
    public class UpdateProductModel : PageModel
    {

        [BindProperty]
        public Product product { get; set; }



        public void OnGet()
        {
        }

        //in this case the Update product uses an Onget as well as an Onpost because we need to get the product that we want to update and then we need to post the updated product back to the database so that we can update the product in the database.

    }
}

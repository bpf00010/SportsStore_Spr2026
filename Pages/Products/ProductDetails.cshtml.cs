using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Build.Framework;
using SportsStore_Spr2026.Data;
using SportsStore_Spr2026.Models;

namespace SportsStore_Spr2026.Pages.Products
{
    public class ProductDetailsModel : PageModel
    {
        private readonly IProductRepository _proudctRepository;

        public ProductDetailsModel(IProductRepository proudctRepository)
        {

            _proudctRepository = proudctRepository;


        }




        public Product product { get; set; }





        public void OnGet(int id)
        {

            product = _proudctRepository.GetProductById(id);






        }
    }
}

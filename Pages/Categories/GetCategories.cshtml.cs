using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SportsStore_Spr2026.Data;
using SportsStore_Spr2026.Models;

namespace SportsStore_Spr2026.Pages.Categories
{
    public class GetCategoriesModel : PageModel
    {
        private readonly ICategoryRepository categoryRepository;




        //this serves as the constructor used mainly to just use the methods from the ICategoryRepository interface to get the data from the database and then pass it to the view.
        public GetCategoriesModel(ICategoryRepository categoryRepository)
        {
            this.categoryRepository = categoryRepository;
        }


        public List<Category> CategoryList { get; set; } // this property will hold the list of categories that we will get from the database and pass it to view.


























        public void OnGet()
        {
            //this is the onget method that c an be called to get the data from database and pass it to the view

            CategoryList = categoryRepository.GetCategoryList();





        }
    }
}

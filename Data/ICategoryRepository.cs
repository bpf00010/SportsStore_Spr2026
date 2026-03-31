using SportsStore_Spr2026.Models;

namespace SportsStore_Spr2026.Data
{
    public interface ICategoryRepository
    {
        //The ICategory repository is going to be the contract that defines the method that we need to talk to the database and get the data we need for the categories.

        List<Category> GetCategoryList();





        void CreateCategory(Category category);


        
        Category GetCategoryById(int id);









    }
}

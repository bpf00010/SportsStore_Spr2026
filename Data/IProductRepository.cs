using SportsStore_Spr2026.Models;

namespace SportsStore_Spr2026.Data
{
    public interface IProductRepository
    {

        //here we can add methods to talk to the database and get the data we need

        List<Product> GetProductList();
        //need a method to get the product details from the database and return it to the caller.
        //so here it is 
        Product GetProductById(int id);








        //needs to return list of products
        //other functionalities to follow. 
        //the job of the method is to get the data from the database and return it to the caller.
        //needs a class to impliment this contract then calls the method to get the data and return it to the caller.



    }
}


using SportsStore_Spr2026.Models;

namespace SportsStore_Spr2026.Data
{
    public class CategoryRepository : ICategoryRepository
    {


        //so this class is going to impliment the contract of the ICategoryRepository interface and then we will add the code to talk to the database and get the data we need.


        private readonly string connectionString;


        public CategoryRepository(IConfiguration configuration)
        {
            connectionString = configuration.GetConnectionString("DefaultConnection");
        }



        public List<Category> GetCategoryList()
        {

            List<Category> categoryList = new List<Category>();


            using var connection = new Microsoft.Data.SqlClient.SqlConnection(connectionString);
            {

                using var command = new Microsoft.Data.SqlClient.SqlCommand("spGetCategories", connection);
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    connection.Open();
                    using var reader = command.ExecuteReader();
                    {
                        while (reader.Read())
                        {
                            Category category = new Category
                            {
                                CategoryId = reader.GetInt32(reader.GetOrdinal("CategoryId")),
                                DepartmentId = reader.GetInt32(reader.GetOrdinal("DepartmentId")),
                                Name = reader.GetString(reader.GetOrdinal("Name")),
                                Description = reader.GetString(reader.GetOrdinal("Description"))
                            };
                            categoryList.Add(category);


                        }
                    }
                }
                
            }












            return categoryList;

        }

        public void CreateCategory(Category category)
        {







        }

        public Category GetCategoryById(int Categoryid)
        {
            //not looking for a list of categories just trying to find 1 category by its id so we will return a single category object instead of a list of categories.

            Categoryid = new Category().CategoryId;

            using var connection = new Microsoft.Data.SqlClient.SqlConnection(connectionString);
            {
                using var command = new Microsoft.Data.SqlClient.SqlCommand("spGetCategoryById", connection);
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@CategoryId", Categoryid);
                    connection.Open();
                    using var reader = command.ExecuteReader();
                    {
                        if (reader.Read())
                        {
                            Category category = new Category
                            {
                                CategoryId = reader.GetInt32(reader.GetOrdinal("CategoryId")),
                                DepartmentId = reader.GetInt32(reader.GetOrdinal("DepartmentId")),
                                Name = reader.GetString(reader.GetOrdinal("Name")),
                                Description = reader.GetString(reader.GetOrdinal("Description"))
                            };
                            return category;






                        }






    }
}

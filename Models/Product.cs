using System.ComponentModel.DataAnnotations;
namespace SportsStore_Spr2026.Models
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public decimal Price { get; set; }
        public string? thumbnail { get; set; }
        public string? image { get; set; }
        public bool PromoFront { get; set; }
        public bool PromoDept { get; set; }   



        //create a repository so that it can talk to the table in sql server
        //you do this by 






    }
}

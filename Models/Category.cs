using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SportsStore_Spr2026.Models
{
    public class Category
    {


        [Key]
        public int CategoryId { get; set; }

        //foriegn key to departmentID
        [ForeignKey("Department")]
        public int DepartmentId { get; set; }


        public string Name { get; set; }
        public string Description { get; set; }








    }
}

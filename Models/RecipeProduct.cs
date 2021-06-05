using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace DbProject
{
    public class RecipeProduct
    {
        [Key]
        public int RecipeProductId { get; set; }
        
        [ForeignKey("Product")]
        public int ProductId { get; set; }

        public Product Product;
    }
}

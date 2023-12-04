using Microsoft.Build.Evaluation;
using System.ComponentModel.DataAnnotations.Schema;

namespace PustokProject.CoreModels
{
    public class Book
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        
        public int BrandId { get; set; }
        public Brand Brand { get; set; } 
        public string ProductCode { get; set; }
        public bool IsAvailable { get; set; }

        public string CoverImageUrl{ get; set; }

        public decimal Price { get; set; }

        [Column(TypeName= "decimal(5,4)")]
        public decimal? DiscountPercentage { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }
        
        [NotMapped]
        public decimal? DiscountedPrice { get => DiscountPercentage != null ? Price * (1 - DiscountPercentage / 100) : null; }

        

    }
}

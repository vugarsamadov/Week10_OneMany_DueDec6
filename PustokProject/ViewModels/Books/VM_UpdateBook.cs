using System.ComponentModel.DataAnnotations;

namespace PustokProject.ViewModels;

public class VM_UpdateBook
{
    [Microsoft.Build.Framework.Required]
    public string Name { get; set; }
    [Microsoft.Build.Framework.Required]
    public string Description { get; set; }
    [Microsoft.Build.Framework.Required]
    public int CategoryId { get; set; }
        
    [Microsoft.Build.Framework.Required]
    public int BrandId { get; set; }
    [Microsoft.Build.Framework.Required]
    public string ProductCode { get; set; }
    [Microsoft.Build.Framework.Required]
    public bool? IsAvailable { get; set; }
    [Microsoft.Build.Framework.Required]
    public string CoverImageUrl { get; set; }
    [Microsoft.Build.Framework.Required]
    [Range(0, 10000,ErrorMessage = "Price value should be betwen 0 and 10000")]
    public decimal Price { get; set; }
    [Range(0, 100,ErrorMessage = "Percentage value should be between 0 and 100!")] 
    public decimal? DiscountPercentage { get; set; }
}
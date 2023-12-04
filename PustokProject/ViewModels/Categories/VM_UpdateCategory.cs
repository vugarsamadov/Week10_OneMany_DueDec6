using System.ComponentModel.DataAnnotations;

namespace PustokProject.ViewModels;

public class VM_UpdateCategory
{
    [Required]
    public string Name { get; set; }
    public int? ParentId { get; set; }
}
using System.ComponentModel.DataAnnotations;

namespace PustokProject.ViewModels;

public class VM_CreateCategory
{
    [Required]
    public string Name { get; set; }
    public int? ParentId { get; set; }
}
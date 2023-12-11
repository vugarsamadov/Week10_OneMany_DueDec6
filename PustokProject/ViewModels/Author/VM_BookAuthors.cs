using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using PustokProject.CoreModels;

namespace PustokProject.ViewModels.Author
{
    public class VM_BookAuthors
    {

        public string Name { get; set; }
        public string Surname { get; set; }
        
        public ICollection<CoreModels.Author>? Authors { get; set; }
    }
}

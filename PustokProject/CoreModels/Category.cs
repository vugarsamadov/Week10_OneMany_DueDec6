namespace PustokProject.CoreModels;

public class Category
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int? ParentId { get; set; }
    
    public Category Parent { get; set; }

    public IEnumerable<Book> Books { get; set; }
}
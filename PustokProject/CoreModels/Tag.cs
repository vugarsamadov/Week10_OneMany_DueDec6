namespace PustokProject.CoreModels
{
    public class Tag
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public ICollection<Blog> Blogs { get; set; }
    }
}

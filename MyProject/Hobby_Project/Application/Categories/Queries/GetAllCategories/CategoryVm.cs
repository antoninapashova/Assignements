namespace HobbyProject.Application.Categories.Queries.GetAllCategories
{
    public class CategoryVm
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Name { get; set; }
        public ICollection<HobbySubCategoryDTO> HobbySubCategories { get; set; }
    }
}
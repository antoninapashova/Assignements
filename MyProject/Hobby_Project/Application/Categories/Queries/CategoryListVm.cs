namespace Application.Categories.Queries
{
    public class CategoryListVm
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public DateTime AddedOn { get; set; }
        public List<HobbySubCategoryDTO> HobbySubCategories { get; set; }
    }
}
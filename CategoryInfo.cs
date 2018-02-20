
namespace Category_problem
{
    public class CategoryInfo
    {
        public int ParentCategoryId { get;  set; }
        public string Name { get;  set; }
        public string Keyword { get; set; }


        public CategoryInfo()
        {
            
        }

        public CategoryInfo(string name, string keyword, int parentCategoryId)
        {
            Name = name;
            Keyword = keyword;
            ParentCategoryId = parentCategoryId;
        }
    }
}

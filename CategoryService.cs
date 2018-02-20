
using System.Collections.Generic;

namespace Category_problem
{
    public class CategoryService
    {
        public List<Category> CategoryData { get; set; }

        public CategoryService(List<Category> Categories)
        {
            CategoryData = Categories;
        }

        public List<Category> GetCategoriesByLevel(int level)
        {
            //Get categories recursively starting from root level(1)
            return (CategoryData != null) ? GetCategoriesByLevelRecursively(level, 1, -1, new List<Category>()) : null;
        }

        public CategoryInfo GetCategoryInfoById(int categoryId)
        {
            return (CategoryData != null) ? GetCategoryInfoByIdRecursively(categoryId, null) : null;
        }

        private CategoryInfo GetCategoryInfoByIdRecursively(int categoryId, CategoryInfo categoryInfo)
        {
            foreach (var category in CategoryData)
            {
                if (category.CategoryId == categoryId)
                {
                    if (categoryInfo == null)
                    {
                        categoryInfo = new CategoryInfo()
                        {
                            Name = category.Name,
                            ParentCategoryId = category.ParentCategoryId
                        };
                    }

                    if (category.Keyword != null)
                    {
                        categoryInfo.Keyword = category.Keyword;
                        return categoryInfo;
                    }
                    else
                    {
                        GetCategoryInfoByIdRecursively(category.ParentCategoryId, categoryInfo);
                    }

                    return categoryInfo;
                }
            }

            return null;
        }

        private List<Category> GetCategoriesByLevelRecursively(int level, int current_level, int parentCategoryId, List<Category> levelCategories)
        {
            if (current_level > level)
            {
                return levelCategories;
            }

            foreach (var category in CategoryData)
            {
                if (category.ParentCategoryId == parentCategoryId)
                {
                    if (level == current_level)
                    {
                        levelCategories.Add(category);
                    }
                    else
                    {
                        GetCategoriesByLevelRecursively(level, current_level + 1, category.CategoryId, levelCategories);
                    }
                }
            }
            return levelCategories;
        }
    }
}

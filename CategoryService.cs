
using System;
using System.Collections.Generic;

namespace Category_problem
{
    public class CategoryService
    {
        public IEnumerable<Category> CategoryData { get; set; }

        public CategoryService(IEnumerable<Category> categories)
        {
            CategoryData = categories;
        }

        public IEnumerable<Category> GetCategoriesByLevel(int level)
        {
            if (CategoryData == null)
                throw new InvalidOperationException("CategoryData is null");

            //Get categories recursively starting from root level(1)
            var categories = new List<Category>();
            GetCategoriesByLevelRecursively(level, 1, -1, categories);

            return categories;
        }

        public CategoryInfo GetCategoryInfoById(int categoryId)
        {
            if (CategoryData == null)
                throw new InvalidOperationException("CategoryData is null");

            return GetCategoryInfoByIdRecursively(categoryId, null);
        }

        private CategoryInfo GetCategoryInfoByIdRecursively(int categoryId, CategoryInfo categoryInfo)
        {
            foreach (var category in CategoryData)
            {
                if (category.CategoryId != categoryId)
                    continue;

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


                if (category.ParentCategoryId != -1)
                    GetCategoryInfoByIdRecursively(category.ParentCategoryId, categoryInfo);

                return categoryInfo;
            }

            return null;
        }

        private void GetCategoriesByLevelRecursively(int level, int currentLevel, int parentCategoryId,  IList<Category> levelCategories)
        {
            if (currentLevel > level)
            {
                return;
            }

            foreach (var category in CategoryData)
            {
                if (category.ParentCategoryId != parentCategoryId) continue;

                if (level == currentLevel)
                {
                    levelCategories.Add(category);
                }
                else
                {
                    GetCategoriesByLevelRecursively(level, currentLevel + 1, category.CategoryId, levelCategories);
                }
            }
        }
    }
}

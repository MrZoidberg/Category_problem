
using System;
using System.Collections.Generic;

namespace Category_problem
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Category> categoryDataSet = new List<Category>
            {
                new Category {CategoryId=100, ParentCategoryId=-1, Name= "Business", Keyword= "Money" },
                new Category {CategoryId=200, ParentCategoryId=-1, Name= "Tutoring", Keyword= "Teaching" },
                new Category {CategoryId=101, ParentCategoryId=100, Name= "Accounting", Keyword= "Taxes" },
                new Category {CategoryId=102, ParentCategoryId=100, Name= "Taxation", Keyword= null },
                new Category {CategoryId=201, ParentCategoryId=200, Name= "Computer", Keyword= null },
                new Category {CategoryId=103, ParentCategoryId=101, Name= "Corporate Tax", Keyword= null },
                new Category {CategoryId=202, ParentCategoryId=201, Name= "Operating System", Keyword= null },
                new Category {CategoryId=109, ParentCategoryId=101, Name= "Small business Tax", Keyword= null }
            };

            CategoryService categoryService = new CategoryService(categoryDataSet);

            Console.WriteLine("GetCategoryInfoById:");

            var categoryRes = categoryService.GetCategoryInfoById(202);
            if (categoryRes != null)
            {
                Console.WriteLine("ParentCategoryId = " + categoryRes.ParentCategoryId + " Name = " + categoryRes.Name + " Keyword = " + categoryRes.Keyword);
            }

            Console.WriteLine("GetCategoriesByLevel:");

            var res = categoryService.GetCategoriesByLevel(3);
            foreach (var category in res)
            {
                Console.WriteLine("CategoryId = " + category.CategoryId);
            }

            Console.ReadLine();
        }
    }
}

DECLARE @param INT = 201

;WITH CTE AS (
   SELECT CategoryId, ParentCategoryId, Name, Keywords
   FROM Cat
   WHERE CategoryId = @param

   UNION ALL

   SELECT c1.CategoryId, c1.ParentCategoryId, c1.Name, c1.Keywords
   FROM Cat AS c1
   INNER JOIN CTE AS c2 ON c1.CategoryId = c2.ParentCategoryId  
   WHERE c1.Keywords IS NOT NULL -- terminate if keyword from previous level is not null
)
SELECT *
FROM CTE
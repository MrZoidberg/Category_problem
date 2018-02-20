DECLARE @level INT = 2

;WITH CTE AS (
   -- Start from root categories
   SELECT CategoryId, ParentCategoryId, Name, Keywords, level = 1
   FROM Cat
   WHERE ParentCategoryId = -1

   UNION ALL

   -- Obtain next level category
   SELECT c1.CategoryId, c1.ParentCategoryId, 
          c1.Name, c1.Keywords, level = c2.level + 1
   FROM Cat AS c1
   INNER JOIN CTE AS c2 ON c1.ParentCategoryId   = c2.CategoryId
   WHERE c2.level < @level -- terminate if specified level has been reached
)
SELECT CategoryId
FROM CTE
WHERE level = @level
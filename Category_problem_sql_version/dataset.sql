WITH sample_data AS (
SELECT  CategoryId,
        ParentCategoryId, 
        Name, 
        Keywords
FROM (VALUES 
(100, -1,   'business',         'Money'),
(200, -1,   'tutoring',         'Teaching'),
(101, 100,  'Accountting',      'Taxes'),
(102, 100,  'Taxation',         NULL),
(201, 200,  'Computer',         NULL),
(103, 101,  'Corporate Tax',    NULL),
(202, 201,  'operating system', NULL),
(109, 101,  'Small business Tax', NULL)) as c(CategoryId, ParentCategoryId, Name, Keywords)
)
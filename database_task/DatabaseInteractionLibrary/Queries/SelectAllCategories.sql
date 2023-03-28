SELECT product_name, category_name
FROM Product CROSS APPLY STRING_SPLIT(product_categories, ',')
INNER JOIN Category c ON TRIM(value) = c.item_id
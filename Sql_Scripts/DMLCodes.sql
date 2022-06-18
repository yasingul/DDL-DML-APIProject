
--Categoris üzerine sorgu
SELECT * FROM Categories c where c.CategoryName='Mobilya'

--Products Üzerine sorgu
SELECT * FROM  Products p where p.ProductId=2

--ProductFeatures Üzerine sorgu

SELECT*FROM ProductFeatures p where p.Width > 100 and p.Height> 150
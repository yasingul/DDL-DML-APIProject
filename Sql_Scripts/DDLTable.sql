--Products Tablosunun olu�turulmas�
CREATE TABLE Products (
 ProductId int Primary key Identity (1,1) not null,
 ProductName nvarchar(50) not null ,
 Price  money not null ,
 refCategoryId int not null
)
--Categories Tablosunun olu�turulmas�
CREATE TABLE Categories(
CategoryId int Primary key Identity (1,1) not null,
CategoryName nvarchar(50) not null,
)
--ProductFeatures Tablosunun olu�turulmas�
CREATE TABLE ProductFeatures (
ProductFeaturesId int Primary Key Identity(1,1) not null,
Width decimal ,
Height decimal )

---Products ile Category ile aras�ndaki one to many ili�ki kurulmas�
Alter Table Products 
Add Foreign key (refCategoryId) References Categories(CategoryId) 

--Products ile ProductFeatures aras�ndaki one to many ili�ki kurulmas�
Alter Table Products
Add Foreign key (ProductId) References ProductFeatures(ProductFeaturesId)

--Categories Tablosuna Veri Eklenmesi
INSERT INTO dbo.Categories (CategoryName) Values ('Beyaz E�ya')
INSERT INTO dbo.Categories (CategoryName) Values ('Mobilya')

--ProductFeatures Tablosuna Veri Eklenmesi
INSERT INTO dbo.ProductFeatures ( Width,Height ) Values (400,350)
INSERT INTO dbo.ProductFeatures ( Width,Height ) Values (450,350)

--Products Tablosuna Veri Eklenmesi
INSERT INTO dbo.Products (ProductName,Price,refCategoryId) Values('Buzdolab�',500,1)
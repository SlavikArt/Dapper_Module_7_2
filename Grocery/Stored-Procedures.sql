CREATE PROCEDURE GetProductById
    @Id INT
AS
BEGIN
    SELECT * FROM Products WHERE id = @Id
END

CREATE PROCEDURE GetAllProducts
AS
BEGIN
    SELECT * FROM Products
END

CREATE PROCEDURE UpdateProduct
    @Id INT,
    @Name NVARCHAR(50),
    @Type NVARCHAR(50),
    @Color NVARCHAR(50),
    @Calories INT
AS
BEGIN
    UPDATE Products SET name = @Name, type = @Type, color = @Color, calories = @Calories WHERE id = @Id
END

CREATE PROCEDURE DeleteProduct
    @Id INT
AS
BEGIN
    DELETE FROM Products WHERE id = @Id
END

CREATE PROCEDURE GetAverageCalories
AS
BEGIN
    SELECT AVG(calories) FROM Products
END

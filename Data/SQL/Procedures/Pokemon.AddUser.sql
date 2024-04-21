CREATE OR ALTER PROCEDURE Pokemon.AddUser
   @Email NVARCHAR(128),
   @UserID INT OUTPUT
AS
IF NOT EXISTS (SELECT * FROM Pokemon.Users WHERE Email = @Email)
    INSERT INTO Pokemon.Users(Email)
        VALUES (@Email);
SET @UserID = SCOPE_IDENTITY();
GO
PRINT '   $TableName$Delete ...'
EXEC dbo.DropProcedure '$TableName$Delete'
GO
CREATE PROCEDURE [$TableSchema$].[$TableName$Delete]
    @Id bigint
AS BEGIN
    DELETE FROM [$TableSchema$].[$TableName$] WHERE Id = @Id;
END
GO

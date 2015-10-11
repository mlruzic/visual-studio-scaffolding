PRINT '   $TableName$Get ...'
EXEC dbo.DropProcedure '$TableName$Get'
GO
CREATE PROCEDURE [$TableSchema$].[$TableName$Get]
  @Id bigint
AS BEGIN
    SELECT *
    FROM [$TableSchema$].[$TableName$] (NOLOCK)
    WHERE Id = @Id;
END
GO

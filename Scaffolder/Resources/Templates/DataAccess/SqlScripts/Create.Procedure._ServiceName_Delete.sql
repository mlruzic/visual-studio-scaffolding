﻿--------------------------------------------------------------------------------
-- <auto-generated>
--     This code was generated by a scaffolding tool.
--     Runtime Version: $Version$
--     Date: $DateTimeNow$
-- </auto-generated>
--------------------------------------------------------------------------------
PRINT '   $TableName$Delete ...'
EXEC dbo.DropProcedure @schema='$TableSchema$', @name='$TableName$Delete'
GO
CREATE PROCEDURE [$TableSchema$].[$TableName$Delete]
    @Id bigint
AS BEGIN
    DELETE FROM [$TableSchema$].[$TableName$] WHERE Id = @Id;
END
GO

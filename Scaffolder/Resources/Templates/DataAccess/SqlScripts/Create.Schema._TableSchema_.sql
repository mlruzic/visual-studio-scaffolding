PRINT 'Creating the $TableSchema$ schema...'
GO

IF NOT EXISTS (SELECT * FROM sys.schemas WHERE name = '$TableSchema$') BEGIN
    EXEC sys.sp_executesql N'CREATE SCHEMA $TableSchema$;'
END
GO

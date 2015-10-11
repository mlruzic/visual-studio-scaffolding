PRINT '   $TableName$Insert ...'
EXEC dbo.DropProcedure '$TableName$Insert'
GO
CREATE PROCEDURE [$TableSchema$].[$TableName$Insert]
    $rest(TableColumns): { col 
    | @$col.Name$ [$col.SqlType$]}; separator=",\n"$
AS BEGIN
    INSERT INTO [$TableSchema$].[$TableName$] (
        $rest(TableColumns): { col | $col.Name$}; separator=",\n"$)
    VALUES (
        $rest(TableColumns): { col | @$col.Name$}; separator=",\n"$)

    EXEC [$TableSchema$].[$TableName$Get] @@IDENTITY;
END
GO

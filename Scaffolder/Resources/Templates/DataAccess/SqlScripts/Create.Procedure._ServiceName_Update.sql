﻿--------------------------------------------------------------------------------
-- <auto-generated>
--     This code was generated by a scaffolding tool.
--     Runtime Version: $Version$
--     Date: $DateTimeNow$
-- </auto-generated>
--------------------------------------------------------------------------------
PRINT '   $TableName$Update ...'
EXEC dbo.DropProcedure '$TableName$Update'
GO
CREATE PROCEDURE [$TableSchema$].[$TableName$Update]
    $TableColumns: { col 
    | @$col.Name$ $col.SqlType$}; separator=",\n"$
AS BEGIN
    UPDATE [$TableSchema$].[$TableName$]
    SET 
        $rest(TableColumns): { col 
        | $col.Name$ = @$col.Name$}; separator=",\n"$
    WHERE $first(TableColumns): { col | $col.Name$ = @$col.Name$; }$

    EXEC [$TableSchema$].[$TableName$Get] @Id;
END
GO

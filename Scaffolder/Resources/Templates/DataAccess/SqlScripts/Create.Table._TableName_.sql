PRINT 'Creating the $TableName$ table...'
GO

if not exists (select * from sys.tables where name = '$TableName$' and schema_name(schema_id) = '$TableSchema$') begin
CREATE TABLE [$TableSchema$].[$TableName$]
(
    $first(options.TableColumns): { col | [$col.Name$] [$col.SqlType$] IDENTITY(1,1) NOT NULL, }$
    $rest(options.TableColumns): { col | [$col.Name$] [$col.SqlType$],}; separator="\n"$
    CONSTRAINT PK_$TableName$ PRIMARY KEY CLUSTERED (Id) ON [PRIMARY]
)
end;
go

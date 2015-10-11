namespace VSPackage.ScaffolderPackage.Core
{
    /// <summary>
    /// Represents one column of the table that is being scaffolded
    /// </summary>
    public class TableColumn
    {
        public string Name { get; set; }

        public string SqlType { get; set; }

        public string DotNetType { get; set; }

        public TableColumn()
        {
            Name = "ColumnName";
            SqlType = "nvarchar(max)";
            DotNetType = "string";
        }
    }
}

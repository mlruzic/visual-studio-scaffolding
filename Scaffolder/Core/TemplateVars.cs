namespace VSPackage.ScaffolderPackage.Core
{
    using System.Collections.Generic;
    
    /// <summary>
    /// Defines variables that are available for use in templates. 
    /// </summary>
    public class TemplateVars : Dictionary<string, object>
    {
        public TemplateVars(string tableName, IEnumerable<TableColumn> tableColumns, string projectItemName):
            base()
        {
            Add("TableName", tableName);
            Add("TableColumns", tableColumns);
            Add("TableSchema", projectItemName);
            Add("ModuleName", string.Format("{0}Module", projectItemName));
            Add("ModuleNamespace", string.Format("Se.{0}", projectItemName));
            Add("ServiceName", tableName);
            Add("ServiceIoName", string.Format("{0}Io", tableName));
            Add("ServiceModelName", string.Format("{0}Model", tableName));
            Add("ControllerName", string.Format("{0}Controller", tableName));
            
        }
    }
}

namespace VSPackage.ScaffolderPackage.Core
{
    using System;
    using System.Collections.Generic;
    using System.Reflection;
    
    /// <summary>
    /// Defines variables that are available for use in templates. 
    /// </summary>
    public class TemplateVars : Dictionary<string, object>
    {
        private const string dateTimeFormat = "yyyy-MM-dd HH:mm:ss";

        public TemplateVars(string tableName, IEnumerable<TableColumn> tableColumns, string projectItemName):
            base()
        {
            var version = Assembly.GetExecutingAssembly().GetName().Version.ToString();
            Add("Version", version);
            Add("DateTimeNow", DateTime.Now.ToString(dateTimeFormat));
            Add("DateTimeUtcNow", DateTime.UtcNow.ToString(dateTimeFormat));
            Add("SelectedProjectItem", projectItemName);

            Add("TableName", tableName);
            Add("TableColumns", tableColumns);
            Add("TableSchema", projectItemName.StartWithLowercase());
            Add("ModuleName", string.Format("{0}Module", projectItemName));
            Add("ModuleNamespace", string.Format("Se.{0}", projectItemName));
            Add("ServiceName", tableName);
            Add("ServiceIoName", string.Format("{0}Io", tableName));
            Add("ServiceModelName", string.Format("{0}Model", tableName));
            Add("ControllerName", string.Format("{0}Controller", tableName));
        }
    }

    static class StringExt
    {
        public static string StartWithLowercase(this string str){
            if (string.IsNullOrEmpty(str))
            {
                return string.Empty;
            }
            if (str.Length == 1)
            {
                return str.ToLower();
            }
            return char.ToLower(str[0]) + str.Substring(1);
        }
    }
}

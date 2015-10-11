namespace VSPackage.ScaffolderPackage.Core
{
    using System.Globalization;
    using System.Text.RegularExpressions;
    using System.Windows.Controls;
    using System.Windows.Data;

    /// <summary>
    /// Table column validator used in DataGrid control
    /// </summary>
    public class TableColumnValidationRule: ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            TableColumn tableColumn = (value as BindingGroup).Items[0] as TableColumn;

            if (!IsValidColumnName(tableColumn.Name))
            {
                return new ValidationResult(false, "Invalid value for column name");
            }
            if (string.IsNullOrWhiteSpace(tableColumn.SqlType))
            {
                return new ValidationResult(false, "Invalid value for sql type");
            }
            if (string.IsNullOrWhiteSpace(tableColumn.DotNetType))
            {
                return new ValidationResult(false, "Invalid value for .NET type");
            }

            return ValidationResult.ValidResult;
        }

        private bool IsValidColumnName(string value)
        {
            // Make sure it doesn't contain any spaces
            var regex = new Regex("^[a-zA-Z0-9]+$");
            return regex.IsMatch(value);

        }
    }
}

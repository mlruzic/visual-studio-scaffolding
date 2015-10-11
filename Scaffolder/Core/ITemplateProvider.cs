namespace VSPackage.ScaffolderPackage.Core
{
    using System.Collections.Generic;

    public interface ITemplateProvider
    {
        IEnumerable<TemplateDefinition> TemplateDefinitions { get; set; }
    }
}

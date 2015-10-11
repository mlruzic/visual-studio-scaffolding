namespace VSPackage.ScaffolderPackage.TableScaffolder.UI
{
    using System.Collections.Generic;
    using System.ComponentModel;
    using Core;

    public class ExtensionSettingsViewModel : ViewModel
    {
        public IEnumerable<TemplateDefinition> templates;
        public IEnumerable<TemplateDefinition> Templates
        {
            get
            {
                return templates;
            }
            set
            {
                templates = value;
                OnPropertyChanged("Templates");
            }
        }
    }
}

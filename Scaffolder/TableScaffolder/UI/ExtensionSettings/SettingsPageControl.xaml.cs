namespace VSPackage.ScaffolderPackage.TableScaffolder.UI
{
    using Microsoft.VisualStudio.Shell;
    using System.Collections.Generic;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Input;
    using Core;

    public partial class SettingsPageControl : UserControl
    {
        private ExtensionSettingsViewModel viewModel = new ExtensionSettingsViewModel();

        private IEnumerable<TemplateDefinition> templates;
        public IEnumerable<TemplateDefinition> Templates
        {
            get
            {
                return viewModel.Templates;
            }
            set
            {
                viewModel.Templates = new List<TemplateDefinition>(value);
            }
        }

        public SettingsPageControl()
        {
            DataContext = viewModel;
            InitializeComponent();

            dataGrid.AddHandler(UIElementDialogPage.DialogKeyPendingEvent, new RoutedEventHandler(OnDialogKeyPendingEvent));
        }

        void OnDialogKeyPendingEvent(object sender, RoutedEventArgs e)
        {
            var args = e as DialogKeyEventArgs;
            if (args != null && args.Key == Key.Enter)
            {
                e.Handled = true;
            }
        }

        public void CommitChanges()
        {
            dataGrid.CurrentItem = null;
        }
    }
}

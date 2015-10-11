namespace VSPackage.ScaffolderPackage.TableScaffolder.UI
{
    using Microsoft.VisualStudio.ComponentModelHost;
    using Microsoft.VisualStudio.Shell;
    using System;
    using System.ComponentModel;
    using System.Runtime.InteropServices;
    using System.Windows;
    using Core;

    [ClassInterface(ClassInterfaceType.AutoDual)]
    [CLSCompliant(false)]
    [ComVisible(true)]
    [Guid("E3261E0F-A3C6-4017-B567-F07E3CAED95C")]
    public class SettingsPage: UIElementDialogPage
    {
        // This is the control that hold UI for our settings
        private SettingsPageControl settingsPageControl;

        protected override UIElement Child
        {
            get
            {
                return settingsPageControl ?? (settingsPageControl = new SettingsPageControl());
            }
        }
        
        protected override void OnActivate(CancelEventArgs e)
        {
            base.OnActivate(e);

            // Load templates into our settings control
            var templateProvider = GetTemplateProvider();
            settingsPageControl.Templates = templateProvider.TemplateDefinitions;
        }

        protected override void OnApply(PageApplyEventArgs args)
        {
            if (args.ApplyBehavior == ApplyKind.Apply)
            {
                settingsPageControl.CommitChanges();

                // Save settings
                var templateProvider = GetTemplateProvider();
                templateProvider.TemplateDefinitions = settingsPageControl.Templates;
            }

            base.OnApply(args);
        }

        ITemplateProvider GetTemplateProvider()
        {
            var componentModel = (IComponentModel)(Site.GetService(typeof(SComponentModel)));
            return componentModel.DefaultExportProvider.GetExportedValue<ITemplateProvider>();
        }
    }
}

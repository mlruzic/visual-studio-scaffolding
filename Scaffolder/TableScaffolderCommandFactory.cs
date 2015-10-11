namespace VSPackage.ScaffolderPackage
{
    using EnvDTE;
    using EnvDTE80;
    using Microsoft.VisualStudio.Shell;
    using System;
    using System.ComponentModel.Design;
    using System.IO;
    using System.Windows;
    using TableScaffolder.UI;

    public class TableScaffolderCommandFactory
    {
        private Package package;

        public TableScaffolderCommandFactory(Package package)
        {
            this.package = package;
        }

        public MenuCommand CreateCommand()
        {
            CommandID menuCommandId = new CommandID(GuidList.guidSkafolderCmdSet, (int)PkgCmdIDList.cmdidScaffolder);
            var menuCommand = new OleMenuCommand(ShowTableDesigner, menuCommandId);
            menuCommand.BeforeQueryStatus += BeforeQueryStatusCallback;

            return menuCommand;
        }
        
        private void ShowTableDesigner(object sender, EventArgs e)
        {
            var selectedProjectItem = GetSelectedProjectItem();
            TableDesigner.Instance.Show(selectedProjectItem);
        }

        private void BeforeQueryStatusCallback(object sender, EventArgs e)
        {
            var projectItem = GetSelectedProjectItem();
            var path = projectItem.Properties.Item("FullPath").Value.ToString();
            var dirInfo = new DirectoryInfo(path);

            var cmd = (OleMenuCommand)sender;
            cmd.Visible = dirInfo.Parent.Name.Equals("modules", StringComparison.InvariantCultureIgnoreCase);
        }

        private ProjectItem GetSelectedProjectItem()
        {
            DTE2 dte = (DTE2)Package.GetGlobalService(typeof(DTE));
            UIHierarchy uih = (UIHierarchy)dte.ToolWindows.SolutionExplorer;

            var selectedItems = (Array)uih.SelectedItems;
            if (selectedItems != null)
            {
                foreach (UIHierarchyItem selectedItem in selectedItems)
                {
                    ProjectItem projectItem = selectedItem.Object as ProjectItem;
                    return projectItem;
                }
            }
            return null;
        }
    }
}

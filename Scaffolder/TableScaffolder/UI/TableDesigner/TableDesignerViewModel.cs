namespace VSPackage.ScaffolderPackage.TableScaffolder.UI
{
    using System.Collections.Generic;
    using EnvDTE;
    using Core;
    using System.Windows.Input;
    using Microsoft.VisualStudio.ComponentModelHost;
    using System.Windows.Controls;
    using System.ComponentModel;
    using System.Windows.Threading;
    using System;

    public class TableDesignerViewModel :ViewModel
    {
        public TableDesignerViewModel(RichTextBox log)
        {
            this.log = log;
            Reset();
        }

        /// <summary>
        /// Resets view into default state
        /// </summary>
        public void Reset()
        {
            TableDesignerVisible = true;
            ScaffoldingLogVisible = false;

            TableName = "NewTableName";
            TableColumns = new List<TableColumn>
            {
                new TableColumn
                {
                    Name = "Id",
                    SqlType = "bigint",
                    DotNetType = "long"
                }
            };
        }

        /// <summary>
        /// Selected project item in Viual Studio solution explorer
        /// </summary>
        public ProjectItem ProjectItem { get; set; }

        public ICommand ScaffoldCommand
        {
            get
            {
                return new RelayCommand(StartScaffolding, CanStartScaffolding);
            }
        }

        private List<string> sqlTypes = new List<string>() { "int", "bingint", "nvarchar(max)", "datetime", "bit" };
        public List<string> SqlTypes
        {
            get { return sqlTypes; }
            set { }
        }

        private List<string> dotNetTypes = new List<string>() { "int", "long", "string", "DateTime", "bool" };
        public List<string> DotNetTypes
        {
            get { return dotNetTypes; }
        }

        private string tableName;
        public string TableName
        {
            get { return tableName; }
            set
            {
                tableName = value;
                OnPropertyChanged("TableName");
            }
        }

        private List<TableColumn> tableColumns;
        public List<TableColumn> TableColumns
        {
            get { return tableColumns; }
            set
            {
                tableColumns = value;
                OnPropertyChanged("TableColumns");
            }
        }

        private bool tableDesignerVisible;
        public bool TableDesignerVisible
        {
            get { return tableDesignerVisible; }
            set
            {
                tableDesignerVisible = value;
                OnPropertyChanged("TableDesignerVisible");
            }
        }

        private bool scaffoldingLogVisible;
        public bool ScaffoldingLogVisible
        {
            get { return scaffoldingLogVisible; }
            set
            {
                scaffoldingLogVisible = value;
                OnPropertyChanged("ScaffoldingLogVisible");
            }
        }

        private RichTextBox log;

        private void StartScaffolding(object obj)
        {
            var worker = new BackgroundWorker();

            worker.DoWork += new DoWorkEventHandler(StartScaffoldingAsync);
            worker.WorkerReportsProgress = true;
            worker.ProgressChanged += scaffoldingWorker_ProgressChanged;

            worker.RunWorkerAsync();
        }


        private void scaffoldingWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            var action = e.UserState as Action;
            if (action != null)
            {
                action();
            }
        }

        private void StartScaffoldingAsync(Object sender, EventArgs e)
        {
            var logger = new RichTextBoxLogger(log, sender as BackgroundWorker);
            var templateVars = new TemplateVars(TableName, TableColumns, ProjectItem.Name);
            var templateProvider = GetTemplateProvider();
            var codeCommentator = new CodeCommentator();
            var vsProjectPersister = new VsProjectFilePersister(ProjectItem, codeCommentator, logger);

            TableDesignerVisible = false;
            ScaffoldingLogVisible = true;

            var scaffolder = new TableScaffolder(
                templateVars,
                templateProvider,
                vsProjectPersister,
                ProjectItem,
                logger);

            scaffolder.Scaffold();
        }

        /// <summary>
        /// enables or disables "Scaffold" button
        /// </summary>
        private bool CanStartScaffolding(object obj)
        {
            if (string.IsNullOrWhiteSpace(TableName) ||
                TableColumns == null ||
                TableColumns.Count == 0 ||
                ProjectItem == null ||
                ScaffoldingLogVisible)
            {
                return false;
            }
            return true;
        }

        private ITemplateProvider GetTemplateProvider()
        {
            var componentModel = (IComponentModel)Microsoft.VisualStudio.Shell.Package.GetGlobalService(typeof(SComponentModel));
            return componentModel.DefaultExportProvider.GetExportedValue<ITemplateProvider>();
        }
    }
}

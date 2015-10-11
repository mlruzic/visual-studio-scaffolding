namespace VSPackage.ScaffolderPackage.TableScaffolder.UI
{
    using System.ComponentModel;
    using System.Windows;
    using System.Windows.Documents;
    using System.Windows.Threading;

    /// <summary>
    /// Interaction logic for TableScaffolderOptions.xaml
    /// </summary>
    public partial class TableDesigner : Window
    {
        private static TableDesigner instance;
        public static TableDesigner Instance
        {
            get
            {
                if(instance == null)
                {
                    instance = new TableDesigner();
                    instance.Owner = Application.Current.MainWindow;
                }
                return instance;
            }
        }

        private TableDesignerViewModel viewModel;

        private TableDesigner()
        {
            InitializeComponent();

            viewModel = new TableDesignerViewModel(log);
            DataContext = viewModel;

            Closing += delegate (object sender, CancelEventArgs e)
            {
                e.Cancel = true;
                Hide();
            };
        }
        
        public void Show(EnvDTE.ProjectItem projectItem)
        {
            viewModel.ProjectItem = projectItem;
            viewModel.Reset();
            ClearLog();
            Show();
            tableName.Focus();
            tableName.SelectAll();
        }

        private void ClearLog()
        {
            var textRange = new TextRange(log.Document.ContentStart, log.Document.ContentEnd);
            textRange.Text = string.Empty;
        }
    }
}

namespace VSPackage.ScaffolderPackage.TableScaffolder
{
    using Core;
    using EnvDTE;
    using System;

    /// <summary>
    /// Performs scaffolding
    /// </summary>
    public class TableScaffolder
    {
        private TemplateVars templateVars;
        private ITemplateProvider templateProvider;
        private IFilePersister filePersister;
        private ProjectItem projectItem;
        private ILogger logger;

        public TableScaffolder(
            TemplateVars templateVars,
            ITemplateProvider templateProvider,
            IFilePersister filePersister,
            ProjectItem projectItem,
            ILogger logger)
        {
            this.templateVars = templateVars;
            this.templateProvider = templateProvider;
            this.filePersister = filePersister;
            this.projectItem = projectItem;
            this.logger = logger;
        }

        public void Scaffold()
        {
            logger.Info("Scaffolding started...");
            var scaffoldedFiles = 0;

            try
            {
                var basePath = projectItem.Properties.Item("FullPath").Value.ToString();

                foreach (var templateDefinition in templateProvider.TemplateDefinitions)
                {
                    var compiledTemplate = templateDefinition.Compile(templateVars, logger);

                    if (compiledTemplate != null)
                    {
                        var filePath = templateDefinition.CompileFullPath(templateVars, basePath);
                        if (filePersister.PersistFile(filePath, compiledTemplate.Render(), templateDefinition.Overwrite))
                        {
                            scaffoldedFiles++;
                        }
                    }
                }
                logger.Info(string.Format("Successfully scaffolded {0} files", scaffoldedFiles));
            }
            catch (Exception e)
            {
                logger.Error("Critical error! Aborting...");
                logger.Error(e.ToString());
            }
        }
    }
}

namespace VSPackage.ScaffolderPackage.Core
{
    using Microsoft.VisualStudio.Settings;
    using Microsoft.VisualStudio.Shell;
    using Microsoft.VisualStudio.Shell.Settings;
    using Newtonsoft.Json;
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using System.ComponentModel.Composition;
    using System.Diagnostics;
    using System.IO;
    using System.Reflection;

    /// <summary>
    /// Provides default templates from embedded resourse files,
    /// utilizes WritableSettingsStore class to load/save templates
    /// in user settings so that they can be configured in options pane as well
    /// </summary>
    [Export(typeof(ITemplateProvider))]
    public class TemplateProvider : ITemplateProvider
    {
        private readonly WritableSettingsStore writableSettingsStore;
        private static TemplateDefinition[] defaultTemplates = GetDefaultTemplates();
        private const string CollectionPath = "Scaffolder";
        private const string PropertyName = "Templates";

        [Import]
        internal SVsServiceProvider ServiceProvider = null;

        // Init with default templates
        private List<TemplateDefinition> templateDefinitions = new List<TemplateDefinition>(defaultTemplates);
        public IEnumerable<TemplateDefinition> TemplateDefinitions
        {
            get
            {
                return templateDefinitions;
            }
            //set
            //{
            //    templateDefinitions.Clear();
            //    templateDefinitions.AddRange(value);
            //    if(templateDefinitions.Count == 0)
            //    {
            //        templateDefinitions.AddRange(defaultTemplates);
            //    }
            //    SaveSettings();
            //}
        }

        [ImportingConstructor]
        public TemplateProvider(SVsServiceProvider vsServiceProvider)
        {
            //var shellSettingsManager = new ShellSettingsManager(vsServiceProvider);
            //writableSettingsStore = shellSettingsManager.GetWritableSettingsStore(SettingsScope.UserSettings);

            //LoadTemplates();
        }

        /// <summary>
        /// Loads templates from user settings store
        /// </summary>
        private void LoadTemplates()
        {
            //try
            //{
            //    if (writableSettingsStore.PropertyExists(CollectionPath, PropertyName))
            //    {
            //        var json = writableSettingsStore.GetString(CollectionPath, PropertyName);
            //        TemplateDefinitions = DeserializeCollection(json);
            //    }
            //}
            //catch (Exception ex)
            //{
            //    Debug.Fail(ex.Message);
            //}
        }

        /// <summary>
        /// Save templates to user settings store
        /// </summary>
        private void SaveSettings()
        {
            //try
            //{
            //    if (!writableSettingsStore.CollectionExists(CollectionPath))
            //    {
            //        writableSettingsStore.CreateCollection(CollectionPath);
            //    }

            //    string json = JsonConvert.SerializeObject(TemplateDefinitions);
            //    writableSettingsStore.SetString(CollectionPath, PropertyName, json);
            //}
            //catch (Exception ex)
            //{
            //    Debug.Fail(ex.Message);
            //}
        }

        private IEnumerable<TemplateDefinition> DeserializeCollection(string json)
        {
            try
            {
                var templates = JsonConvert.DeserializeObject<TemplateDefinition[]>(json);
                return templates;
            }
            catch(Exception e)
            {
                Debug.Fail(e.Message);
                return new List<TemplateDefinition>();
            }
        }

        /// <summary>
        /// Loads default templated from embedded resource files
        /// </summary>
        /// <returns></returns>
        private static TemplateDefinition[] GetDefaultTemplates()
        {
            var defaultTemplates = new List<TemplateDefinition>();
            var assembly = Assembly.GetExecutingAssembly();
            var resourceBasePath = "VSPackage.ScaffolderPackage.Resources.Templates";

            foreach (var resource in GetResources())
            {
                var resourceParts = new string[] { resourceBasePath, resource.ResourcePath, resource.FileName };
                var resourceName = string.Join(".", resourceParts.Where(r => !string.IsNullOrEmpty(r)));

                using (Stream stream = assembly.GetManifestResourceStream(resourceName))
                {
                    using (StreamReader reader = new StreamReader(stream))
                    {
                        defaultTemplates.Add(new TemplateDefinition
                        {
                            FileName = resource.FileName,
                            RelativePath = resource.RelativePath,
                            Overwrite = resource.overwrite,
                            Template = reader.ReadToEnd()
                        });
                    }
                }
            }

            return defaultTemplates.ToArray();
        }

        private static IEnumerable<dynamic> GetResources()
        {
            // Embedded resources
            return new List<object>
            {
                new { RelativePath="Api\\_ServiceName_", FileName = "_ServiceIoName_.cs", ResourcePath = "Api", overwrite = true },
                new { RelativePath="Api\\_ServiceName_", FileName = "_ServiceName_Controller.cs", ResourcePath = "Api", overwrite = true },
                new { RelativePath="DataAccess\\_ServiceName_", FileName = "_ServiceName_SqlProvider.cs", ResourcePath = "DataAccess", overwrite = true },
                new { RelativePath="DataAccess\\_ServiceName_", FileName = "I_ServiceName_Provider.cs", ResourcePath = "DataAccess", overwrite = true },
                new { RelativePath="DataAccess\\_ServiceName_\\SqlScripts", FileName = "Create.Procedure._ServiceName_Delete.sql", ResourcePath = "DataAccess.SqlScripts", overwrite = true },
                new { RelativePath="DataAccess\\_ServiceName_\\SqlScripts", FileName = "Create.Procedure._ServiceName_Get.sql", ResourcePath = "DataAccess.SqlScripts", overwrite = true },
                new { RelativePath="DataAccess\\_ServiceName_\\SqlScripts", FileName = "Create.Procedure._ServiceName_Insert.sql", ResourcePath = "DataAccess.SqlScripts", overwrite = true },
                new { RelativePath="DataAccess\\_ServiceName_\\SqlScripts", FileName = "Create.Procedure._ServiceName_Update.sql", ResourcePath = "DataAccess.SqlScripts", overwrite = true },
                new { RelativePath="DataAccess\\_ServiceName_\\SqlScripts", FileName = "Create.Schema._TableSchema_.sql", ResourcePath = "DataAccess.SqlScripts", overwrite = true },
                new { RelativePath="DataAccess\\_ServiceName_\\SqlScripts", FileName = "Create.Table._TableName_.sql", ResourcePath = "DataAccess.SqlScripts", overwrite = true },
                new { RelativePath="Models\\_ServiceName_", FileName = "_ServiceModelName_.cs", ResourcePath = "Models", overwrite = true },
                new { RelativePath="Service\\_ServiceName_", FileName = "_ServiceName_.cs", ResourcePath = "Service", overwrite = true },
                new { RelativePath="Service\\_ServiceName_", FileName = "_ServiceName_Repository.cs", ResourcePath = "Service", overwrite = true },
                new { RelativePath="Service\\_ServiceName_", FileName = "I_ServiceName_Repository.cs", ResourcePath = "Service", overwrite = true },
                new { RelativePath="", FileName = "_ModuleName_.cs", ResourcePath = "", overwrite = false }
            };
        }
    }
}

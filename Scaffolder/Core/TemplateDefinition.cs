namespace VSPackage.ScaffolderPackage.Core
{
    using Antlr4.StringTemplate;
    using System;
    using System.IO;

    /// <summary>
    /// Describes template before it being compiled into a file
    /// </summary>
    public class TemplateDefinition
    {
        /// <summary>
        /// FileName this template is being compiled into. 
        /// FileName can contain placeholders like _TemplateVar_ which 
        /// are going to be replaced by corresponding template variable
        /// </summary>
        /// <example>
        /// _ServiceName_Controller.cs
        /// </example>
        public string FileName { get; set; }

        /// <summary>
        /// Destination folder relative to the project item
        /// </summary>
        public string RelativePath { get; set; }

        /// <summary>
        /// If true, existing files will be overwritten. If false
        /// new content will be commented out and appended to the 
        /// end of the file
        /// </summary>
        public bool Overwrite { get; set; }

        /// <summary>
        /// Template contents
        /// </summary>
        public string Template { get; set; }

        public TemplateDefinition()
        {
            FileName = string.Empty;
            RelativePath = string.Empty;
            Template = string.Empty;
        }

        public Template Compile(TemplateVars templateVars, ILogger logger)
        {
            try
            {
                // Override default delimiters, these will not require as
                // much escaping in C# code as default delimiters
                var template = new Template(Template, '$', '$');
                foreach (var templateVar in templateVars)
                {
                    template.Add(templateVar.Key, templateVar.Value);
                }
                
                // Register string renderer so that we can user "Upper" modifier in templates
                template.Group.RegisterRenderer(typeof(string), new StringRenderer());

                return template;
            }
            catch (Exception e)
            {
                // Ups, something is worng with the template
                logger.Error(string.Format("Invalid template {0}. {1}", FileName, e.Message));
                return null;
            }
        }

        /// <summary>
        /// Generates full path to the destination file and replaces all
        /// placeholders with a corresponding template variable
        /// </summary>
        public string CompileFullPath(TemplateVars templateVars, string basePath)
        {
            var fullPath = Path.Combine(basePath, RelativePath, FileName);
            foreach (var templateVar in templateVars)
            {
                var key = string.Format("_{0}_", templateVar.Key);
                fullPath = fullPath.Replace(key, templateVar.Value.ToString());
            }
            return fullPath;
        }
    }
}
namespace VSPackage.ScaffolderPackage.Core
{
    using EnvDTE;
    using System;
    using System.Collections.Generic;
    using System.IO;

    /// <summary>
    /// Saves compiled template file to disk and includes it 
    /// into a visual Studio project
    /// </summary>
    public class VsProjectFilePersister : IFilePersister
    {
        private ProjectItem projectItem;
        private ICodeCommentator codeCommentator;
        private ILogger logger;

        public VsProjectFilePersister(ProjectItem projectItem, ICodeCommentator codeCommentator, ILogger logger)
        {
            this.projectItem = projectItem;
            this.codeCommentator = codeCommentator;
            this.logger = logger;
        }

        public bool PersistFile(string path, string contents, bool overwrite)
        {
            // Short path for logging
            var shortPath = ShortPath(path);
            var extension = Path.GetExtension(path);

            try
            {
                // Create directory if it does not exists
                var directoryName = Path.GetDirectoryName(path);
                Directory.CreateDirectory(directoryName);
            }
            catch(Exception e)
            {
                logger.Error(string.Format("Cannot create directory: {0}", e.Message));
                return false;
            }

            try
            {
                if (!File.Exists(path))
                {
                    // create new file
                    logger.Info(string.Format("Creating file: {0}", shortPath));
                    File.AppendAllText(path, contents);
                }
                else if (overwrite)
                {
                    // Overwrite existing file
                    logger.Warn(string.Format("Overwriting file: {0}", shortPath));
                    File.WriteAllText(path, contents);
                }
                else
                {
                    // We need to comment out the code and append it to the end of the file
                    var commentedCode = string.Empty;
                    if (codeCommentator.CommentOutAllLines(extension, contents, out commentedCode))
                    {
                        logger.Warn(string.Format("File exists: {0}. Appending commented content", shortPath));
                        File.AppendAllText(path, commentedCode);
                    }
                    else
                    {
                        // Unable to comment out the file, append the uncommented contents
                        logger.Error(string.Format("I don't know how to comment out {0} files.", extension));
                        logger.Error("Contents will be appended to the end of the existing file uncommented!");
                        File.AppendAllText(path, contents);
                    }
                }
            }
            catch (Exception e)
            {
                logger.Error(string.Format("Failed: {0}", e.Message));
                return false;
            }

            try
            {
                // Include file into a project
                projectItem.ContainingProject.ProjectItems.AddFromFile(path);
            }
            catch (Exception e)
            {
                logger.Error(string.Format("Cannot include file in Visual Studio project: {0}", e.Message));
                return false;
            }

            return true;
        }

        private string ShortPath(string path)
        {
            var basePath = projectItem.Properties.Item("FullPath").Value.ToString();
            return path.Replace(basePath, "");
        }
    }
}

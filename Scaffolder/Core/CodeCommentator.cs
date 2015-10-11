using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VSPackage.ScaffolderPackage.Core
{
    public class CodeCommentator : ICodeCommentator
    {
        public bool CommentOutAllLines(string fileExtension, string code, out string commentedCode)
        {
            // Remove the dot
            fileExtension = fileExtension.Trim('.');

            // Make sure we know how to comment out this file
            if (codeCommentators.ContainsKey(fileExtension))
            {
                var codeCommentator = codeCommentators[fileExtension];
                commentedCode = CommentOutAllLines(code, codeCommentator);
                return true;
            }
            else
            {
                commentedCode = null;
                return false;
            }
        }

        private string CommentOutAllLines(string contents, Func<string, string> codeCommentator)
        {
            var commentedCode = new StringBuilder();
            using (var reader = new StringReader(contents))
            {
                var line = string.Empty;
                while ((line = reader.ReadLine()) != null)
                {
                    commentedCode.AppendLine(codeCommentator(line));
                }
            }
            return commentedCode.ToString();
        }

        /// <summary>
        /// These are the files we know how to comment out
        /// </summary>
        private Dictionary<string, Func<string, string>> codeCommentators = new Dictionary<string, Func<string, string>>
        {
            { "cs",  (line) => { return "//" + line; } },
            { "sql",  (line) => { return "--" + line; } }
        };
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VSPackage.ScaffolderPackage.Core
{
    public interface ICodeCommentator
    {
        bool CommentOutAllLines(string fileExtension, string code, out string commentedCode);
    }
}

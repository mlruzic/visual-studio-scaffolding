namespace VSPackage.ScaffolderPackage.Core
{
    public interface IFilePersister
    {
        bool PersistFile(string path, string contents, bool overwrite);
    }
}
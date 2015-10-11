namespace VSPackage.ScaffolderPackage.Core
{
    public interface ILogger
    {
        void Error(string text, object obj = null);

        void Info(string text, object obj = null);

        void Warn(string text, object obj = null);
    }
}

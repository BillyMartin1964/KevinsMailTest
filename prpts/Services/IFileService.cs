namespace prpts.Services
{
    public interface IFileService
    {
        void EncryptFile(FileInfo file);
        void DecryptFile(FileInfo file);
        void getSecrets();

    }
}
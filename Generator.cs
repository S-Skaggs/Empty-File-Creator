namespace EmptyFileCreator
{
    public class Generator
    {
        private readonly string _destinationPath;
        private readonly string _fileType;

        public Generator(string destinationPath, string fileType)
        {
            _destinationPath = destinationPath;
            _fileType = fileType;
        }

        public string GenerateFile()
        {
            if (IsValidPath())
            {
                return CreateEmptyFile();
            }
            else
            {
                throw new ArgumentException("Invalid value provided for the 'path' argument. Path does not exist.");
            }
        }

        private string CreateEmptyFile()
        {
            string fileName = $@"{_destinationPath}\SomeFileName_{DateTime.Now:MM_dd_yyyy_HHmm}.{_fileType}";
            File.Create(fileName).Dispose();
            return fileName;
        }

        private bool IsValidPath() => new DirectoryInfo(_destinationPath).Exists;
    }
}

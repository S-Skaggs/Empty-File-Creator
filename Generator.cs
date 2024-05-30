using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmptyFileCreator
{
    public class Generator : IDisposable
    {
        public string DestinationPath;
        public string FileType;
        private bool disposedValue;

        public Generator(string destinationPath, string fileType)
        {
            DestinationPath = destinationPath;
            FileType = fileType;
        }

        public string GenerateTheFile()
        {
            if (IsValidPath())
            {
                return CreateEmptyFile();
            }
            else
            {
                throw new ArgumentException(String.Format("The first parameter for the path is not a valid path.", DestinationPath));
            }
        }

        public bool IsValidPath()
        {
            DirectoryInfo directoryInfo = new DirectoryInfo(DestinationPath);
            return directoryInfo.Exists;
        }

        public string CreateEmptyFile()
        {
            string fileName = DateTime.Now.ToString("MM_dd_yyyy_HHmm");

            fileName = String.Format("SomeFileName_{0}.{1}", fileName, FileType);

            try
            {
                fileName = String.Format("{0}\\{1}", DestinationPath, fileName);
                File.Create(fileName).Dispose();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                fileName = String.Empty;
                Environment.ExitCode = 1;
            }

            return fileName;
        }



        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects)
                }

                // TODO: free unmanaged resources (unmanaged objects) and override finalizer
                // TODO: set large fields to null
                disposedValue = true;
            }
        }

        // // TODO: override finalizer only if 'Dispose(bool disposing)' has code to free unmanaged resources
        // ~Generator()
        // {
        //     // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
        //     Dispose(disposing: false);
        // }

        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}

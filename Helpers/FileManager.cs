using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.Desktop.Helpers
{
    class FileManager : IFileManager
    {
        public void ChangeFileState(string filePath, FileState State)
        {
            throw new NotImplementedException();
        }

        public void DeleteFile(string fileName)
        {
            throw new NotImplementedException();
        }

        public void DeleteFiles(string directoryPath)
        {
            throw new NotImplementedException();
        }

        public List<string> GetFileNames(string directoryPath)
        {
            throw new NotImplementedException();
        }

        //Don't do it yet
        public FileState GetFileState(string filePath)
        {
            throw new NotImplementedException();
        }

        public List<string> GetNewFilePathes(string directoryPath)
        {
            throw new NotImplementedException();
        }

        public int GetNewFilesCount(string directoryPath)
        {
            throw new NotImplementedException();
        }

        public void MoveFiles(string fromDirectory, string toDirectory)
        {
            throw new NotImplementedException();
        }
    }
}

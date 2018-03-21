using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.Desktop.Helpers
{
    public interface IFileManager
    {
        int GetNewFilesCount(string directoryPath);
        List<string> GetFileNames(string directoryPath);
        void MoveFiles(string fromDirectory, string toDirectory);
        void DeleteFile(string fileName);
        void DeleteFiles(string directoryPath);

        FileState GetFileState(string filePath);
        void ChangeFileState(string filePath, FileState State);
        List<string> GetNewFilePathes(string directoryPath);
    }
}

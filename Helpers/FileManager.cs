using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace EMS.Desktop.Helpers
{
    class FileManager : IFileManager
    {
        public void DeleteFile(string fileName)
        {
            FileInfo file = new FileInfo(fileName);

            if (file.Exists)
            {
                file.Delete();
            }
            else
                throw new FileNotFoundException("Error: file not found ", fileName);
        }

        public void DeleteFiles(string directoryPath)
        {
            try
            {
                string[] fileList = Directory.GetFiles(directoryPath);

                foreach (string f in fileList)
                {
                    File.Delete(f);
                }
            }

            catch (DirectoryNotFoundException dirNotFound)
            {
                throw new DirectoryNotFoundException("Error: directory not found ", dirNotFound);
            }
        }

        public List<string> GetFileNames(string directoryPath)
        {
            string[] files = Directory.GetFiles(directoryPath);

            return files.ToList();
        }

        public void MoveFiles(string fromDirectory, string toDirectory)
        {
            try
            {
                string[] fileList = Directory.GetFiles(fromDirectory);

                // Move files.
                foreach (string f in fileList)
                {

                    // Remove path from the file name.
                    string fName = f.Substring(fromDirectory.Length + 1);

                    try
                    {
                        // Will not overwrite if the destination file already exists.
                        File.Move(Path.Combine(fromDirectory, fName), Path.Combine(toDirectory, fName));
                    }

                    // Catch exception if the file was already copied.
                    catch (IOException moveError)
                    {
                        throw new IOException("Error", moveError);
                    }
                }
            }

            catch (DirectoryNotFoundException dirNotFound)
            {
                throw new DirectoryNotFoundException("Error: directory not found ", dirNotFound);
            }
        }

        //Don't do it yet
        public void ChangeFileState(string filePath, FileState State)
        {
            throw new NotImplementedException();
        }

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
    }
}
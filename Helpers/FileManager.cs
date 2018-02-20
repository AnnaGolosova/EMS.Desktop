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
                Console.WriteLine("{0} was successfully deleted.", fileName);
            }
            else
                throw new FileNotFoundException("Error: file not found ", fileName);
        }

        public void DeleteFiles(string directoryPath)
        {
            try
            {
                string[] f202List = Directory.GetFiles(directoryPath, "*.202");
                string[] f210List = Directory.GetFiles(directoryPath, "*.210");
                string[] exelList = Directory.GetFiles(directoryPath, "*.xlsx");

                foreach (string f in f202List)
                {
                    File.Delete(f);
                }
                foreach (string f in f210List)
                {
                    File.Delete(f);
                }
                foreach (string f in exelList)
                {
                    File.Delete(f);
                }
            }

            catch (DirectoryNotFoundException dirNotFound)
            {
                Console.WriteLine(dirNotFound.Message);
            }
        }

        public List<string> GetFileNames(string directoryPath)
        {
            string[] files = Directory.GetFiles(directoryPath);
            List<string> files2 = new List<string>();

            foreach (string file in files)
                files2.Add(file);

            return files2;
                //Console.WriteLine("{0}", file);

            //throw new NotImplementedException();
        }

        public void MoveFiles(string fromDirectory, string toDirectory)
        {

            //throw new NotImplementedException();
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
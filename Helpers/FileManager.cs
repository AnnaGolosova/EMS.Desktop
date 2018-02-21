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
            try
            {
                string[] f202List = Directory.GetFiles(fromDirectory, "*.202");
                string[] f210List = Directory.GetFiles(fromDirectory, "*.210");
                string[] exelList = Directory.GetFiles(fromDirectory, "*.xlsx");

                // Copy "*.202" files.
                foreach (string f in f202List)
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
                        Console.WriteLine(moveError.Message);
                    }
                }

                // Copy "*.210" files.
                foreach (string f in f210List)
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
                        Console.WriteLine(moveError.Message);
                    }
                }

                // Copy "*.xlsx" files.
                foreach (string f in exelList)
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
                        Console.WriteLine(moveError.Message);
                    }
                }
            }

            catch (DirectoryNotFoundException dirNotFound)
            {
                Console.WriteLine(dirNotFound.Message);
            }
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
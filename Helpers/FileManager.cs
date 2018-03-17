﻿﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using DSOFile;
using EMS.Desktop.Services;

namespace EMS.Desktop.Helpers
{
    class FileManager //: IFileManager
    {
        public static void DeleteFile(string fileName)
        {
            FileInfo file = new FileInfo(fileName);

            if (file.Exists)
            {
                file.Delete();
            }
            else
                throw new FileNotFoundException("Error: file not found ", fileName);
        }

        public static void DeleteFiles(string directoryPath)
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

        public static List<string> GetFileNames(string directoryPath)
        {
            string[] files = Directory.GetFiles(directoryPath);

            return files.ToList();
        }

        public static void MoveFiles(string fromDirectory, string toDirectory)
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
        public static void ChangeFileState(string filePath, FileState state)
        {
            using (FileParameterSetter setter = new FileParameterSetter(filePath))
            {
                setter.SetCustomProperty(state);
            }
        }

        public static FileState GetFileState(string filePath)
        {
            using (FileParameterSetter setter = new FileParameterSetter(filePath))
            {
                return setter.GetProperty();
            }
        }

        public static int GetFileId(string filePath)
        {
            using (FileParameterSetter setter = new FileParameterSetter(filePath))
            {
                return setter.GetFileId();
            }
        }

        public static int SetFileId(string filePath, int? Id)
        {
            using (FileParameterSetter setter = new FileParameterSetter(filePath))
            {
                DBRepository db = new DBRepository();
                Models.File f = db.FindOrAddFile(Id, filePath);
                setter.SetFileId(f.Id);
                return f.Id;
            }
        }

        public static List<string> GetNewFilePathes(string directoryPath)
        {
            List<string> result = new List<string>();
            try
            {
                DirectoryInfo dir = new DirectoryInfo(directoryPath);
                List<FileInfo> files = dir.GetFiles().ToList();
                foreach (FileInfo file in files)
                {
                    if (file.Name.Split('.').Last().CompareTo("210") == 0)
                    {
                        using (FileParameterSetter setter = new FileParameterSetter(file.FullName))
                        {
                            if (setter.GetProperty() == FileState.New || setter.GetProperty() == FileState.None)
                                result.Add(file.FullName);
                        }
                    }
                }
            }
            catch
            {
                //Не может найти путь - обработать исключение
            }
            return result;
        }

        /// <summary>
        /// Returns count of new .210 files
        /// </summary>
        /// <param name="directoryPath">path to target directory</param>
        /// <returns></returns>
        public static int GetNewFilesCount(string directoryPath)
        {
            return GetNewFilePathes(directoryPath).Count;
        }

        public static void ClearFileStates(string directoryPath)
        {
            foreach (string file in GetFileNames(directoryPath))
            {
                using (FileParameterSetter setter = new FileParameterSetter(file))
                {
                    setter.SetCustomProperty(FileState.New);
                }
            }
        }
    }
}

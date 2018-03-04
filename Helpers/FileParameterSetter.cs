using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.Desktop.Helpers
{
    class FileParameterSetter : IDisposable
    {
        private DSOFile.OleDocumentProperties m_file;
        const string PROPERTY_NAME = "FileState";

        public FileParameterSetter(string path)
        {
            m_file = new DSOFile.OleDocumentProperties();
            m_file.Open(path, false, DSOFile.dsoFileOpenOptions.dsoOptionDefault);
        }

        /// <summary>
        /// Sets a custom state for the file.
        /// </summary>
        /// <param name="State">New value of state</param>
        /// <exception cref="System.Exception"></exception>
        public void SetCustomProperty(FileState state)
        {
            try
            {
                string value = state.ToString();
                //m_file.CustomProperties.Add(PROPERTY_NAME, ref value);
                m_file.SummaryProperties.Comments = value;
                m_file.Save();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Gets a state for the file.
        /// </summary>
        /// <returns>Returns FileState.None if file is't new or .210</returns>
        public FileState GetProperty()
        {
            try
            {
                if (m_file.Name.Split('.').Last().CompareTo("210") != 0)
                    return FileState.None;
                if (string.IsNullOrEmpty(m_file.SummaryProperties.Comments))
                    return FileState.New;
                return (FileState)Enum.Parse(typeof(FileState), m_file.SummaryProperties.Comments);
            }
            catch
            {
                return FileState.None;
            }
        }

        public void Dispose()
        {
            m_file.Close(true);
        }
    }
}

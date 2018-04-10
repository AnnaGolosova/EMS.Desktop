using EMS.Desktop.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EMS.Desktop.Helpers
{
    class FileParameterSetter : IDisposable
    {
        bool isSupportedFile = true;

        private DSOFile.OleDocumentProperties m_file;
        const string PROPERTY_NAME = "FileState";
        const string FILE_ID_NAME = "FileId";

        public FileParameterSetter(string path)
        {
            try
            {
                m_file = new DSOFile.OleDocumentProperties();
                m_file.Open(path, false, DSOFile.dsoFileOpenOptions.dsoOptionDefault);
                if (m_file.Name.Split('.').Last().CompareTo("210") != 0)
                    isSupportedFile = false;
            }
            catch(System.Runtime.InteropServices.COMException)
            {
                isSupportedFile = false;
            }
        }

        /// <summary>
        /// Sets a custom state for the file.
        /// </summary>
        /// <param name="State">New value of state</param>
        /// <exception cref="System.Exception"></exception>
        public void SetCustomProperty(FileState state)
        {
            if (isSupportedFile)
            {
                try
                {
                    object value = state.ToString();
                    System.Diagnostics.Debugger.NotifyOfCrossThreadDependency();
                    System.Collections.IEnumerator it = m_file.CustomProperties.GetEnumerator();
                    it.Reset();
                    while (it.MoveNext() != false)
                    {
                        dynamic d = it.Current;
                        if (((string)d.Name).CompareTo(PROPERTY_NAME) == 0)
                        {
                            d.Value = value;
                            m_file.Save();
                            return;
                        }
                    }
                    //m_file.CustomProperties.Add(PROPERTY_NAME, ref value);
                    m_file.CustomProperties.Add(PROPERTY_NAME, ref value);
                    m_file.Save();
                }
                catch (Exception)
                {
                    MessageBox.Show("Файл не поддерживается.", "Неверный формат", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }  

        /// <summary>
        /// Gets a state for the file.
        /// </summary>
        /// <returns>Returns FileState.None if file is't new or .210</returns>
        public FileState GetProperty()
        {
            if (!isSupportedFile) return FileState.None;
            try
            {
                System.Collections.IEnumerator it = m_file.CustomProperties.GetEnumerator();
                it.Reset();
                while(it.MoveNext() != false)
                {
                    dynamic d = it.Current;
                    if (((string)d.Name).CompareTo(PROPERTY_NAME) == 0)
                        return Enum.Parse(typeof(FileState), d.Value);
                }
            }
            catch
            {
                return FileState.None;
            }
            return FileState.None;
        }



        public void Dispose()
        {
            m_file.Close(true);
        }

        internal int GetFileId()
        {
            if(isSupportedFile)
            {
                System.Collections.IEnumerator it = m_file.CustomProperties.GetEnumerator();
                it.Reset();
                while (it.MoveNext() != false)
                {
                    dynamic d = it.Current;
                    if (((string)d.Name).CompareTo(FILE_ID_NAME) == 0)
                        return int.Parse(d.Value);
                }
            }
            return -1;
        }

        internal void SetFileId(int id)
        {
            System.Collections.IEnumerator it = m_file.CustomProperties.GetEnumerator();
            it.Reset();
            while (it.MoveNext() != false)
            {
                dynamic d = it.Current;
                if (((string)d.Name).CompareTo(FILE_ID_NAME) == 0)
                { 
                    d.Value = id.ToString();
                    m_file.Save();
                    return;
                }
            }
            m_file.CustomProperties.Add(FILE_ID_NAME, id.ToString());
            m_file.Save();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileReader
{
    public class FileReader : FileReaderAbstract
    {
        /// <summary>
        /// Read text file from the path
        /// </summary>
        /// <param name="path">full path to text file to read</param>
        /// <param name="isEncrypted">if file is encrypted, by default it's not</param>
        /// <returns>the content of the file to read</returns>
        public string ReadTextFile(string path, bool isEncrypted = false)
        {
            if (!isEncrypted)
                return ReadFile(path);
            else
                return ReadEncryptedFile(path);
        }

        /// <summary>
        /// Read XML file from the path
        /// </summary>
        /// <param name="path">full path to XML file to read</param>
        /// <param name="role">role based security context, by default it's None</param>
        /// <returns>the content of the file to read</returns>
        public string ReadXmlFile(string path, Role role = Role.None)
        {
            switch (role)
            {
                case Role.None:
                    return ReadFile(path);
                case Role.Admin:
                    return ReadFile(path);//Not specified clearly by the business for now
                default:
                    return ReadFile(path);
            }
        }
    }
}

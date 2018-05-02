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
        /// <param name="role">role based security context, by default it's None</param>
        /// <returns>the content of the file to read</returns>
        public string ReadTextFile(string path, bool isEncrypted = false, Role role = Role.None)
        {
            switch (role)
            {
                case Role.None:
                    return !isEncrypted ? ReadFile(path) : ReadEncryptedFile(path);

                case Role.Admin: //Not specified clearly by the business for now
                    return !isEncrypted ? ReadFile(path) : ReadEncryptedFile(path);

                default:
                    return !isEncrypted ? ReadFile(path) : ReadEncryptedFile(path);
            }
        }

        /// <summary>
        /// Read XML file from the path
        /// </summary>
        /// <param name="path">full path to XML file to read</param>
        /// <param name="role">role based security context, by default it's None</param>
        /// <param name="isEncrypted">true if file is encrypted, by default it's not</param>
        /// <returns>the content of the file to read</returns>
        public string ReadXmlFile(string path, Role role = Role.None, bool isEncrypted = false)
        {
            switch (role)
            {
                case Role.None:
                    return !isEncrypted ? ReadFile(path) : ReadEncryptedFile(path);

                case Role.Admin: //Not specified clearly by the business for now
                    return !isEncrypted ? ReadFile(path) : ReadEncryptedFile(path);

                default:
                    return !isEncrypted ? ReadFile(path) : ReadEncryptedFile(path);
            }
        }

        /// <summary>
        /// Read json file from the path
        /// </summary>
        /// <param name="path">full path to json file to read</param>
        /// <returns>string file content</returns>
        public string ReadJsonFile(string path)
        {
            return ReadFile(path);
        }

        /// <summary>
        /// Read json file from the path
        /// </summary>
        /// <param name="path">full path to json file to read</param>
        /// <param name="isEncrypted">if the file is encrypted or not</param>
        /// <returns>string file content</returns>
        public string ReadJsonFile(string path, bool isEncrypted)
        {
            if (!isEncrypted)
                return ReadFile(path);
            else
                return ReadEncryptedFile(path);
        }
    }
}

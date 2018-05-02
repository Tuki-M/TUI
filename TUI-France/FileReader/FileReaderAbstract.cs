using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileReader
{
    public abstract class FileReaderAbstract
    {
        public string ReadFile(string path)
        {
            if (!File.Exists(path))
                throw new FileNotFoundException("File not found");

            return File.ReadAllText(path);
        }

        public string ReadEncryptedFile(string path)
        {
            string fileContent = ReadFile(path);
            return Reverse(fileContent);
        }

        /// <summary>
        /// Reverse string
        /// </summary>
        /// <param name="content">the string content</param>
        /// <returns>Reversed string</returns>
        private string Reverse(string content)
        {
            char[] contentArray = content.ToCharArray();
            Array.Reverse(contentArray);
            return new string(contentArray);
        }
    }
}

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
        /// <returns>the content of the file to read</returns>
        public string ReadTextFile(string path)
        {
            return ReadFile(path);
        }

        /// <summary>
        /// Read XML file from the path
        /// </summary>
        /// <param name="path">full path to XML file to read</param>
        /// <returns>the content of the file to read</returns>
        public string ReadXmlFile(string path)
        {
            return ReadFile(path);
        }
    }
}

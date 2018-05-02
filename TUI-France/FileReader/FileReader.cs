using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileReader
{
    public class FileReader : FileReaderAbstract
    {
        public string ReadTextFile(string path)
        {
            return ReadFile(path);
        }
    }
}

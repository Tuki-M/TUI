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
    }
}

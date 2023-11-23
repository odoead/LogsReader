using LogsReader.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogsReader
{
     public class LastLineReader:IReader
    {
        public  string Read(string path)
        {
            using (FileStream fileStream = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            {
                using (StreamReader reader = new StreamReader(fileStream))
                {
                    string line;
                    string lastLine = null;

                    while ((line = reader.ReadLine()) != null)
                    {
                        lastLine = line;
                    }


                    return lastLine;
                }
            }

        }
    }
}

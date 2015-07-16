using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace RemoteScript.Model
{
    public class ScriptFile
    {
        public void Test()
        {
            FileInfo f = new FileInfo("test.txt");
            var fs = f.OpenRead();
           
        }
        public FileInfo File { get; set; }
    }
}

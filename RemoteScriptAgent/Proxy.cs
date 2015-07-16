using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace RemoteScriptAgent
{
    public class Proxy : MarshalByRefObject
    {
        public void LoadAssembly(string assemblyPath)
        {
            try
            {
                Assembly.LoadFrom(assemblyPath);
            }
            catch 
            {
                
                
            }
        }
    }
}

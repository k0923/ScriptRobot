using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemoteScript.ModelingLib
{
    public abstract class ScriptRunner
    {
        public ScriptRunner() { }
    }

    public class DotNetScriptRunner:ScriptRunner
    {
        public DotNetScriptRunner(int a)
        {

        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sel
{
    class Other
    {
        public static void Do(string func, string args)
        {
            if (func == "goto")
            {
                if (Program.funcs.ContainsKey(args))
                    Program.i = Program.funcs[args];
            }
            else if (func == "gotoline")
            {
                Program.i = int.Parse(args);
            }
        }
    }
}

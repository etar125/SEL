using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sel.Variables
{
    class Vars
    {
        public static void Do(string func, string args, int inex)
        {
            if(func == "set")
            {
                string val = "";
                string va = "";
                int m = 0;
                for (int a = 0; a < args.Length; a++)
                {
                    if (args[a] == ' ')
                    {
                        m = a;
                        break;
                    }
                }
                va = args.Substring(0, m);
                val = args.Substring(m + 1);
                if (Program.vars.ContainsKey(va))
                    Program.vars[va] = Globl.ConvertS(val);
                else
                    Program.vars.Add(va, Globl.ConvertS(val));
            }
            else if (func == "if")
            {
                string[] sl = Globl.SplitByFirst(args, ' ');
                string name = sl[0];
                string sec1 = sl[1];
                string[] sl2 = Globl.SplitByFirst(sec1, ' ');
                string va = sl2[0];
                string sec2 = sl2[1];
                string[] sl3 = Globl.SplitByFirst(sec2, ' ');
                string oper = sl3[0];
                string val = Globl.ConvertS(sl3[1]);
                if (oper == "==")
                    if (Program.vars.ContainsKey(va) && Program.vars[va] != val)
                        Program.i = Program.Search(inex, "variable->endif " + name);
                else if (oper == "!=")
                    if (Program.vars.ContainsKey(va) && Program.vars[va] == val)
                        Program.i = Program.Search(inex, "variable->endif " + name);
                else if (oper == "?=")
                    if (Program.vars.ContainsKey(va) && !Program.vars[va].Contains(val))
                        Program.i = Program.Search(inex, "variable->endif " + name);
                else if (oper == "(=")
                    if (Program.vars.ContainsKey(va) && !Program.vars[va].StartsWith(val))
                        Program.i = Program.Search(inex, "variable->endif " + name);
                else if (oper == ")=")
                    if (Program.vars.ContainsKey(va) && !Program.vars[va].EndsWith(val))
                        Program.i = Program.Search(inex, "variable->endif " + name);
                else if (oper == "<=")
                {
                    if (Program.vars.ContainsKey(va) && double.Parse(Program.vars[va]) >= double.Parse(val))
                    {
                        Program.i = Program.Search(inex, "variable->endif " + name);
                    }
                }
                else if (oper == ">=")
                {
                    if (Program.vars.ContainsKey(va) && double.Parse(Program.vars[va]) <= double.Parse(val))
                    {
                        Program.i = Program.Search(inex, "variable->endif " + name);
                    }
                }
                else if (oper == "<=")
                {
                    if (Program.vars.ContainsKey(va) && double.Parse(Program.vars[va]) >= double.Parse(val))
                    {
                        Program.i = Program.Search(inex, "variable->endif " + name);
                    }
                }
                else if (oper == ">=")
                {
                    if (Program.vars.ContainsKey(va) && double.Parse(Program.vars[va]) <= double.Parse(val))
                    {
                        Program.i = Program.Search(inex, "variable->endif " + name);
                    }
                }
            }
            else if (func == "math")
            {
                string[] sl = Globl.SplitByFirst(args, ' ');
                string onea = Globl.ConvertS(sl[0]);
                string sec1 = sl[1];
                string[] sl2 = Globl.SplitByFirst(sec1, ' ');
                string oper = sl2[0];
                string sec2 = sl2[1];
                string[] sl3 = Globl.SplitByFirst(sec2, ' ');
                string twoa = Globl.ConvertS(sl3[0]);
                string sec3 = sl3[1];
                string[] sl4 = Globl.SplitByFirst(sec3, ' ');
                string res = sl4[0];
                double result = 0d;
                double one = double.Parse(onea);
                double two = double.Parse(twoa);
                if(oper == "+")
                {
                    result = one + two;
                }
                else if (oper == "-")
                {
                    result = one - two;
                }
                else if (oper == "*")
                {
                    result = one * two;
                }
                else if (oper == "/")
                {
                    result = one / two;
                }
                else if (oper == "%")
                {
                    result = one % two;
                }
                if (Program.vars.ContainsKey(res))
                {
                    Program.vars[res] = result.ToString();
                }
                else
                {
                    Program.vars.Add(res, result.ToString());
                }
            }
        }
    }
}

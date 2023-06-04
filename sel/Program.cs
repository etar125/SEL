using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using sel.Consol;
using sel.Variables;

namespace sel
{
    public class Program
    {
        public static Dictionary<string, string> vars = new Dictionary<string, string> { };
        public static Dictionary<string, string> temp = new Dictionary<string, string> { };
        public static Dictionary<string, List<string>> ars = new Dictionary<string, List<string>> { };
        public static Dictionary<string, int> funcs = new Dictionary<string, int> { };
        public static string[] ln;
        public static int i;

        static void Main(string[] args)
        {
            string file = "main.sel";
            foreach (string s in args)
                if (File.Exists(s) && s.EndsWith(".sel"))
                    file = s;
            if (File.Exists(file))
            {
                string[] cln = File.ReadAllLines(file);
                for (int ih = 0; ih < cln.Length; ih++)
                {
                    string lna = cln[ih];
                    for (int ii = 0; ii < lna.Length; ii++)
                    {
                        if (lna[ii] != ' ')
                        {
                            lna = lna.Remove(0, ii);
                            break;
                        }
                    }
                    cln[ih] = lna;
                }
                for (int ih = 0; ih < cln.Length; ih++)
                {
                    if (cln[ih] != "begin")
                    {
                        string[] sl = Globl.SplitByFirst(cln[ih], ' ');
                        vars.Add(sl[0], Globl.ConvertS(sl[1]));
                    }
                    else
                    {
                        ln = new string[cln.Length - 1];
                        for (int k = ih + 1; k < ln.Length; k++)
                        {
                            ln[k] = cln[k];
                        }
                    }
                }
                for (i = 0; i < ln.Length; i++)
                {
                    string tk = ln[i];
                    try
                    {
                        if (tk.StartsWith("func "))
                        {
                            string[] sl = Globl.SplitByFirst(tk, ' ');
                            funcs.Add(sl[1], i);
                        }
                    }
                    catch (Exception e) { Console.WriteLine("Line::" + i + "\nText::" + tk + "\nError::" + e.Message); Console.ReadKey(true); Environment.Exit(0); }
                }
                DoCode(funcs["main"]);
            }
        }

        public static bool endof = false;

        public static void DoCode(int index)
        {
            endof = false;
            for (i = index; i < ln.Length && !endof; i++)
            {
                string tk = ln[i];
                try
                {
                    string[] sl = Globl.SplitByFirst(tk, ' ');
                    string[] ll = sl[0].Split(new string[] { "." }, StringSplitOptions.None);
                    if (ll[0] == "end")
                        break;
                    if (ll[0] != "using")
                    {
                        if (ll[0] == "console")
                        {
                            Base.Do(ll[1], sl[1]);
                        }
                        else if (ll[0] == "variable")
                        {
                            Vars.Do(ll[1], sl[1], i);
                        }
                    }
                    else
                    {
                        if (ll[1] == "console")
                        {
                            for (int ih = i; ih < ln.Length; ih++)
                            {
                                if (ln[ih] == "end")
                                {
                                    endof = true; break;
                                }
                                if (ln[ih] == "enduse")
                                    break;
                                string[] sla = Globl.SplitByFirst(ln[ih], ' ');
                                Base.Do(sla[0], sla[1]);
                            }
                        }
                    }
                }
                catch (Exception e) { Console.WriteLine("Line::" + i + "\nText::" + tk + "\nError::" + e.Message); Console.ReadKey(true); Environment.Exit(0); }
            }
        }

        public static int Search(int startIndex, string text)
        {
            for (int ia = startIndex; ia < ln.Length; ia++)
            {
                if (ln[ia] == "end")
                    break;
                if (ln[ia] == text)
                {
                    return ia;
                }
            }
            return 0;
        }
    }
}

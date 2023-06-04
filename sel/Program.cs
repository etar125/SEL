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
                ln = File.ReadAllLines(file);
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
                for (i = 0; i < ln.Length; i++)
                {
                    string tk = ln[i];
                    try
                    {
                        string[] sl = Globl.SplitByFirst(tk, ' ');
                        string[] ll = sl[0].Split(new string[] { "->" }, StringSplitOptions.None);
                        if (ll[0] == "console")
                        {
                            Base.Do(ll[1], sl[1]);
                        }
                        else if (ll[0] == "variable")
                        {
                            Vars.Do(ll[1], sl[1], i);
                        }
                    }
                    catch (Exception e) { Console.WriteLine("Line::" + i + "\nText::" + tk + "\nError::" + e.Message); Console.ReadKey(true); Environment.Exit(0); }
                }
            }
        }

        public static int Search(int startIndex, string text)
        {
            for (int i = startIndex; i < ln.Length; i++)
            {
                if (ln[i] == text)
                {
                    return i;
                }
            }
            return 0;
        }
    }
}

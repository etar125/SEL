using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sel.Consol
{
    class Base
    {
        public static void Do(string func, string args)
        {
            if (func == "println")
                Console.WriteLine(Globl.ConvertS(args));
            else if (func == "print")
                Console.Write(Globl.ConvertS(args));
            else if (func == "clear")
                Console.Clear();
            else if (func == "exit")
                Environment.Exit(0);
            else if (func == "title")
                Console.Title = Globl.ConvertS(args);
            else if (func == "foreclr")
                Console.ForegroundColor = Globl.ParseBy(args);
            else if (func == "backclr")
                Console.BackgroundColor = Globl.ParseBy(args);
            else if (func == "getkey")
            {
                ConsoleKeyInfo k = Console.ReadKey();
                if (Program.vars.ContainsKey(args))
                    Program.vars[args] = k.Key.ToString();
                else
                    Program.vars.Add(args, k.Key.ToString());
            }
            else if (func == "sgetkey")
            {
                ConsoleKeyInfo k = Console.ReadKey(true);
                if (Program.vars.ContainsKey(args))
                    Program.vars[args] = k.Key.ToString();
                else
                    Program.vars.Add(args, k.Key.ToString());
            }
            else if (func == "pause")
                Console.ReadKey(true);
            else if (func == "getline")
            {
                string k = Console.ReadLine();
                if (Program.vars.ContainsKey(args))
                    Program.vars[args] = k;
                else
                    Program.vars.Add(args, k);
            }
            //Globl.met = Globl.Status.Complete;
        }
    }
}

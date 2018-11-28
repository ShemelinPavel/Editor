using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exegete;

namespace Lab
{
    class Program
    {
        static void Main(string[] args)
        {
            //string a = "ПОКА 1111 КОНЕЦ";
            string a = "ПОКА 111 КОНЕЦ";
            List<Token> tokens = Lexer.Lex(a);
            if (tokens != null)
            {
                foreach (var item in tokens)
                {
                    Console.WriteLine(item.ToString());
                }
            }

            Console.ReadKey();
        }
    }
}

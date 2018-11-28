using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

namespace Exegete
{
    public enum tokenTags { NONE, RESERVED, INT, ID}

    public struct Token
    {
        public string text;
        public tokenTags tag;

        public Token(string text, tokenTags tag)
        {
            this.text = text;
            this.tag = tag;
        }

        public override string ToString()
        {
            return $"{this.text} / {this.tag}";
        }
    }

    public static class Lexer
    {

        private static Dictionary<string, tokenTags> tokenPhrases;

        static Lexer()
        {

            tokenPhrases = new Dictionary<string, tokenTags>();

            tokenPhrases.Add(@"^[ \n\t]+", tokenTags.NONE);
            tokenPhrases.Add(@"^#[\n]*", tokenTags.NONE);
            tokenPhrases.Add(@"^\(", tokenTags.RESERVED);
            tokenPhrases.Add(@"^\)", tokenTags.RESERVED);
            tokenPhrases.Add(@"^\+", tokenTags.RESERVED);
            tokenPhrases.Add(@"^-", tokenTags.RESERVED);
            tokenPhrases.Add(@"^\*", tokenTags.RESERVED);
            tokenPhrases.Add(@"^/", tokenTags.RESERVED);
            tokenPhrases.Add(@"^>", tokenTags.RESERVED);
            tokenPhrases.Add(@"^<", tokenTags.RESERVED);
            tokenPhrases.Add(@"^>=", tokenTags.RESERVED);
            tokenPhrases.Add(@"^<=", tokenTags.RESERVED);
            tokenPhrases.Add(@"^=", tokenTags.RESERVED);
            tokenPhrases.Add(@"^!=", tokenTags.RESERVED);
            tokenPhrases.Add(@"^НАЧАЛО", tokenTags.RESERVED);
            tokenPhrases.Add(@"^ЕСЛИ", tokenTags.RESERVED);
            tokenPhrases.Add(@"^ТО", tokenTags.RESERVED);
            tokenPhrases.Add(@"^ИНАЧЕ", tokenTags.RESERVED);
            tokenPhrases.Add(@"^ПОКА", tokenTags.RESERVED);
            tokenPhrases.Add(@"^КОНЕЦ ЕСЛИ", tokenTags.RESERVED);
            tokenPhrases.Add(@"^КОНЕЦ ПОКА", tokenTags.RESERVED);
            tokenPhrases.Add(@"^КОНЕЦ", tokenTags.RESERVED);
            tokenPhrases.Add(@"^[0-9]+", tokenTags.INT);
            tokenPhrases.Add(@"^[A-Za-zА-Яа-я][A-Za-zА-Яа-я0-9]*", tokenTags.ID);
        }

        public static List<Token> Lex(string charasters)
        {

            List<Token> tokens = new List<Token>();
            int pos = 0;

            while(pos < charasters.Length - 1)
            {
                Match match = null;
                bool breakFlag = false;
                foreach (var item in tokenPhrases)
                {
                    match = Regex.Match(charasters.Substring(pos), item.Key);

                    if(match.Success)
                    {
                        string text = match.Groups[0].Value;
                        if (item.Value != tokenTags.NONE)
                        {
                            tokens.Add(new Token(text, item.Value));
                        }

                        pos = pos + text.Length;
                        breakFlag = true;
                        break;
                        
                    }
                }

                //если ни один из шаблонов ключевых слов не подошел
                if(!(breakFlag))
                {
                    Console.WriteLine($"Illegal character:{charasters[pos]}");
                    return null;
                }
            }
            return tokens;
        }
    }
}

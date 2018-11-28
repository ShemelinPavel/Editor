using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exegete
{
    public struct ParserResalt
    {
        public string Value;
        public int Position;


        public ParserResalt(string val, int pos)
        {
            this.Value = val;
            this.Position = pos;
        }

        public override string ToString()
        {
            return $"Result ({this.Value}, {this.Position})";
        }
    }

    public class Parser
    {
        private List<Token> tokens;
        private int position;

        public Parser(List<Token> tokens, int pos)
        {
            this.tokens = tokens;
            this.position = pos;
        }
    }
}

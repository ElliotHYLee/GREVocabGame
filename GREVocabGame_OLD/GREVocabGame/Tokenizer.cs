using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GREVocabGame
{
    class Tokenizer
    {

        public static List<String> getTokens(String sentence)
        {
            List<String> result = new List<String>();
            char[] delim = { ' ' };
            string[] temp = sentence.Split(delim);

            foreach(string element in temp)
            {
                if(!element.Equals(' '))
                {
                    result.Add(element);
                }
            }
            return result;
        }

    }
}
